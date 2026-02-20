using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ItemController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(ItemRequest request)
        {
            var effectConection = new EffectsConectionController(_context);
            await effectConection.Register(request.Name);
            Item item = new Item
            {
                Name = request.Name,
                Icon = request.Icon,
                Description = request.Description,
                IsConsumable = request.IsConsumable,
                Gold = request.Gold,
                IdRarity = request.IdRarity,
                IdEffectsConection = _context.EffectsConections.Max(effect => effect.Id)

            };
            _context.Itens.Add(item);
            await _context.SaveChangesAsync();

            return Ok("Item Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            try
            {
                Item item = await _context.Itens.FirstAsync(i => i.Id == id);

                return item;
            }
            catch (Exception ex)
            {
                return BadRequest("Item não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Item>>> Gets()
        {

            var listItens = _context.Itens.ToList();

            return listItens;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ItemUpdateRequest updateRequest)
        {
            try
            {
                Item item = await _context.Itens.FirstAsync(i => i.Id == updateRequest.Id);

                item.Name = updateRequest.Name ?? item.Name;
                item.Description = updateRequest.Description ?? item.Description;
                item.IsConsumable = updateRequest.IsConsumable;
                item.Gold = updateRequest.Gold;
                item.Icon = updateRequest.Icon;
                item.IdRarity   = updateRequest.IdRarity;

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Item Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Item não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Item item = await _context.Itens.FirstAsync(i => i.Id == id);

                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("Item Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Item não encontrada");
            }
        }
    }
}
