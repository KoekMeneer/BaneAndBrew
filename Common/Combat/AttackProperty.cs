using Terraria.Localization;

namespace BaneAndBrew.Common.Combat
{
    public class AttackProperty
    {
        /// <summary>
        /// Unique case-insensitive id of the property.
        /// 
        /// Built-ins are plain (e.g. "Fire").
        /// Other mods should prefix theirs to avoid clashes (e.g. "MyMod/Void").
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Name for the player to read (Bestiary, tooltips). Localized when a name was supplied, otherwise
        /// the plain <see cref="Id"/>, so a property registered without a name still displays something sensible.
        /// </summary>
        public string DisplayName => Name?.Value ?? Id;
        internal LocalizedText? Name { get; set; }

        internal AttackProperty(string id)
        {
            Id = id;
        }

        public override string ToString() => Id;
    }
}
