using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/MonsterSkill")]
    [ApiController]
    public class MonsterSkillController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MonsterSkillController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(MonsterSkillRequest request)
        {
            MonsterSkill monsterSkill = new MonsterSkill
            {
                IdMonster = request.IdMonster,
                IdSkill = request.IdSkill,
                Level = request.Level

            };
            _context.MonsterSkills.Add(monsterSkill);
            await _context.SaveChangesAsync();

            return Ok("Habilidade do Monstro Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<MonsterSkill>> Get(int idMonster, int idSkill)
        {
            try
            {
                MonsterSkill monsterSkill = await _context.MonsterSkills.FirstAsync(ms => ms.IdMonster == idMonster && ms.IdSkill == idSkill);

                return monsterSkill;
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade do Monstro não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<MonsterSkill>>> Gets(int idMonster)
        {

            var listMonsterSkill = _context.MonsterSkills.ToList();

            return listMonsterSkill;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(MonsterSkillRequest updateRequest)
        {
            try
            {
                MonsterSkill monsterSkill = await _context.MonsterSkills.FirstAsync(ms => ms.IdMonster == updateRequest.IdMonster && ms.IdSkill == updateRequest.IdSkill);

                monsterSkill.Level = updateRequest.Level;


                _context.Entry(monsterSkill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Habilidade do Monstro Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade do Monstro não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                MonsterSkill monsterSkill = await _context.MonsterSkills.FirstAsync(ms => ms.Id == id);

                _context.MonsterSkills.Remove(monsterSkill);
                await _context.SaveChangesAsync();
                return Ok("Habilidade do Monstro Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade do Monstro não encontrada");
            }
        }
    }
}
