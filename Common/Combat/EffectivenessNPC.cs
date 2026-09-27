using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// The floating text shown above an enemy when a hit's affinity is worth calling out.
    /// Normal stays quiet on purpose - only Effective/Resist/Immune say anything, matching
    /// the Combat.* entries in the .hjson file.
    /// </summary>
    public class EffectivenessNpc : GlobalNPC
    {
        private static LocalizedText _effective = null!;
        private static LocalizedText _resist = null!;
        private static LocalizedText _immune = null!;

        internal static void LoadStaticDefaults(Mod mod)
        {
            _effective = mod.GetLocalization("Combat.Effective");
            _resist = mod.GetLocalization("Combat.Resist");
            _immune = mod.GetLocalization("Combat.Immune");
        }

        public override bool InstancePerEntity =>  true; // Each NPC has it's own cooldown

        /// <summary>
        /// 60 ticks = 1 second. Long enough to avoid spam, short enough that it still feels responsive.
        /// </summary>
        private const int CooldownTicks = 45;

        /// <summary>
        /// How far above the normal damage numbers the text appears (pixels), so they don't overlap.
        /// </summary>
        private const int VerticalOffset = 30;

        private uint lastShownTick;
        private Affinity lastShownAffinity; // Starts as Normal, which is never shown, so the first hit always shows.

        /// <summary>
        /// Shows the text for this hit if it is allowed to (config on, not spamming).
        /// </summary>
        /// <remarks>
        /// Normal is never shown.
        /// Call from the attacking player's client only.
        /// </remarks>
        public void TryShow(NPC npc, Affinity affinity)
        {
            if (!ModContent.GetInstance<ClientConfig>().ShowAffinityText)
            {
                return;
            }

            if (affinity == Affinity.Normal)
            {
                return;
            }

            bool repeat = affinity == lastShownAffinity;
            if (repeat && Main.GameUpdateCount - lastShownTick < CooldownTicks)
            {
                return;
            }

            lastShownTick = Main.GameUpdateCount;
            lastShownAffinity = affinity;

            (LocalizedText? text, Color color) = affinity switch
            {
                Affinity.Vulnerable => (_effective, Color.OrangeRed),
                Affinity.Resistant => (_resist, Color.SkyBlue),
                Affinity.Immune => (_immune, Color.Gray),
                _ => (null, Color.White), // Normal: nothing worth announcing
            };

            if (text is null)
            {
                return;
            }

            // Combat text spawns relative to a rectangle. Shift it up so it doesn't sit on the damage number.
            Rectangle area = npc.Hitbox;
            area.Y -= VerticalOffset;

            CombatText.NewText(area, color, text.Value);
        }
    }
}