namespace Evolve_Game.Entities
{
    public class MonsterSkill
    {
        public int Id { get; set; }
        public int IdMonster { get; set; }
        public Monster Monster { get; set; }
        public int IdSkill { get; set; }
        public Skill Skill { get; set; }

        public int Level { get; set; }
    }
}
