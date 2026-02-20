namespace Evolve_Game.Entities
{
    public class DropItem
    {
        public int Id { get; set; }
        public int IdItem { get; set; }
        public Item Item { get; set; }
        public int IdDrop { get; set; }
        public Drop Drop { get; set; }
        public float ChanceDrop { get; set; }
        public bool IsBoss { get; set; }
    }
}
