using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerMonsterEquip")]
    [ApiController]
    public class PlayerMonsterEquipController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerMonsterEquipController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerMonsterEquipRequest request)
        {
            PlayerMonsterEquip playerMonsterEquip = new PlayerMonsterEquip
            {
                IdPlayerMonster = request.IdPlayerMonster,
                IdPlayerEquip = request.IdPlayerEquip,


            };
            _context.PlayerMonsterEquips.Add(playerMonsterEquip);
            await _context.SaveChangesAsync();

            return Ok("Equipado o Monstro do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerMonsterEquip>> Get(int idPlayerMonster, int idPlayerEquip)
        {
            try
            {
                PlayerMonsterEquip playerMonsterEquip = await _context.PlayerMonsterEquips.FirstAsync(pm => pm.IdPlayerMonster == idPlayerMonster && pm.IdPlayerEquip == idPlayerEquip);

                return playerMonsterEquip;
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento no Monstro do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerMonsterEquip>>> Gets(int idPlayerMonster)
        {

            var listPlayerMonsterEquip = _context.PlayerMonsterEquips.Where(pm => pm.IdPlayerMonster == idPlayerMonster).ToList();

            return listPlayerMonsterEquip;
        }

        
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(PlayerMonsterEquipRequest deleteRequest)
        {
            try
            {
                PlayerMonsterEquip playerMonsterEquip = await _context.PlayerMonsterEquips.FirstAsync(pm => pm.IdPlayerMonster == deleteRequest.IdPlayerMonster && pm.IdPlayerEquip == deleteRequest.IdPlayerEquip);

                _context.PlayerMonsterEquips.Remove(playerMonsterEquip);
                await _context.SaveChangesAsync();
                return Ok("Equipamento no Monstro do Jogador removido com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento no Monstro do Jogador não encontrada");
            }
        }
    }
}
