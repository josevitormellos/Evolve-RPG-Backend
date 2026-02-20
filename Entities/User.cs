namespace Evolve_Game.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Gold { get; set; }

        public int IdDungeon { get; set; }
        public Dungeon Dungeon { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public DateTime DateUpdate { get; set; }
        public List<PlayerMonster> PlayerMonsters { get; set; }
        public List<PlayerItem > PlayerItems { get; set; }
        public List<PlayerEquip> PlayerEquips { get; set; }
    }
}
