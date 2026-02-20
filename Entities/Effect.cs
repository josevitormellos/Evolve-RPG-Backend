namespace Evolve_Game.Entities
{
    public class Effect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EffectActive { get; set; }

        public bool IsEffectContinue {  get; set; }
        public int TimeEffectContinue { get; set; }
        public bool IsEffectPlayer { get; set; }
        public bool IsEffectAttackContinue { get; set; }
        public bool IsEffectDamageContinue {  get; set; }
    }
}
