using Evolve_Game.Entities;

namespace Evolve_Game.Request
{
    public class EvolutionMonsterRequest
    {
        public int IdMonster { get; set; }
        
        public int IdEvolution { get; set; }
        public int MinLevel { get; set; }
    }
}
