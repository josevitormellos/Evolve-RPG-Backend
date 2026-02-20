using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerItem")]
    [ApiController]
    public class PlayerItemController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerItemController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerItemRequest request)
        {
            PlayerItem playerItem = new PlayerItem
            {
                IdUser = request.IdUser,
                IdItem = request.IdItem,
                Amount = request.Amount,
                IsBackPack = request.IsBackPack


            };
            _context.PlayerItems.Add(playerItem);
            await _context.SaveChangesAsync();

            return Ok("Item do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerItem>> Get(int idUser, int idItem)
        {
            try
            {
                PlayerItem playerItem = await _context.PlayerItems.FirstAsync(pi => pi.IdUser == idUser && pi.IdItem == idItem);

                return playerItem;
            }
            catch (Exception ex)
            {
                return BadRequest("Item do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerItem>>> Gets(int idUser)
        {

            var listPlayerItem = _context.PlayerItems.Where(pe => pe.IdUser == idUser).ToList();

            return listPlayerItem;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(PlayerItemRequest updateRequest)
        {
            try
            {
                PlayerItem playerItem = await _context.PlayerItems.FirstAsync(pi => pi.IdUser == updateRequest.IdUser && pi.IdItem == updateRequest.IdItem);

                playerItem.Amount = updateRequest.Amount;
                playerItem.IsBackPack = updateRequest.IsBackPack;

                _context.Entry(playerItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Item do Jogador Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Item do Jogador não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                PlayerItem playerItem = await _context.PlayerItems.FirstAsync(pe => pe.Id == id);

                _context.PlayerItems.Remove(playerItem);
                await _context.SaveChangesAsync();
                return Ok("Item do Jogador Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Item do Jogador não encontrada");
            }
        }
    }
}
