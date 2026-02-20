namespace Evolve_Game.Request
{
    public class PlayerEquipRequest
    {
        public int IdUser { get; set; }
        public int IdEquip { get; set; }
        public int Life { get; set; }
        public int Magicula { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicDamage { get; set; }

        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public float SpeedAttack { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalDamage { get; set; }
        public bool IsBackPack { get; set; }
    }
}
