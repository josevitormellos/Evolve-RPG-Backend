using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerEvolutionMonster")]
    [ApiController]
    public class PlayerEvolutionMonsterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerEvolutionMonsterController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerEvolutionMonsterRequest request)
        {
            PlayerEvolutionMonster playerEvolutionMonster = new PlayerEvolutionMonster
            {
                IdPlayerMonster = request.IdPlayerMonster,
                IdEvolutionMonster = request.IdEvolutionMonster


            };
            _context.PlayerEvolutionMonsters.Add(playerEvolutionMonster);
            await _context.SaveChangesAsync();

            return Ok("Evoluções do monstro do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerEvolutionMonster>> Get(int idPlayerMonster, int idEvolutionMonster)
        {
            try
            {
                PlayerEvolutionMonster playerEvolutionMonster = await _context.PlayerEvolutionMonsters.FirstAsync(pe => pe.IdPlayerMonster == idPlayerMonster && pe.IdEvolutionMonster == idEvolutionMonster);

                return playerEvolutionMonster;
            }
            catch (Exception ex)
            {
                return BadRequest("Evoluções do monstro do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerEvolutionMonster>>> Gets(int idPlayerMonster)
        {

            var listPlayerEvolutionMonster = _context.PlayerEvolutionMonsters.Where(pe => pe.IdPlayerMonster == idPlayerMonster).ToList();

            return listPlayerEvolutionMonster;
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                PlayerEvolutionMonster playerEvolutionMonster = await _context.PlayerEvolutionMonsters.FirstAsync(pe => pe.Id == id);

                _context.PlayerEvolutionMonsters.Remove(playerEvolutionMonster);
                await _context.SaveChangesAsync();
                return Ok("Evoluções do monstro do Jogador Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Evoluções do monstro do Jogador não encontrada");
            }
        }
    }
}
