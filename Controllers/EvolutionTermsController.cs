using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EvolutionTerms")]
    [ApiController]
    public class EvolutionTermsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EvolutionTermsController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(EvolutionTermsRequest request)
        {
            EvolutionTerms evolutionTerms = new EvolutionTerms
            {
                IdEvolutionMonster = request.IdEvolutionMonster,
                IdEvolutionType = request.IdEvolutionType,
                Amount = request.Amount

            };
            _context.EvolutionTerms.Add(evolutionTerms);
            await _context.SaveChangesAsync();

            return Ok("Termo de Evolução salva Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EvolutionTerms>> Get(int Id)
        {
            try
            {
                EvolutionTerms evolutionTerms = await _context.EvolutionTerms.FirstAsync(et => et.Id == Id);

                return evolutionTerms;
            }
            catch (Exception ex)
            {
                return BadRequest("Termo de Evolução não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EvolutionTerms>>> Gets(int IdEvolution)
        {

            var listEvolutionTerms = _context.EvolutionTerms.Where(et => et.IdEvolutionMonster == IdEvolution).ToList();

            return listEvolutionTerms;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EvolutionTermsUpdateRequest updateRequest)
        {
            try
            {
                EvolutionTerms evolutionTerms = await _context.EvolutionTerms.FirstAsync(et => et.IdEvolutionMonster == updateRequest.IdEvolutionMonster && et.IdEvolutionType == updateRequest.IdEvolutionType);

                evolutionTerms.Amount = updateRequest.Amount;


                _context.Entry(evolutionTerms).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Termos de Evolução Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Termos de Evolução não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EvolutionTerms evolutionTerms = await _context.EvolutionTerms.FirstAsync(et => et.Id == id);

                _context.EvolutionTerms.Remove(evolutionTerms);
                await _context.SaveChangesAsync();
                return Ok("Termos de Evolução Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Termos de Evolução não encontrada");
            }
        }
    }
}
