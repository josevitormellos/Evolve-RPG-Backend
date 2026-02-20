using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/DungeonMonster")]
    [ApiController]
    public class DungeonMonsterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DungeonMonsterController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(DungeonMonsterRequest request)
        {
            DungeonMonster dungeonMonster = new DungeonMonster
            {
                IdDungeon = request.IdDungeon,
                IdMonster = request.IdMonster,
                MinLevel = request.MinLevel,
                MaxLevel = request.MaxLevel,
                IsBoss = request.IsBoss

            };
            _context.DungeonMonsters.Add(dungeonMonster);
            await _context.SaveChangesAsync();

            return Ok("Monstros da Masmorra Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<DungeonMonster>> Get(int id)
        {
            try
            {
                DungeonMonster dungeonMonster = await _context.DungeonMonsters.FirstAsync(dm => dm.Id == id);

                return dungeonMonster;
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro da Masmorra não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<DungeonMonster>>> Gets()
        {

            var listDungeonMonster = _context.DungeonMonsters.ToList();

            return listDungeonMonster;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DungeonMonsterRequest updateRequest)
        {
            try
            {
                DungeonMonster dungeonMonster = await _context.DungeonMonsters.FirstAsync(dm => dm.IdMonster == updateRequest.IdMonster && dm.IdDungeon == updateRequest.IdDungeon);

                dungeonMonster.MaxLevel = updateRequest.MaxLevel;
                dungeonMonster.MinLevel = updateRequest.MinLevel;
                dungeonMonster.IsBoss = updateRequest.IsBoss;


                _context.Entry(dungeonMonster).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Monstro da Masmorra Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro da Masmorra não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DungeonMonsterDeleteRequest deleteRequest)
        {
            try
            {
                DungeonMonster dungeonMonster = await _context.DungeonMonsters.FirstAsync(dm => dm.IdMonster == deleteRequest.IdMonster && dm.IdDungeon == deleteRequest.IdDungeon);

                _context.DungeonMonsters.Remove(dungeonMonster);
                await _context.SaveChangesAsync();
                return Ok("Monstro da Masmorra Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Monstro da Masmorra não encontrada");
            }
        }
    }
}
