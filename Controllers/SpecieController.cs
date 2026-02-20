using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Specie")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SpecieController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult<Specie>> Register(string Name)
        {
            Specie specie = new Specie
            {
                Name = Name
                
            };
            _context.Species.Add(specie);
            await _context.SaveChangesAsync();

            return Ok("Specie Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Specie>> Get(int id)
        {
            try
            {
                Specie specie = await _context.Species.FirstAsync(s => s.Id == id);

                return specie;
            }
            catch (Exception ex)
            {
                return BadRequest("Raridade não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Specie>>> Gets()
        {
            
            var listSpecie = _context.Species.ToList();

            return listSpecie;
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(Specie updateRequest)
        {
            try
            {
                Specie specie = await _context.Species.FirstAsync(s => s.Id == updateRequest.Id);

                specie.Name = updateRequest.Name ?? specie.Name;


                _context.Entry(specie).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Especie Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Especie não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Specie specie = await _context.Species.FirstAsync(s => s.Id == id);

                _context.Species.Remove(specie);
                await _context.SaveChangesAsync();
                return Ok("Especie Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Especie não encontrada");
            }
        }
    }
}
