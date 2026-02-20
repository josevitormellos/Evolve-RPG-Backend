using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class DungeonMonsterRequest
    {
        public int IdDungeon { get; set; }
        public int IdMonster { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public bool IsBoss { get; set; }
    }
}
