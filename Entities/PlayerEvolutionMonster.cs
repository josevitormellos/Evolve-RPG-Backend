namespace Evolve_Game.Entities
{
    public class PlayerEvolutionMonster
    {
        public int Id { get; set; }
        public int IdPlayerMonster {  get; set; }
        public PlayerMonster PlayerMonster { get; set; }

        public int IdEvolutionMonster { get; set; }
        public EvolutionMonster EvolutionMonster { get; set; }
    }
}
