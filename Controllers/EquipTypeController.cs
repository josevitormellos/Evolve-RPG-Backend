using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EquipType")]
    [ApiController]
    public class EquipTypeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EquipTypeController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string Name)
        {
            EquipType equipType = new EquipType
            {
                Name = Name

            };
            _context.EquipTypes.Add(equipType);
            await _context.SaveChangesAsync();

            return Ok("Tipo de Equipamento Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EquipType>> Get(int id)
        {
            try
            {
                EquipType equipType = await _context.EquipTypes.FirstAsync(et => et.Id == id);

                return equipType;
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Equipamento não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EquipType>>> Gets()
        {

            var listEquipTypes = _context.EquipTypes.ToList();

            return listEquipTypes;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EquipType updateRequest)
        {
            try
            {
                EquipType equipType = await _context.EquipTypes.FirstAsync(ae => ae.Id == updateRequest.Id);

                equipType.Name = updateRequest.Name ?? equipType.Name;


                _context.Entry(equipType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Tipo de Equipamento Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Equipamento não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EquipType equipType = await _context.EquipTypes.FirstAsync(ae => ae.Id == id);

                _context.EquipTypes.Remove(equipType);
                await _context.SaveChangesAsync();
                return Ok("Tipo de Equipamento Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Tipo de Equipamento não encontrada");
            }
        }
    }
}
