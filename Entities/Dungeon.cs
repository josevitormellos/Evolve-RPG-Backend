namespace Evolve_Game.Entities
{
    public class Dungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        public int IdMap { get; set; }
        public int PosMax { get; set; }

        public List<DungeonMonster> dungeonMonsters { get; set; }
        public List<DungeonChest> dungeonChest { get; set;}
    }
}
