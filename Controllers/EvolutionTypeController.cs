using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EvolutionType")]
    [ApiController]
    public class EvolutionTypeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EvolutionTypeController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string Name)
        {
            EvolutionType evolutionType = new EvolutionType
            {
                Name = Name

            };
            _context.EvolutionTypes.Add(evolutionType);
            await _context.SaveChangesAsync();

            return Ok("Tipo de Evolução Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EvolutionType>> Get(int id)
        {
            try
            {
                EvolutionType evolutionType = await _context.EvolutionTypes.FirstAsync(et => et.Id == id);

                return evolutionType;
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Evolução não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EvolutionType>>> Gets()
        {

            var listEvolutionTypes = _context.EvolutionTypes.ToList();

            return listEvolutionTypes;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EvolutionType updateRequest)
        {
            try
            {
                EvolutionType evolutionType = await _context.EvolutionTypes.FirstAsync(et => et.Id == updateRequest.Id);

                evolutionType.Name = updateRequest.Name ?? evolutionType.Name;


                _context.Entry(evolutionType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Tipo de Evolução Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Evolução não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EvolutionType evolutionType = await _context.EvolutionTypes.FirstAsync(ae => ae.Id == id);

                _context.EvolutionTypes.Remove(evolutionType);
                await _context.SaveChangesAsync();
                return Ok("Tipo de Evolução Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Evolução não encontrada");
            }
        }
    }
}
