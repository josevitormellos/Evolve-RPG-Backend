using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Drop")]
    [ApiController]
    public class DropController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DropController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string Name)
        {
            Drop drop = new Drop
            {
                Name = Name

            };
            _context.Drops.Add(drop);
            await _context.SaveChangesAsync();

            return Ok("Drop Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Drop>> Get(int id)
        {
            try
            {
                Drop drop = await _context.Drops.FirstAsync(d => d.Id == id);

                return drop;
            }
            catch (Exception ex)
            {
                return BadRequest("Drop não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Drop>>> Gets()
        {

            var listDrop = _context.Drops.ToList();

            return listDrop;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Drop updateRequest)
        {
            try
            {
                Drop drop = await _context.Drops.FirstAsync(d => d.Id == updateRequest.Id);

                drop.Name = updateRequest.Name ?? drop.Name;


                _context.Entry(drop).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Drop Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Drop drop = await _context.Drops.FirstAsync(d => d.Id == id);

                _context.Drops.Remove(drop);
                await _context.SaveChangesAsync();
                return Ok("Drop Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop não encontrada");
            }
        }
    }
}
