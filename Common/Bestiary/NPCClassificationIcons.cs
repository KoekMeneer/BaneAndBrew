using BaneAndBrew.Common.Families;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;

namespace BaneAndBrew.Common.Bestiary
{
    /// <summary>
    /// Optional icons for each NPCIdentity/NPCAlignment, shown next to the text line in the Bestiary.
    /// </summary>
    /// TODO: Add icons!!! ( in the future )
    public static class NPCClassificationIcons
    {
        private static readonly Dictionary<NPCIdentity, Asset<Texture2D>> _identityIcons = new();
        private static readonly Dictionary<NPCAlignment, Asset<Texture2D>> _alignmentIcons = new();

        public static void Register(NPCIdentity identity, Asset<Texture2D> icon) => _identityIcons[identity] = icon;

        public static void Register(NPCAlignment alignment, Asset<Texture2D> icon) => _alignmentIcons[alignment] = icon;

        public static Asset<Texture2D>? Get(NPCIdentity identity)
            => _identityIcons.TryGetValue(identity, out var icon) ? icon : null;

        public static Asset<Texture2D>? Get(NPCAlignment alignment)
            => _alignmentIcons.TryGetValue(alignment, out var icon) ? icon : null;

        internal static void Unload()
        {
            _identityIcons.Clear();
            _alignmentIcons.Clear();
        }
    }
}