using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class DungeonChestRequest
    {
        public int IdDungeon { get; set; }
        public int IdChest { get; set; }
        public float ChanceApper { get; set; }
    }
}
