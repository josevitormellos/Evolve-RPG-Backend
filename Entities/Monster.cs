namespace Evolve_Game.Entities
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Life { get; set; }
        public int Magicola { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicDamage { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public float SpeedAttack { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }

        public float SpecialFire { get; set; }
        public float SpecialWater { get; set; }
        public float SpecialLight { get; set; }
        public float SpecialShadow { get; set; }
        public float SpecialFairy { get; set; }

        public float DefenseFire { get; set; }
        public float DefenseWater { get; set; }
        public float DefenseLight { get; set; }
        public float DefenseShadow { get; set; }
        public float DefenseFairy { get; set; }

        public int Skin {  get; set; }
        public int XpKill { get; set; }
        public int GoldKill { get; set; }

        public float ScaleSize {  get; set; }
        public bool PosRotation { get; set; }

        public int IdSpecie {  get; set; }
        public Specie Specie { get; set; }
        public int IdRarity { get; set; }
        public Rarity Rarity {  get; set; }

        public int IdDrop { get; set; }
        public Drop Drop { get; set; }
        public int IdEffectsConection { get; set; }
        public EffectsConection EffectsConection { get; set; }
        
    }
}
