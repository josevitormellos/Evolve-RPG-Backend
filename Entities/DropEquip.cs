namespace Evolve_Game.Entities
{
    public class DropEquip
    {
        public int Id { get; set; }
        public int IdEquip { get; set; }
        public Equip Equip { get; set; }
        public int IdDrop { get; set; }
        public Drop Drop { get; set; }
        public float ChanceDrop { get; set; }
        public bool IsBoss { get; set; }
    }
}
