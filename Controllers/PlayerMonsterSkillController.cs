using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerMonsterSkill")]
    [ApiController]
    public class PlayerMonsterSkillController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerMonsterSkillController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerMonsterSkillRequest request)
        {
            PlayerMonsterSkill playerMonsterSkill = new PlayerMonsterSkill
            {
                IdPlayerMonster = request.IdPlayerMonster,
                IdSkill = request.IdSkill,


            };
            _context.PlayerMonsterSkills.Add(playerMonsterSkill);
            await _context.SaveChangesAsync();

            return Ok("Habilidade o Monstro do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerMonsterSkill>> Get(int idPlayerMonster, int idSkill)
        {
            try
            {
                PlayerMonsterSkill playerMonsterSkill = await _context.PlayerMonsterSkills.FirstAsync(pm => pm.IdPlayerMonster == idPlayerMonster && pm.IdSkill == idSkill);

                return playerMonsterSkill;
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade no Monstro do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerMonsterSkill>>> Gets(int idPlayerMonster)
        {

            var listPlayerMonsterSkill = _context.PlayerMonsterSkills.Where(pm => pm.IdPlayerMonster == idPlayerMonster).ToList();

            return listPlayerMonsterSkill;
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(PlayerMonsterSkillRequest deleteRequest)
        {
            try
            {
                PlayerMonsterSkill playerMonsterSkill = await _context.PlayerMonsterSkills.FirstAsync(pm => pm.IdPlayerMonster == deleteRequest.IdPlayerMonster && pm.IdSkill == deleteRequest.IdSkill);

                _context.PlayerMonsterSkills.Remove(playerMonsterSkill);
                await _context.SaveChangesAsync();
                return Ok("Habilidade no Monstro do Jogador removido com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade no Monstro do Jogador não encontrada");
            }
        }
    }
}
