namespace Evolve_Game.Entities
{
    public class PlayerEquip
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdEquip {  get; set; }
        public Equip Equip { get; set; }
        public int Life { get; set; }
        public int Magicula{ get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicDamage{ get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public float SpeedAttack { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }

        public bool IsBackPack { get; set; }

    }
}
