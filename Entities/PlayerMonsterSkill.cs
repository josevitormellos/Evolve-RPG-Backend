namespace Evolve_Game.Entities
{
    public class PlayerMonsterSkill
    {
        public int Id { get; set; }
        public int IdPlayerMonster {  get; set; }
        public PlayerMonster PlayerMonster { get; set; }
        public int IdSkill { get; set; }

        public Skill Skill { get; set; }
    }
}
