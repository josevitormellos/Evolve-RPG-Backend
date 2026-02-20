using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/DropItem")]
    [ApiController]
    public class DropItemController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DropItemController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(DropItemRequest request)
        {
            DropItem dropItem = new DropItem
            {
                IdItem = request.IdItem,
                IdDrop = request.IdDrop,
                ChanceDrop = request.ChanceDrop,
                IsBoss = request.IsBoss

            };
            _context.DropItems.Add(dropItem);
            await _context.SaveChangesAsync();

            return Ok("Drop de Item Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<DropItem>> Get(int idDrop, int idItem)
        {
            try
            {
                DropItem dropItem = await _context.DropItems.FirstAsync(di => di.IdDrop == idDrop && di.IdItem == idItem);

                return dropItem;
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Item não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<DropItem>>> Gets()
        {

            var listDropItem = _context.DropItems.ToList();

            return listDropItem;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DropItemRequest updateRequest)
        {
            try
            {
                DropItem dropItem = await _context.DropItems.FirstAsync(di => di.IdDrop == updateRequest.IdDrop && di.IdItem == updateRequest.IdItem);

                dropItem.ChanceDrop = updateRequest.ChanceDrop;
                dropItem.IsBoss = updateRequest.IsBoss;


                _context.Entry(dropItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Drop de Item Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Item não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DropItem dropItem = await _context.DropItems.FirstAsync(di => di.Id == id);

                _context.DropItems.Remove(dropItem);
                await _context.SaveChangesAsync();
                return Ok("Drop de Item Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Item não encontrada");
            }
        }
    }
}
