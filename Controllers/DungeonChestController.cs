using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/DungeonChest")]
    [ApiController]
    public class DungeonChestController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DungeonChestController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(DungeonChestRequest request)
        {
            DungeonChest dungeonChest = new DungeonChest
            {
                IdDungeon = request.IdDungeon,
                IdChest = request.IdChest,
                ChanceApper = request.ChanceApper

            };
            _context.DungeonChests.Add(dungeonChest);
            await _context.SaveChangesAsync();

            return Ok("Baú da Masmorra Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<DungeonChest>> Get(int idDungeon, int IdChest)
        {
            try
            {
                DungeonChest dungeonChest = await _context.DungeonChests.FirstAsync(dc => dc.IdDungeon == idDungeon && dc.IdChest == IdChest);

                return dungeonChest;
            }
            catch (Exception ex)
            {
                return BadRequest("Baú da Masmorra não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<DungeonChest>>> Gets()
        {

            var listDungeonChest = _context.DungeonChests.ToList();

            return listDungeonChest;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DungeonChestRequest updateRequest)
        {
            try
            {
                DungeonChest dungeonChest = await _context.DungeonChests.FirstAsync(dc => dc.IdDungeon == updateRequest.IdDungeon);

                dungeonChest.ChanceApper = updateRequest.ChanceApper;


                _context.Entry(dungeonChest).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Baú da Masmorra Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Baú da Masmorra não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DungeonChest dungeonChest = await _context.DungeonChests.FirstAsync(dc => dc.Id == id);

                _context.DungeonChests.Remove(dungeonChest);
                await _context.SaveChangesAsync();
                return Ok("Baú da Masmorra Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Baú da Masmorra não encontrada");
            }
        }
    }
}
