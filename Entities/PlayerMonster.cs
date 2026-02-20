using System.ComponentModel.DataAnnotations;

namespace Evolve_Game.Entities
{
    public class PlayerMonster
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdMonster { get; set; }
        public Monster Monster { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int IdRarity { get; set; }
        public Rarity Rarity { get; set; }

        [Range(1, 100)]
        public int ColorMagicGreen { get; set;}
        [Range(1, 100)]
        public int ColorMagicBlue { get; set;}
        [Range(1, 100)]
        public int ColorMagicRed { get; set;}
        [Range(1, 100)]
        public int ColorMagicBlack { get; set;}
        [Range(1, 100)]
        public int ColorMagicWhite { get; set;}
        [Range(1, 100)]
        public int ColorMagicPink { get; set;}
        [Range(1, 100)]
        public int ColorMagicPurple { get; set;}
    }
}
