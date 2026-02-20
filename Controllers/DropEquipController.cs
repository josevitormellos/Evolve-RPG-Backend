using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/DropEquip")]
    [ApiController]
    public class DropEquipController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DropEquipController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(DropEquipRequest request)
        {
            DropEquip dropEquip = new DropEquip
            {
                IdEquip = request.IdEquip,
                IdDrop = request.IdDrop,
                ChanceDrop = request.ChanceDrop,
                IsBoss = request.IsBoss

            };
            _context.DropEquips.Add(dropEquip);
            await _context.SaveChangesAsync();

            return Ok("Drop de Equipamento Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<DropEquip>> Get(int idDrop, int idEquip)
        {
            try
            {
                DropEquip dropEquip = await _context.DropEquips.FirstAsync(de => de.IdDrop == idDrop && de.IdEquip == idEquip);

                return dropEquip;
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Equipamento não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<DropEquip>>> Gets()
        {

            var listDropEquip = _context.DropEquips.ToList();

            return listDropEquip;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DropEquipRequest updateRequest)
        {
            try
            {
                DropEquip dropEquip = await _context.DropEquips.FirstAsync(de => de.IdDrop == updateRequest.IdDrop && de.IdEquip == updateRequest.IdEquip);

                dropEquip.ChanceDrop = updateRequest.ChanceDrop;
                dropEquip.IsBoss = updateRequest.IsBoss;


                _context.Entry(dropEquip).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Drop de Equipamento Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Equipamento não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DropEquip dropEquip = await _context.DropEquips.FirstAsync(de => de.Id == id);

                _context.DropEquips.Remove(dropEquip);
                await _context.SaveChangesAsync();
                return Ok("Drop de Equipamento Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Drop de Equipamento não encontrada");
            }
        }
    }
}
