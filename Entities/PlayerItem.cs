namespace Evolve_Game.Entities
{
    public class PlayerItem
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdItem { get; set; }

        public Item Item { get; set; }
        public int Amount { get; set; }
        public bool IsBackPack { get; set; }
    }
}
