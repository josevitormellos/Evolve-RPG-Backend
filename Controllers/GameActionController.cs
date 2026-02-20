using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Migrations;
using Evolve_Game.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Controllers
{
    [Route("api/GameAction")]
    [ApiController]
    public class GameActionController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GameActionController(ApiDbContext context) { _context = context; }

        //Separar o Update em 3 pedaços, pois batalha, antes da batalha e virada de dungeon.
        [HttpPut("updateDungeon")]
        public async Task<IActionResult> UpdateDungeon(UserDungeonUpdateRequest updateRequest)
        {
            try
            {

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.IdDungeon = updateRequest.IdDungeon;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Posição da Dungeon Salva Usuario Alterados com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        [HttpPut("updateBaseDungeon")]
        public async Task<IActionResult> UpdateBaseDungeon(UserDungeonUpdateRequest updateRequest)
        {
            try
            {

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.IdDungeon = updateRequest.IdDungeon;
                user.PosX = updateRequest.PosX;
                user.PosY = updateRequest.PosY;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Posição da Dungeon Salva Usuario Alterados com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }


        [HttpPut("updateEntryBattler")]
        public async Task<IActionResult> UpdateInitBattler(UserDungeonUpdateRequest updateRequest)
        {
            try
            {

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.PosX = updateRequest.PosX;
                user.PosY = updateRequest.PosY;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Dados do Localização do Usuario Alterados com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        
        [HttpPut("updateFinishBattler")]
        public async Task<IActionResult> UpdateFinishBattler(UserFinishBattlerRequest updateRequest)
        {
            try
            {

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.PosX = updateRequest.PosX;
                user.PosY = updateRequest.PosY;
                user.Gold = updateRequest.Gold;

                PlayerMonster pm = await _context.PlayerMonsters.FirstAsync(p => p.Id == updateRequest.IdPlayerMonster);
                pm.Xp = updateRequest.Xp;
                pm.Level = updateRequest.Level;

                _context.Entry(user).State = EntityState.Modified;
                _context.Entry(pm).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Dados de final de batalha alterados com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        [HttpPut("sellItem")]
        public async Task<IActionResult> SellItem(SellItemRequest updateRequest)
        {
            try
            {

                PlayerItem item = await _context.PlayerItems.FirstAsync(pi => pi.IdUser == updateRequest.IdUser && pi.IdItem == updateRequest.IdItem);
                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.Gold += updateRequest.Gold;
                _context.Users.Update(user);

                if(item.Amount == 1)
                {
                    _context.PlayerItems.Remove(item);
                    _context.Entry(item).State = EntityState.Deleted;
                }
                else
                {
                    item.Amount--;
                    _context.PlayerItems.Update(item);
                    _context.Entry(item).State = EntityState.Modified;

                }

                _context.Entry(user).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
                return Ok("Venda fo Item feita com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        [HttpPut("sellEquip")]
        public async Task<IActionResult> SellEquip(SellEquipRequest updateRequest)
        {
            try
            {

                PlayerEquip equip = await _context.PlayerEquips.FirstAsync(pe => pe.IdUser == updateRequest.IdUser && pe.IdEquip == updateRequest.IdEquip);
                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.Gold += updateRequest.Gold;
                _context.Users.Update(user);

                
                    _context.PlayerEquips.Remove(equip);
                    _context.Entry(equip).State = EntityState.Deleted;
               
           

                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok("Venda do Equipamento feita com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }
        [HttpPut("registerDropEquip")]
        public async Task<IActionResult> RegisterDropEquip(SellEquipRequest updateRequest)
        {
            try
            {
                System.Random rnd = new System.Random();
                Equip equip = await _context.Equips.FirstAsync(pe => pe.Id == updateRequest.IdEquip);
                int life = rnd.Next(equip.LifeMin, equip.LifeMax + 1);
                int magicula = rnd.Next(equip.MagicolaMin, equip.MagicolaMax + 1);
                int physicalDamage = rnd.Next(equip.PhysicalDamageMin, equip.PhysicalDamageMax + 1);
                int magicDamage = rnd.Next(equip.MagicDamageMin, equip.MagicDamageMax + 1);
                int physicalDefense = rnd.Next(equip.PhysicalDefenseMin, equip.PhysicalDefenseMax + 1);
                int magicDefense = rnd.Next(equip.MagicDefenseMin, equip.MagicDefenseMax + 1);
                float speedAttack = (float)(rnd.NextDouble() * (equip.SpeedAttackMax - equip.SpeedAttackMin) + equip.SpeedAttackMin);
                float criticalChance = (float)(rnd.NextDouble() * (equip.CriticalChanceMax - equip.CriticalChanceMin) + equip.CriticalChanceMin);
                float criticalDamage = (float)(rnd.NextDouble() * (equip.CriticalDamageMax - equip.CriticalDamageMin) + equip.CriticalDamageMin);
                int count = _context.PlayerEquips.Count(equip => equip.IsBackPack);
                bool isBackPack = false;
                if(count <= 15)
                {
                    isBackPack = true;
                }
                PlayerEquipRequest playerEquip = new PlayerEquipRequest()
                {
                    IdUser = updateRequest.IdUser,
                    IdEquip = updateRequest.IdEquip,
                    Life = life,
                    Magicula = magicula,
                    PhysicalDamage = physicalDamage,
                    MagicDamage = magicDamage,
                    PhysicalDefense = physicalDefense,
                    MagicDefense = magicDefense,
                    SpeedAttack = speedAttack,
                    CriticalChance = criticalChance,
                    CriticalDamage = criticalDamage,
                    IsBackPack = isBackPack
                };
                PlayerEquipController pec = new PlayerEquipController(_context);
                await pec.Register(playerEquip);

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.Gold += updateRequest.Gold;
                _context.Users.Update(user);
                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok("Ganhou Equipamento feita com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        [HttpPut("registerDropItem")]
        public async Task<IActionResult> RegisterDropItem(SellItemRequest updateRequest)
        {
            try
            {
           
                PlayerItem? item = await _context.PlayerItems.FirstOrDefaultAsync(pe => pe.IdItem == updateRequest.IdItem);
                if(item != null)
                {
                    item.Amount++;
                    _context.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    int count = _context.PlayerItems.Count(equip => equip.IsBackPack);
                    bool isBackPack = false;
                    if (count <= 16)
                    {
                        isBackPack = true;
                    }
                    PlayerItemRequest playerItem = new PlayerItemRequest()
                    {
                        IdUser = updateRequest.IdUser,
                        IdItem = updateRequest.IdItem,
                        Amount = 1,
                        IsBackPack = isBackPack

                    };
                    PlayerItemController pec = new PlayerItemController(_context);
                    await pec.Register(playerItem);
                }

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.Gold += updateRequest.Gold;
                _context.Users.Update(user);
                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok("Ganhou Item feita com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

        [HttpPut("registerSellMonster")]
        public async Task<IActionResult> RegisterSellMonster(SellMonsterRequest updateRequest)
        {
            try
            {

                    PlayerMonsterRequest playerMonster = new PlayerMonsterRequest()
                    {
                        IdUser = updateRequest.IdUser,
                        IdMonster = updateRequest.IdMonster,
                        Level = updateRequest.Level

                    };
                    PlayerMonsterController pec = new PlayerMonsterController(_context);
                    await pec.Register(playerMonster);
                

                User user = await _context.Users.FirstAsync(u => u.Id == updateRequest.IdUser);
                user.Gold += updateRequest.Gold;
                _context.Users.Update(user);
                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok("Ganhou Monster feita com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }

    }
}
