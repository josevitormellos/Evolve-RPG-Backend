using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EffectsConection")]
    [ApiController]
    public class EffectsConectionController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EffectsConectionController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string Name)
        {
            EffectsConection effectsConection = new EffectsConection
            {
                Name = Name

            };
            _context.EffectsConections.Add(effectsConection);
            await _context.SaveChangesAsync();

            return Ok("Conexão de Efeito Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EffectsConection>> Get(int id)
        {
            try
            {
                EffectsConection effectsConection = await _context.EffectsConections.FirstAsync(ec => ec.Id == id);

                return effectsConection;
            }
            catch (Exception ex)
            {
                return BadRequest("Conexão de Efeitos não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EffectsConection>>> Gets()
        {

            var listEffectsConection = _context.EffectsConections.ToList();

            return listEffectsConection;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EffectsConection updateRequest)
        {
            try
            {
                EffectsConection effectsConection = await _context.EffectsConections.FirstAsync(ec => ec.Id == updateRequest.Id);

                effectsConection.Name = updateRequest.Name ?? effectsConection.Name;


                _context.Entry(effectsConection).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Conexão de Efeito Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Conexão de Efeito não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EffectsConection effectsConection = await _context.EffectsConections.FirstAsync(ec => ec.Id == id);

                _context.EffectsConections.Remove(effectsConection);
                await _context.SaveChangesAsync();
                return Ok("Conexão de Efeito Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Conexão de Efeito não encontrada");
            }
        }
    }
}
