using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EvolutionMonster")]
    [ApiController]
    public class EvolutionMonsterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EvolutionMonsterController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(EvolutionMonsterRequest request)
        {
            EvolutionMonster evolutionMonster = new EvolutionMonster
            {
                IdMonsterEvolution = request.IdEvolution,
                IdMonster = request.IdMonster,
                MinLevel = request.MinLevel

            };
            _context.EvolutionMonsters.Add(evolutionMonster);
            await _context.SaveChangesAsync();

            return Ok("Evolução do Monstro Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EvolutionMonster>> Get(EvolutionMonsterRequest request)
        {
            try
            {
                EvolutionMonster evolutionMonster = await _context.EvolutionMonsters.FirstAsync(em => em.IdMonster == request.IdMonster && em.IdMonsterEvolution == request.IdEvolution);

                return evolutionMonster;
            }
            catch (Exception ex)
            {
                return BadRequest("Evoluão do Monstro não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EvolutionMonster>>> Gets()
        {

            var listEvolutionMonster = _context.EvolutionMonsters.ToList();

            return listEvolutionMonster;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EvolutionMonsterRequest updateRequest)
        {
            try
            {
                EvolutionMonster evolutionMonster = await _context.EvolutionMonsters.FirstAsync(em => em.IdMonster == updateRequest.IdMonster && em.IdMonsterEvolution == updateRequest.IdEvolution);

                evolutionMonster.IdMonster = updateRequest.IdMonster;
                evolutionMonster.IdMonsterEvolution = updateRequest.IdEvolution;
                evolutionMonster.MinLevel = updateRequest.MinLevel;
               


                _context.Entry(evolutionMonster).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Evolução do Monstro Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(" Evolução do Monstro não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(EvolutionMonsterRequest deleteRequest)
        {
            try
            {
                EvolutionMonster evolutionMonster = await _context.EvolutionMonsters.FirstAsync(dm => dm.IdMonster == deleteRequest.IdMonster && dm.IdMonsterEvolution == deleteRequest.IdEvolution);

                _context.EvolutionMonsters.Remove(evolutionMonster);
                await _context.SaveChangesAsync();
                return Ok("Evolução do Monstro Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Evolução do Monstro não encontrada");
            }
        }
    }
}
