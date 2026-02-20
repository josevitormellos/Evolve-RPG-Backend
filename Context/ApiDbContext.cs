using Evolve_Game.Entities;
using Microsoft.EntityFrameworkCore;

namespace Evolve_Game.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<DungeonMonster> DungeonMonsters { get; set; }
        public DbSet<Equip> Equips { get; set; }
        public DbSet<EquipType> EquipTypes { get; set; }
        public DbSet<PlayerEvolutionMonster> PlayerEvolutionMonsters { get; set; }
        public DbSet<EvolutionMonster> EvolutionMonsters  { get; set; }
        public DbSet<EvolutionTerms> EvolutionTerms { get; set; }
        public DbSet<EvolutionType> EvolutionTypes { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<EffectList> EffectList{ get; set; }
        public DbSet<EffectsConection> EffectsConections { get; set; }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterSkill> MonsterSkills { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        public DbSet<PlayerEquip> PlayerEquips { get; set; }
        public DbSet<PlayerMonster> PlayerMonsters { get; set; }
        public DbSet<PlayerMonsterEquip> PlayerMonsterEquips { get; set; }
        public DbSet<PlayerMonsterSkill> PlayerMonsterSkills { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<AtributteElement> AtributteElements { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Specie> Species { get; set; }
        public DbSet<Drop> Drops { get; set; }
        public DbSet<DropEquip> DropEquips { get; set; }
        public DbSet<DropItem> DropItems { get; set; }
        public DbSet<Chest> Chests { get; set; }
        public DbSet<DungeonChest> DungeonChests { get; set; }

        public DbSet<Entities.Version> Versions { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dungeon
            modelBuilder.Entity<Dungeon>()
                .HasMany(d => d.dungeonMonsters) // Caso você queira que Dungeon tenha uma lista de monstros
                .WithOne()
                .HasForeignKey(dm => dm.IdDungeon)
                .OnDelete(DeleteBehavior.Cascade); // Ou outro comportamento, se necessário

            modelBuilder.Entity<DungeonChest>()
                 .HasOne(dc => dc.Dungeon)
                 .WithMany()
                 .HasForeignKey(dm => dm.IdDungeon)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DungeonChest>()
                 .HasOne(dc => dc.Chest)
                 .WithMany()
                 .HasForeignKey(dm => dm.IdChest)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Chest>()
                 .HasOne(c => c.Drop)
                 .WithMany()
                 .HasForeignKey(c => c.IdDrop)
                 .OnDelete(DeleteBehavior.Restrict);
            // DungeonMonster
            modelBuilder.Entity<DungeonMonster>()
                .HasOne(dm => dm.Dungeon)
                .WithMany()
                .HasForeignKey(dm => dm.IdDungeon)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DungeonMonster>()
                .HasOne(dm => dm.Monster)
                .WithMany()
                .HasForeignKey(dm => dm.IdMonster)
                .OnDelete(DeleteBehavior.Cascade);

            // Effect
            modelBuilder.Entity<EffectList>()
                .HasOne(ei => ei.Effect)
                .WithMany()
                .HasForeignKey(ei => ei.IdEffect)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EffectList>()
               .HasOne(ei => ei.EffectsConection)
               .WithMany()
               .HasForeignKey(ei => ei.IdEffectsConection)
               .OnDelete(DeleteBehavior.Restrict);

            
           

            //Item
            modelBuilder.Entity<Item>()
               .HasOne(i => i.Rarity)
               .WithMany()
               .HasForeignKey(i => i.IdRarity)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Item>()
                .HasOne(e => e.EffectsConection)
                .WithMany()
                .HasForeignKey(e => e.IdEffectsConection)
                .OnDelete(DeleteBehavior.Restrict);
            // Equip
            modelBuilder.Entity<Equip>()
                .HasOne(e => e.EquipType)
                .WithMany()
                .HasForeignKey(e => e.IdEquipType)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Equip>()
                .HasOne(e => e.Rarity)
                .WithMany()
                .HasForeignKey(e => e.IdRarity)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Equip>()
                .HasOne(e => e.EffectsConection)
                .WithMany()
                .HasForeignKey(e => e.IdEffectsConection)
                .OnDelete(DeleteBehavior.Restrict);


            //Drops
            modelBuilder.Entity<DropEquip>()
                .HasOne(e => e.Equip)
                .WithMany()
                .HasForeignKey(e => e.IdEquip)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DropEquip>()
                .HasOne(e => e.Drop)
                .WithMany()
                .HasForeignKey(e => e.IdDrop)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DropItem>()
                .HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.IdItem)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DropItem>()
                .HasOne(e => e.Drop)
                .WithMany()
                .HasForeignKey(e => e.IdDrop)
                .OnDelete(DeleteBehavior.Restrict);
            // EvolutionMonster
            modelBuilder.Entity<PlayerEvolutionMonster>()
                .HasOne(em => em.PlayerMonster)
                .WithMany()
                .HasForeignKey(em => em.IdPlayerMonster)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerEvolutionMonster>()
                .HasOne(em => em.EvolutionMonster)
                .WithMany()
                .HasForeignKey(em => em.IdEvolutionMonster)
                .OnDelete(DeleteBehavior.Restrict);

            // EvolutionMonster
            modelBuilder.Entity<EvolutionMonster>()
                .HasOne(em => em.Monster)
                .WithMany()
                .HasForeignKey(em => em.IdMonster)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvolutionMonster>()
                .HasOne(em => em.MonsterEvolution)
                .WithMany()
                .HasForeignKey(em => em.IdMonsterEvolution)
                .OnDelete(DeleteBehavior.Restrict);

            // EvolutionTerms
            modelBuilder.Entity<EvolutionTerms>()
                .HasOne(et => et.EvolutionType)
                .WithMany()
                .HasForeignKey(et => et.IdEvolutionType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvolutionTerms>()
               .HasOne(et => et.EvolutionMonster)
               .WithMany()
               .HasForeignKey(et => et.IdEvolutionMonster)
               .OnDelete(DeleteBehavior.Cascade);

            // MonsterSkill
            modelBuilder.Entity<MonsterSkill>()
                .HasOne(ms => ms.Monster)
                .WithMany()
                .HasForeignKey(ms => ms.IdMonster)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MonsterSkill>()
                .HasOne(ms => ms.Skill)
                .WithMany()
                .HasForeignKey(ms => ms.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            // PlayerItem
            modelBuilder.Entity<PlayerItem>()
                .HasOne(pi => pi.User)
                .WithMany()
                .HasForeignKey(pi => pi.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerItem>()
                .HasOne(pi => pi.Item)
                .WithMany()
                .HasForeignKey(pi => pi.IdItem)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerEquip>()
                .HasOne(pm => pm.User)
                .WithMany()
                .HasForeignKey(pm => pm.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlayerEquip>()
                .HasOne(pm => pm.Equip)
                .WithMany()
                .HasForeignKey(pm => pm.IdEquip)
                .OnDelete(DeleteBehavior.Cascade);
            // PlayerMonster
            modelBuilder.Entity<PlayerMonster>()
                .HasOne(pm => pm.User)
                .WithMany()
                .HasForeignKey(pm => pm.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerMonster>()
                .HasOne(pm => pm.Monster)
                .WithMany()
                .HasForeignKey(pm => pm.IdMonster)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerMonster>()
                .HasOne(pm => pm.Rarity)
                .WithMany()
                .HasForeignKey(pm => pm.IdRarity)
                .OnDelete(DeleteBehavior.Cascade);

            // PlayerMonsterEquip
            

            modelBuilder.Entity<PlayerMonsterEquip>()
                .HasOne(pme => pme.PlayerMonster)
                .WithMany()
                .HasForeignKey(pme => pme.IdPlayerMonster)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerMonsterEquip>()
                .HasOne(pme => pme.PlayerEquip)
                .WithMany()
                .HasForeignKey(pme => pme.IdPlayerEquip)
                .OnDelete(DeleteBehavior.Cascade);

            

            // PlayerMonsterSkill
            modelBuilder.Entity<PlayerMonsterSkill>()
                .HasOne(pms => pms.PlayerMonster)
                .WithMany()
                .HasForeignKey(pms => pms.IdPlayerMonster)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerMonsterSkill>()
                .HasOne(pms => pms.Skill)
                .WithMany()
                .HasForeignKey(pms => pms.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Monster>()
                .HasOne(m => m.Specie)
                .WithMany()
                .HasForeignKey(m => m.IdSpecie)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Monster>()
                .HasOne(m => m.Rarity)
                .WithMany()
                .HasForeignKey(m => m.IdRarity)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Monster>()
                .HasOne(e => e.EffectsConection)
                .WithMany()
                .HasForeignKey(e => e.IdEffectsConection)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Monster>()
                .HasOne(e => e.Drop)
                .WithMany()
                .HasForeignKey(e => e.IdDrop)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.AtributteElement)
                .WithMany()
                .HasForeignKey(s => s.IdAtributteElement)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Skill>()
                .HasOne(e => e.EffectsConection)
                .WithMany()
                .HasForeignKey(e => e.IdEffectsConection)
                .OnDelete(DeleteBehavior.Restrict);

            // User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Dungeon)
                .WithMany()
                .HasForeignKey(u => u.IdDungeon)
                .OnDelete(DeleteBehavior.SetNull); // Ou outro comportamento, conforme sua necessidade

            // PlayerMonster e User
            modelBuilder.Entity<PlayerMonster>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.PlayerMonsters) // Cada User pode ter vários PlayerMonsters
                .HasForeignKey(pm => pm.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            // PlayerItem e User
            modelBuilder.Entity<PlayerItem>()
                .HasOne(pi => pi.User)
                .WithMany(u => u.PlayerItems) // Cada User pode ter vários PlayerItems
                .HasForeignKey(pi => pi.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            // PlayerMonsterEquip e User
           
        }
    }
}

