using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Atributte")]
    [ApiController]
    public class AtributteController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AtributteController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string Name)
        {
            AtributteElement atributte = new AtributteElement
            {
                Name = Name

            };
            _context.AtributteElements.Add(atributte);
            await _context.SaveChangesAsync();

            return Ok("Atributo Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<AtributteElement>> Get(int id)
        {
            try
            {
                AtributteElement atributto = await _context.AtributteElements.FirstAsync(ae => ae.Id == id);

                return atributto;
            }
            catch (Exception ex)
            {
                return BadRequest("Atributo não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<AtributteElement>>> Gets()
        {

            var listAtributte = _context.AtributteElements.ToList();

            return listAtributte;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AtributteElement updateRequest)
        {
            try
            {
                AtributteElement atributo = await _context.AtributteElements.FirstAsync(ae => ae.Id == updateRequest.Id);

                atributo.Name = updateRequest.Name ?? atributo.Name;


                _context.Entry(atributo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Atributo Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Atributo não encontrada");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                AtributteElement atributte = await _context.AtributteElements.FirstAsync(ae => ae.Id == id);

                _context.AtributteElements.Remove(atributte);
                await _context.SaveChangesAsync();
                return Ok("Atributo Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Atributo não encontrada");
            }
        }
    }
}
