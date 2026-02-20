using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/EffectList")]
    [ApiController]
    public class EffectListController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EffectListController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(EffectListRequest request)
        {
            EffectList effectList = new EffectList
            {
                IdEffect = request.IdEffect,
                IdEffectsConection = request.IdEffectsConection

            };
            _context.EffectList.Add(effectList);
            await _context.SaveChangesAsync();

            return Ok("Lista de Efeitos Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<EffectList>> Get(int idEffect, int idEffectsConection)
        {
            try
            {
                EffectList effectList = await _context.EffectList.FirstAsync(el => el.IdEffect == idEffect && el.IdEffectsConection == idEffectsConection);

                return effectList;
            }
            catch (Exception ex)
            {
                return BadRequest("Lista de Efeitos não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<EffectList>>> Gets()
        {

            var listEffectList = _context.EffectList.ToList();

            return listEffectList;
        }

        
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(EffectListRequest deleteRequest)
        {
            try
            {
                EffectList effectList = await _context.EffectList.FirstAsync(el => el.IdEffect == deleteRequest.IdEffect && el.IdEffectsConection == deleteRequest.IdEffectsConection);

                _context.EffectList.Remove(effectList);
                await _context.SaveChangesAsync();
                return Ok("Lista de Efeito Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Lista de Efeito não encontrada");
            }
        }
    }
}
