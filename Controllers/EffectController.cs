using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Effect")]
    [ApiController]
    public class EffectController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EffectController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(EffectRequest request)
        {
            Effect effect = new Effect
            {
                Name = request.Name,
                EffectActive = request.EffectActive,
                IsEffectContinue = request.IsEffectContinue,
                IsEffectPlayer = request.IsEffectPlayer,
                IsEffectAttackContinue = request.IsEffectAttackContinue,
                IsEffectDamageContinue = request.IsEffectDamageContinue,
                TimeEffectContinue = request.TimeEffectContinue

            };
            _context.Effects.Add(effect);
            await _context.SaveChangesAsync();

            return Ok("Efeito Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Effect>> Get(int id)
        {
            try
            {
                Effect effect = await _context.Effects.FirstAsync(e => e.Id == id);

                return effect;
            }
            catch (Exception ex)
            {
                return BadRequest("Efeito não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Effect>>> Gets()
        {

            var listEffects = _context.Effects.ToList();

            return listEffects;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Effect updateRequest)
        {
            try
            {
                Effect effect = await _context.Effects.FirstAsync(e => e.Id == updateRequest.Id);

                effect.Name = updateRequest.Name ?? effect.Name;
                effect.EffectActive = updateRequest.EffectActive;
                effect.IsEffectContinue = updateRequest.IsEffectContinue;
                effect.IsEffectPlayer = updateRequest.IsEffectPlayer;
                effect.IsEffectDamageContinue = updateRequest.IsEffectDamageContinue;
                effect.IsEffectAttackContinue = updateRequest.IsEffectAttackContinue;
                effect.TimeEffectContinue = updateRequest.TimeEffectContinue;


                _context.Entry(effect).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Efeito Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Efeito não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Effect effect = await _context.Effects.FirstAsync(e => e.Id == id);

                _context.Effects.Remove(effect);
                await _context.SaveChangesAsync();
                return Ok("Efeito Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Efeito não encontrada");
            }
        }
    }
}
