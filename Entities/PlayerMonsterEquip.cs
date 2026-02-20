namespace Evolve_Game.Entities
{
    public class PlayerMonsterEquip
    {
        public int Id { get; set; }
        public int IdPlayerMonster {  get; set; }

        public PlayerMonster PlayerMonster { get; set; }
        public int IdPlayerEquip {  get; set; }
        public PlayerEquip PlayerEquip { get; set; }
        
    }
}
