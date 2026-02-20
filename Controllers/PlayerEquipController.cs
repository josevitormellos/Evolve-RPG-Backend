using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/PlayerEquip")]
    [ApiController]
    public class PlayerEquipController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PlayerEquipController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(PlayerEquipRequest request)
        {
            
            PlayerEquip playerEquip = new PlayerEquip
            {
                IdUser = request.IdUser,
                IdEquip = request.IdEquip,
                Life = request.Life,
                Magicula = request.Magicula,
                PhysicalDamage = request.PhysicalDamage,
                MagicDamage = request.MagicDamage,
                PhysicalDefense = request.PhysicalDefense,
                MagicDefense = request.MagicDefense,
                SpeedAttack = request.SpeedAttack,
                CriticalChance = request.CriticalChance,
                CriticalDamage = request.CriticalDamage,
                IsBackPack = request.IsBackPack

            };
            _context.PlayerEquips.Add(playerEquip);
            await _context.SaveChangesAsync();

            return Ok("Equipamento do Jogador Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<PlayerEquip>> Get(int idUser, int idEquip)
        {
            try
            {
                PlayerEquip playerEquip = await _context.PlayerEquips.FirstAsync(pe => pe.IdUser == idUser && pe.IdEquip == idEquip);

                return playerEquip;
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento do Jogador não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<PlayerEquip>>> Gets(int idUser)
        {

            var listPlayerEquip = _context.PlayerEquips.Where(pe => pe.IdUser == idUser).ToList();

            return listPlayerEquip;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(PlayerEquipRequest updateRequest)
        {
            try
            {
                PlayerEquip playerEquip = await _context.PlayerEquips.FirstAsync(pe => pe.IdUser == updateRequest.IdUser && pe.IdEquip == updateRequest.IdEquip);

                playerEquip.Life = updateRequest.Life;
                playerEquip.Magicula = updateRequest.Magicula;
                playerEquip.PhysicalDamage = updateRequest.PhysicalDamage;
                playerEquip.MagicDamage = updateRequest.MagicDamage;
                playerEquip.PhysicalDefense = updateRequest.PhysicalDefense;
                playerEquip.MagicDefense = updateRequest.MagicDefense;
                playerEquip.SpeedAttack = updateRequest.SpeedAttack;
                playerEquip.CriticalChance = updateRequest.CriticalChance;
                playerEquip.CriticalDamage = updateRequest.CriticalDamage;
                playerEquip.IsBackPack = updateRequest.IsBackPack;


                _context.Entry(playerEquip).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Equipamento do Jogador Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento do Jogador não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                PlayerEquip playerEquip = await _context.PlayerEquips.FirstAsync(pe => pe.Id == id);

                _context.PlayerEquips.Remove(playerEquip);
                await _context.SaveChangesAsync();
                return Ok("Equipamento do Jogador Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento do Jogador não encontrada");
            }
        }
    }
}
