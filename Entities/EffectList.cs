namespace Evolve_Game.Entities
{
    public class EffectList
    {
        public int Id { get; set; }
        public int IdEffect { get; set; }
        public Effect Effect { get; set; }
        public int IdEffectsConection { get; set; }
        public EffectsConection EffectsConection { get; set; }
    }
}
