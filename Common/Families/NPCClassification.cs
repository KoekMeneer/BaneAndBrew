namespace BaneAndBrew.Common.Families
{
    /// <summary>
    /// Specifies the type of the NPC.
    /// </summary>
    public enum NPCIdentity : byte
    {
        None,
        Slime,
        Undead,
        Spirit,
        Demon,
        Beast,
        Humanoid,
        Insect,
        Plant,
        Aquatic,
        Construct,
        Eldritch,
    }

    /// <summary>
    /// Specifies the alignment of the NPC.
    /// </summary>
    public enum NPCAlignment : byte
    {
        None,
        Infernal,
        Frigid,
        Storm,
        Corrupted,
        Hallowed,
    }

    public readonly record struct NPCClassification(
        NPCIdentity Identity,
        NPCAlignment Alignment = NPCAlignment.None
    );
}
