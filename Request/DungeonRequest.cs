using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class DungeonRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdMap { get; set; }
        public int PosMax { get; set; }

    }
}
