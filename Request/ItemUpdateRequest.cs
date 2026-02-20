namespace Evolve_Game.Request
{
    public class ItemUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Icon { get; set; }
        public string Description { get; set; }

        public bool IsConsumable { get; set; }
        public int Gold { get; set; }

        public int IdRarity { get; set; }
    }
}
