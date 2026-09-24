namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// How an NPC reacts to one attack property. <see cref="Normal"/> MUST stay 0:
    /// zero-initialized arrays are then "everything normal" for free.
    /// </summary>
    public enum Affinity : byte
    {
        Normal = 0,
        Vulnerable,
        Resistant,
        Immune, // use sparingly
    }

    public static class AffinityExtensions
    {
        // The single place where "how strong is a weakness" lives.
        // Later this can be fed from a ModConfig without touching any other code.
        public const float VulnerableMultiplier = 1.5f;
        public const float ResistantMultiplier = 0.65f;
        public const float ImmuneMultiplier = 0f; // maybe raise to ~0.1f if too annoying

        public static float ToMultiplier(this Affinity affinity) => affinity switch
        {
            Affinity.Vulnerable => VulnerableMultiplier,
            Affinity.Resistant => ResistantMultiplier,
            Affinity.Immune => ImmuneMultiplier,
            _ => 1f,
        };
    }
}
