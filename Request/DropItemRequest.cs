using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class DropItemRequest
    {
        public int IdItem { get; set; }
        public int IdDrop { get; set; }
        public float ChanceDrop { get; set; }
        public bool IsBoss { get; set; }
    }
}
