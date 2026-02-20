using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Skill")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SkillController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(SkillRequest request)
        {
            var effectConection = new EffectsConectionController(_context);
            await effectConection.Register(request.Name);

            Skill skill = new Skill
            {
                Name = request.Name,
                Description = request.Description,
                IdIcon = request.IdIcon,
                IdAtributteElement = request.IdAtributteElement,
                IdEffectsConection = _context.EffectsConections.Max(effect => effect.Id),
                Time = request.Time

            };
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return Ok("Habilidade Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Skill>> Get(int id)
        {
            try
            {
                Skill skill = await _context.Skills.FirstAsync(s => s.Id == id);

                return skill;
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Skill>>> Gets()
        {

            var listSkills = _context.Skills.ToList();

            return listSkills;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(SkillUpdateRequest updateRequest)
        {
            try
            {
                Skill skill = await _context.Skills.FirstAsync(s => s.Id == updateRequest.Id);

                skill.Name = updateRequest.Name ?? skill.Name;
                skill.Description = updateRequest.Description ?? skill.Description;
                skill.IdIcon = updateRequest.IdIcon;
                skill.IdAtributteElement = updateRequest.IdAtributteElement;
                skill.IdEffectsConection = updateRequest.IdEffectsConection;
                skill.Time = updateRequest.Time;


                _context.Entry(skill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Habilidade Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Skill skill = await _context.Skills.FirstAsync(s => s.Id == id);

                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return Ok("Habilidade Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Habilidade não encontrada");
            }
        }
    }
}
