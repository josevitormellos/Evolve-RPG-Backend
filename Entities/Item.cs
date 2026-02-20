namespace Evolve_Game.Entities
{
    public class Item
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int Icon { get; set; }
        public string Description { get; set; }

        public bool IsConsumable { get; set; }
        public int Gold { get; set; }

        public int IdRarity { get; set; }
        public Rarity Rarity { get; set; }

        public int IdEffectsConection { get; set; }
        public EffectsConection EffectsConection { get; set; }
    }
}
