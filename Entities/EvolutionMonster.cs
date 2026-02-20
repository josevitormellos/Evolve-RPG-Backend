namespace Evolve_Game.Entities
{
    public class EvolutionMonster
    {
        public int Id { get; set; }
        public int IdMonster { get; set; }
        public Monster Monster { get; set; }
        public int IdMonsterEvolution { get; set; }
        public Monster MonsterEvolution { get; set; }
        public int MinLevel { get; set; }
    }
}
