namespace Evolve_Game.Entities
{
    public class Equip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdIcon { get; set; }
        public int LifeMin { get; set; }
        public int LifeMax { get; set; }
        public int MagicolaMin { get; set; }
        public int MagicolaMax { get; set; }
        public int PhysicalDamageMin { get; set; }
        public int PhysicalDamageMax { get; set; }
        public int MagicDamageMin { get; set; }
        public int MagicDamageMax { get; set; }
        public int PhysicalDefenseMin { get; set; }
        public int PhysicalDefenseMax { get; set; }
        public int MagicDefenseMin { get; set; }
        public int MagicDefenseMax { get; set; }
        public float SpeedAttackMin { get; set; }
        public float SpeedAttackMax { get; set; }
        public float CriticalChanceMin { get; set; }
        public float CriticalChanceMax { get; set; }
        public float CriticalDamageMin { get; set; }
        public float CriticalDamageMax { get; set; }

        public int Gold { get; set; }
        public int IdEquipType { get; set; }
        public EquipType EquipType { get; set; }

        public int IdRarity { get; set; }
        public Rarity Rarity { get; set; }
        public int IdEffectsConection { get; set; }
        public EffectsConection EffectsConection { get; set; }
    }
}
