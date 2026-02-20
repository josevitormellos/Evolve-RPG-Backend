using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Equip")]
    [ApiController]
    public class EquipController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EquipController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(EquipRequest request)
        {
            var effectConection = new EffectsConectionController(_context);
            await effectConection.Register(request.Name);
            Equip equip = new Equip
            {
                Name = request.Name,
                Description = request.Description,
                IdIcon = request.IdIcon,
                LifeMin = request.LifeMin,
                LifeMax = request.LifeMax,
                MagicolaMin = request.MagicolaMin,
                MagicolaMax = request.MagicolaMax,
                PhysicalDamageMin = request.PhysicalDamageMin,
                PhysicalDamageMax = request.PhysicalDamageMax,
                MagicDamageMin = request.MagicDamageMin,
                MagicDamageMax = request.MagicDamageMax,
                PhysicalDefenseMin = request.PhysicalDefenseMin,
                PhysicalDefenseMax = request.PhysicalDefenseMax,
                MagicDefenseMin = request.MagicDefenseMin,
                MagicDefenseMax = request.MagicDefenseMax,
                SpeedAttackMin = request.SpeedAttackMin,
                SpeedAttackMax = request.SpeedAttackMax,
                CriticalChanceMin = request.CriticalChanceMin,
                CriticalChanceMax = request.CriticalChanceMax,
                CriticalDamageMin = request.CriticalDamageMin,
                CriticalDamageMax = request.CriticalDamageMax,
                Gold = request.Gold,
                IdEquipType = request.IdEquipType,
                IdRarity = request.IdRarity,
                IdEffectsConection = _context.EffectsConections.Max(effect => effect.Id)

            };
            _context.Equips.Add(equip);
            await _context.SaveChangesAsync();

            return Ok("Equipamento Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Equip>> Get(int id)
        {
            try
            {
                Equip equip = await _context.Equips.FirstAsync(e => e.Id == id);

                return equip;
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Equip>>> Gets()
        {

            var listEquips = _context.Equips.ToList();

            return listEquips;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EquipUpdateRequest updateRequest)
        {
            try
            {
                Equip equip = await _context.Equips.FirstAsync(e => e.Id == updateRequest.Id);

                equip.Name = updateRequest.Name;
                equip.Description = updateRequest.Description;
                equip.IdIcon = updateRequest.IdIcon;
                equip.LifeMin = updateRequest.LifeMin;
                equip.LifeMax = updateRequest.LifeMax;
                equip.MagicolaMin = updateRequest.MagicolaMin;
                equip.MagicolaMax = updateRequest.MagicolaMax;
                equip.PhysicalDamageMin = updateRequest.PhysicalDamageMin;
                equip.PhysicalDamageMax = updateRequest.PhysicalDamageMax;
                equip.MagicDamageMin = updateRequest.MagicDamageMin;
                equip.MagicDamageMax = updateRequest.MagicDamageMax;
                equip.PhysicalDefenseMin = updateRequest.PhysicalDefenseMin;
                equip.PhysicalDefenseMax = updateRequest.PhysicalDefenseMax;
                equip.MagicDefenseMin = updateRequest.MagicDefenseMin;
                equip.MagicDefenseMax = updateRequest.MagicDefenseMax;
                equip.SpeedAttackMin = updateRequest.SpeedAttackMin;
                equip.SpeedAttackMax = updateRequest.SpeedAttackMax;
                equip.CriticalChanceMin = updateRequest.CriticalChanceMin;
                equip.CriticalChanceMax = updateRequest.CriticalChanceMax;
                equip.CriticalDamageMin = updateRequest.CriticalDamageMin;
                equip.CriticalDamageMax = updateRequest.CriticalDamageMax;
                equip.Gold= updateRequest.Gold;
                equip.IdEquipType = updateRequest.IdEquipType;
                equip.IdRarity = updateRequest.IdRarity;
                equip.IdEffectsConection = updateRequest.IdEffectsConection;



                _context.Entry(equip).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Equipamento Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Equip equip = await _context.Equips.FirstAsync(e => e.Id == id);

                _context.Equips.Remove(equip);
                await _context.SaveChangesAsync();
                return Ok("Equipamento Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Equipamento não encontrada");
            }
        }
    }
}
