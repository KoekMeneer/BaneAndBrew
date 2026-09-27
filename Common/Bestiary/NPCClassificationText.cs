using BaneAndBrew.Common.Families;
using System;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Bestiary
{
    /// <summary>
    /// Localized, player-facing text for NPCIdentity and NPCAlignment - used by the Bestiary
    /// entry, and anywhere else a classification needs to be shown to the player.
    /// </summary>
    public static class NPCClassificationText
    {
        private static readonly Dictionary<NPCIdentity, LocalizedText> _identityNames = new();
        private static readonly Dictionary<NPCAlignment, LocalizedText> _alignmentNames = new();

        private static LocalizedText _familyLine = null!;
        private static LocalizedText _alignmentLine = null!;

        /// <summary>
        /// Called once from InitializationSystem.SetStaticDefaults.
        /// </summary>
        internal static void LoadStaticDefaults(Mod mod)
        {
            foreach (NPCIdentity identity in Enum.GetValues<NPCIdentity>())
            {
                if (identity == NPCIdentity.None)
                {
                    continue;
                }

                _identityNames[identity] = mod.GetLocalization($"Families.{identity}", () => identity.ToString());
            }

            foreach (NPCAlignment alignment in Enum.GetValues<NPCAlignment>())
            {
                if (alignment == NPCAlignment.None)
                {
                    continue;
                }

                _alignmentNames[alignment] = mod.GetLocalization($"Alignments.{alignment}", () => alignment.ToString());
            }

            _familyLine = mod.GetLocalization("Bestiary.Family");
            _alignmentLine = mod.GetLocalization("Bestiary.Alignment");
        }

        /// <summary>
        /// "Family: Undead" - or null for NPCIdentity.None, which nothing should ever show.
        /// </summary>
        public static string? FormatFamilyLine(NPCIdentity identity)
        {
            if (identity == NPCIdentity.None)
            {
                return null;
            }

            string name = _identityNames.TryGetValue(identity, out var text) ? text.Value : identity.ToString();
            return _familyLine.Format(name);
        }

        /// <summary>
        /// "Alignment: Corrupted" - or null for NPCAlignment.None, since most NPCs don't have one.
        /// </summary>
        public static string? FormatAlignmentLine(NPCAlignment alignment)
        {
            if (alignment == NPCAlignment.None)
            {
                return null;
            }

            string name = _alignmentNames.TryGetValue(alignment, out var text) ? text.Value : alignment.ToString();
            return _alignmentLine.Format(name);
        }
    }
}
