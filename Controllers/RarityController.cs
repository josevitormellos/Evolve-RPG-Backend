using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Rarity")]
    [ApiController]
    public class RarityController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public RarityController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string Name)
        {
            Rarity rarity = new Rarity
            {
                Name = Name

            };
            _context.Rarities.Add(rarity);
            await _context.SaveChangesAsync();

            return Ok("Raridade Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Rarity>> Get(int id)
        {
            try
            {
                Rarity rarity = await _context.Rarities.FirstAsync(r => r.Id == id);

                return rarity;
            }
            catch (Exception ex)
            {
                return BadRequest("Raridade não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Rarity>>> Gets()
        {
            var listRarity = _context.Rarities.ToList();

            return listRarity;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(Rarity updateRequest)
        {
            try
            {
                Rarity rarity = await _context.Rarities.FirstAsync(r => r.Id == updateRequest.Id);

                rarity.Name = updateRequest.Name ?? rarity.Name;
               

                _context.Entry(rarity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Raridade Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Raridade não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Rarity rarity = await _context.Rarities.FirstAsync(r => r.Id == id);

                _context.Rarities.Remove(rarity);
                await _context.SaveChangesAsync();
                return Ok("Raridade Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Raridade não encontrada");
            }
        }

    }
}
