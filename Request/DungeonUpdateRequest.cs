namespace Evolve_Game.Request
{
    public class DungeonUpdateRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }


        public int IdMap { get; set; }
        public int PosMax { get; set; }
    }
}
