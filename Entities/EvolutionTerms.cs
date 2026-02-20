namespace Evolve_Game.Entities
{
    public class EvolutionTerms
    {
        public int Id { get; set; }
        public int IdEvolutionType { get; set; }
        public EvolutionType EvolutionType { get; set; }

        public int IdEvolutionMonster { get; set; }
        public EvolutionMonster EvolutionMonster {  get; set; }

        public int Amount { get; set; }
    }
}
