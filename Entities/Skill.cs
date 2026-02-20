namespace Evolve_Game.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdIcon {  get; set; }

        public int IdAtributteElement { get; set; }
        public AtributteElement AtributteElement { get; set; }

        public int IdEffectsConection { get; set; }
        public EffectsConection EffectsConection { get; set; }
        public int Time {  get; set; }

    }
}
