using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class DropEquipRequest
    {
        public int IdEquip { get; set; }
        public int IdDrop { get; set; }
        public float ChanceDrop { get; set; }
        public bool IsBoss { get; set; }
    }
}
