using Azure.Core;
using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Evolve_Game.Validate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerMonster")]
    [ApiController]
    public class PlayerMonsterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerMonsterController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerMonsterRequest request)
        {
            System.Random rnd = new System.Random();
            PlayerMonster playerMonster = new PlayerMonster
            {
                IdUser = request.IdUser,
                IdMonster = request.IdMonster,
                Level = request.Level,
                Xp = 0,
                IdRarity = _context.Monsters.First(m => m.Id == request.IdMonster).IdRarity,
                ColorMagicGreen = rnd.Next(0, 101),
                ColorMagicBlue = rnd.Next(0, 101),
                ColorMagicRed = rnd.Next(0, 101),
                ColorMagicBlack = rnd.Next(0, 101),
                ColorMagicWhite = rnd.Next(0, 101),
                ColorMagicPink = rnd.Next(0, 101),
                ColorMagicPurple = rnd.Next(0, 101)


            };
            _context.PlayerMonsters.Add(playerMonster);
            await _context.SaveChangesAsync();

            return Ok("Monstro do Jogador Salvo com sucesso");
        }
        [HttpPost("InitRegister")]
        public async Task<ActionResult> InitRegister(int IdUser)
        {
            
            List<int> values = ValidationPlayerMonster.CalcularAtributos();
            PlayerMonster playerMonster = new PlayerMonster
            {
                IdUser = IdUser,
                IdMonster = 1,
                Level = 1,
                Xp = 0,
                IdRarity = _context.Monsters.First(m => m.Id == 1).IdRarity,
                ColorMagicGreen = values[0],
                ColorMagicBlue = values[1],
                ColorMagicRed = values[2],
                ColorMagicBlack = values[5],
                ColorMagicWhite = values[3],
                ColorMagicPink = values[6],
                ColorMagicPurple = values[4]


            };
            _context.PlayerMonsters.Add(playerMonster);
            await _context.SaveChangesAsync();

            return Ok("Monstro do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerMonster>> Get(int id)
        {
            try
            {
                PlayerMonster playerMonster = await _context.PlayerMonsters.FirstAsync(pm => pm.Id == id);

                return playerMonster;
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerMonster>>> Gets(int idUser)
        {

            var listPlayerMonster = _context.PlayerMonsters.Where(pm => pm.IdUser == idUser).ToList();

            return listPlayerMonster;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(PlayerMonsterUpdateRequest updateRequest)
        {
            try
            {
                PlayerMonster playerMonster = await _context.PlayerMonsters.FirstAsync(pm => pm.Id == updateRequest.Id);
                playerMonster.Level = updateRequest.Level;
                playerMonster.Xp = updateRequest.Xp;
                playerMonster.IdRarity = updateRequest.IdRarity;
                playerMonster.ColorMagicGreen = updateRequest.ColorMagicGreen;
                playerMonster.ColorMagicBlue = updateRequest.ColorMagicBlue;
                playerMonster.ColorMagicRed = updateRequest.ColorMagicRed;
                playerMonster.ColorMagicBlack = updateRequest.ColorMagicBlack;
                playerMonster.ColorMagicWhite = updateRequest.ColorMagicWhite;  
                playerMonster.ColorMagicPink = updateRequest.ColorMagicPink;
                playerMonster.ColorMagicPurple = updateRequest.ColorMagicPurple;


                _context.Entry(playerMonster).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Monstro do Jogador Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro do Jogador não encontrada");
            }
        }

        [HttpPut("evolution")]
        public async Task<IActionResult> Evolution(EvolutionRequest updateRequest)
        {
            try
            {
                PlayerMonster playerMonster = await _context.PlayerMonsters.FirstAsync(pm => pm.Id == updateRequest.IdPlayerMonster);
                EvolutionMonster evolutionMonster = await _context.EvolutionMonsters.FirstAsync(em => em.IdMonsterEvolution == updateRequest.IdMonsterEvolution);
                Monster monster = await _context.Monsters.FirstAsync(monster => monster.Id == updateRequest.IdMonsterEvolution);
                playerMonster.Level = 1;
                playerMonster.Xp = 0;
                playerMonster.IdRarity = monster.IdRarity;
                playerMonster.IdMonster = monster.Id;

                _context.Entry(playerMonster).State = EntityState.Modified;

                PlayerEvolutionMonsterController pemc = new PlayerEvolutionMonsterController(_context);
                PlayerEvolutionMonsterRequest pemr = new PlayerEvolutionMonsterRequest
                {
                    IdPlayerMonster = playerMonster.Id,
                    IdEvolutionMonster = evolutionMonster.Id

                };

                await pemc.Register(pemr);
                await _context.SaveChangesAsync();
                return Ok("Evolução feita com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro do Jogador não encontrada");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                PlayerMonster playerMonster = await _context.PlayerMonsters.FirstAsync(pm => pm.Id == id);

                _context.PlayerMonsters.Remove(playerMonster);
                await _context.SaveChangesAsync();
                return Ok("Monstro do Jogador Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro do Jogador não encontrada");
            }
        }
    }
}
