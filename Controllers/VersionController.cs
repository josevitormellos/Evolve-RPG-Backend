using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Version")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public VersionController(ApiDbContext context) { _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string versionCode)
        {
            Entities.Version version = new Entities.Version
            {
                VersionCode = versionCode

            };
            _context.Versions.Add(version);
            await _context.SaveChangesAsync();

            return Ok("Versão Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Entities.Version>> Get(int id)
        {
            try
            {
                Entities.Version version = await _context.Versions.FirstAsync(v => v.Id == id);

                return version;
            }
            catch (Exception ex)
            {
                return BadRequest("Versão não encontrada");
            }
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Entities.Version>>> Gets()
        {

            var listVersions = _context.Versions.ToList();

            return listVersions;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Entities.Version versionRequest)
        {
            try
            {
                Entities.Version version = await _context.Versions.FirstAsync(v => v.Id == versionRequest.Id);

                version.VersionCode = versionRequest.VersionCode ?? version.VersionCode;


                _context.Entry(version).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Versão Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Versão não encontrada");
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
                return Ok("Versão Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Versão    não encontrada");
            }
        }
    }
}
