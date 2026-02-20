using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Dungeon")]
    [ApiController]
    public class DungeonController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DungeonController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] DungeonRequest request)
        {
            Dungeon dungeon = new Dungeon
            {
                Name = request.Name,
                Description = request.Description,
                IdMap = request.IdMap,
                PosMax = request.PosMax
                
            };
            _context.Dungeons.Add(dungeon);
            await _context.SaveChangesAsync();

            return Ok("Dungeon Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Dungeon>> Get(int id)
        {
            try { 
            Dungeon dungeon = await _context.Dungeons.FirstAsync(d => d.Id == id);

            return dungeon;
            }
            catch (Exception ex)
            {
                return BadRequest("Dungeon não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Dungeon>>> Gets()
        {
            var listDungeon = _context.Dungeons.ToList();

            return listDungeon;
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update(DungeonUpdateRequest updateRequest)
        {
            try
            {
                Dungeon dungeon = await _context.Dungeons.FirstAsync(d => d.Id == updateRequest.Id);

                dungeon.Name = updateRequest.Name ?? dungeon.Name;
                dungeon.Description = updateRequest.Description ?? dungeon.Description;
                if(updateRequest.IdMap > 0)
                    dungeon.IdMap = updateRequest.IdMap;
                if(updateRequest.PosMax > 0)
                    dungeon.PosMax = updateRequest.PosMax;
                
                _context.Entry(dungeon).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Dungeon Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Dungeon não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Dungeon dungeon = await _context.Dungeons.FirstAsync(d => d.Id == id);

                _context.Dungeons.Remove(dungeon);
                await _context.SaveChangesAsync();
                return Ok("Dungeon Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Dungeon não encontrada");
            }
        }
    }
}
