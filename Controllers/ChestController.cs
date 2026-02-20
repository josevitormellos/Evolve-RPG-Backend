using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Chest")]
    [ApiController]
    public class ChestController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ChestController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(ChestRequest request)
        {
            var drop = new DropController(_context);
            await drop.Register(request.Name);
            Chest chest = new Chest
            {
                Name = request.Name,
                IdIcon = request.IdIcon,
                IdDrop = _context.Drops.Max(drop => drop.Id)

            };
            _context.Chests.Add(chest);
            await _context.SaveChangesAsync();

            return Ok("Bau Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Chest>> Get(int id)
        {
            try
            {
                Chest chest = await _context.Chests.FirstAsync(c => c.Id == id);

                return chest;
            }
            catch (Exception ex)
            {
                return BadRequest("Bau não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Chest>>> Gets()
        {

            var listChest = _context.Chests.ToList();

            return listChest;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ChestUpdateRequest updateRequest)
        {
            try
            {
                Chest chest = await _context.Chests.FirstAsync(c => c.Id == updateRequest.Id);

                chest.Name = updateRequest.Name ?? chest.Name;
                chest.IdIcon = updateRequest.IdIcon;

                _context.Entry(chest).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Baú Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Baú não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Chest chest = await _context.Chests.FirstAsync(c => c.Id == id);

                _context.Chests.Remove(chest);
                await _context.SaveChangesAsync();
                return Ok("Baú Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Baú não encontrada");
            }
        }
    }
}
