using System;
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

        // Equality is by Id (case-insensitive), not by reference: this is what makes it safe
        // to use AttackProperty as a Dictionary key while still matching the "unique
        // case-insensitive id" contract documented above, even if two different instances
        // somehow ended up sharing an id.
        public bool Equals(AttackProperty? other)
            => other is not null && string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase);

        public override bool Equals(object? obj) => Equals(obj as AttackProperty);

        public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Id);

        public static bool operator ==(AttackProperty? left, AttackProperty? right) => Equals(left, right);

        public static bool operator !=(AttackProperty? left, AttackProperty? right) => !Equals(left, right);
    }
}
