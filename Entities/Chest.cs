namespace Evolve_Game.Entities
{
    public class Chest
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int IdIcon {  get; set; }
        public int IdDrop { get; set; }
        public Drop Drop {  get; set; }
        
    }
}
