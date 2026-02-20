using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Evolve_Game.Validate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/Monster")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MonsterController(ApiDbContext context) {  _context = context; }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] MonsterRequest request)
        {
            var effectConection = new EffectsConectionController(_context);
            await effectConection.Register(request.Name);
            var drop = new DropController(_context);
            await drop.Register(request.Name);
            Monster monster = new Monster
            {
                Name = request.Name,
                Description = request.Description,
                Life = request.Life,
                Magicola = request.Magicola,
                PhysicalDamage = request.PhysicalDamage,
                MagicDamage = request.MagicDamage,
                PhysicalDefense = request.PhysicalDefense,
                MagicDefense =  request.MagicDefense,
                SpeedAttack = request.SpeedAttack,
                CriticalChance = request.CriticalChance,
                CriticalDamage = request.CriticalDamage,
                Skin = request.Skin,
                XpKill = request.XpKill,
                GoldKill = request.GoldKill,
                ScaleSize = request.ScaleSize,
                PosRotation = request.PosRotation,
                IdSpecie = request.IdSpecie,
                IdRarity = request.IdRarity,
                SpecialFire = request.SpecialFire,
                SpecialWater = request.SpecialWater,
                SpecialFairy = request.SpecialFairy,
                SpecialLight = request.SpecialLight,
                SpecialShadow = request.SpecialShadow,
                DefenseFairy = request.DefenseFairy,
                DefenseFire = request.DefenseFire,
                DefenseWater = request.DefenseWater,
                DefenseLight    = request.DefenseLight,
                DefenseShadow = request.DefenseShadow,
                IdDrop = _context.Drops.Max(drop => drop.Id),
                IdEffectsConection = _context.EffectsConections.Max(effect => effect.Id)
            };
            _context.Monsters.Add(monster);
            await _context.SaveChangesAsync();

            return Ok("Monstro Salvo com sucesso");
        }
        [HttpGet("view")]
        public async Task<ActionResult<Monster>> Get(int Id)
        {
            try{
                Monster monster = await _context.Monsters.FirstAsync(m => m.Id == Id);
                return monster;
            }
            catch (Exception ex)
            {
                return Ok("Erro ao Ver o monstro com Id " + Id.ToString());
            }

            
        }
        [HttpGet("views")]
        public async Task<ActionResult<List<Monster>>> Gets()
        {
            try
            {

                return _context.Monsters.ToList();
            }
            catch (Exception ex)
            {
                return Ok("Erro não encontrou lista de monstros ");
            }


        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(MonsterUpdateRequest updatedRequest)
        {

            // Procura o monstro no banco de dados
            var monster = await _context.Monsters.FindAsync(updatedRequest.Id);
            if (monster == null)
            {
                return NotFound($"Monstro com ID {updatedRequest.Id} não encontrado.");
            }

            // Atualiza os valores do monstro encontrado com os dados recebidos
            monster.Name = updatedRequest.Name;
            monster.Description = updatedRequest.Description;
            monster.Life = updatedRequest.Life;
            monster.Magicola = updatedRequest.Magicola;
            monster.PhysicalDamage = updatedRequest.PhysicalDamage;
            monster.MagicDamage = updatedRequest.MagicDamage;
            monster.PhysicalDefense = updatedRequest.PhysicalDefense;
            monster.MagicDefense = updatedRequest.MagicDefense;
            monster.SpeedAttack = updatedRequest.SpeedAttack;
            monster.CriticalChance = updatedRequest.CriticalChance;
            monster.CriticalDamage = updatedRequest.CriticalDamage;
            monster.SpecialFire = updatedRequest.SpecialFire;
            monster.SpecialWater = updatedRequest.SpecialWater;
            monster.SpecialLight = updatedRequest.SpecialLight;
            monster.SpecialShadow = updatedRequest.SpecialShadow;
            monster.SpecialFairy = updatedRequest.SpecialFairy;
            monster.DefenseFire = updatedRequest.DefenseFire;
            monster.DefenseWater = updatedRequest.DefenseWater;
            monster.DefenseLight = updatedRequest.DefenseLight;
            monster.DefenseShadow = updatedRequest.DefenseShadow;
            monster.DefenseFairy = updatedRequest.DefenseFairy;
            monster.Skin = updatedRequest.Skin;
            monster.XpKill = updatedRequest.XpKill;
            monster.GoldKill = updatedRequest.GoldKill;
            monster.ScaleSize = updatedRequest.ScaleSize;
            monster.PosRotation = updatedRequest.PosRotation;
            monster.IdSpecie = updatedRequest.IdSpecie;
            monster.IdRarity = updatedRequest.IdRarity;

            // Salva as mudanças no banco de dados
            _context.Entry(monster).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Retorna uma resposta indicando que a operação foi bem-sucedida
            return Ok("Monstro Atualizado com sucesso"); 
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {

            // Procura o monstro no banco de dados
            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound($"Monstro com ID {id} não encontrado.");
            }

            

            // Salva as mudanças no banco de dados
            _context.Monsters.Remove(monster);
            await _context.SaveChangesAsync();

            // Retorna uma resposta indicando que a operação foi bem-sucedida
            return Ok("Monstro Deletado com sucesso");
        }



    }
}
