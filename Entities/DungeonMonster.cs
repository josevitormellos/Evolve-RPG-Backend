namespace Evolve_Game.Entities
{
    public class DungeonMonster
    {
        public int Id { get; set; }
        public int IdDungeon { get; set; }
        public Dungeon Dungeon { get; set; }
        public int IdMonster { get; set; }
        public Monster Monster { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public bool IsBoss { get; set; }
    }
}
