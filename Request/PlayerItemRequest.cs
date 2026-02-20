namespace Evolve_Game.Request
{
    public class PlayerItemRequest
    {
        public int IdUser { get; set; }
        public int IdItem { get; set; }
        public int Amount { get; set; }
        public bool IsBackPack { get; set; }
    }
}
