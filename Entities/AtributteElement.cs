using System.ComponentModel.DataAnnotations;

namespace Evolve_Game.Entities
{
    public class AtributteElement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
