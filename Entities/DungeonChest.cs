namespace Evolve_Game.Entities
{
    public class DungeonChest
    {
        public int Id { get; set; }
        public int IdDungeon { get; set; }
        public Dungeon Dungeon { get; set; }
        public int IdChest { get; set; }
        public Chest Chest { get; set; }    
        public float ChanceApper { get; set; }
    }
}
