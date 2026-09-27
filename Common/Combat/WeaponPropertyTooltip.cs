using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Adds an "Attack type: X" tooltip line to weapons and ammo that carry an AttackProperty,
    /// so players can see why a hit was Effective/Resisted before they ever land one.
    /// </summary>
    public class WeaponPropertyTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!ModContent.GetInstance<ClientConfig>().ShowWeaponPropertyTooltip)
            {
                return;
            }

            AttackProperty[] properties = WeaponPropertyRegistry.Get(item.type);
            if (properties.Length == 0)
            {
                return; // ordinary physical item, nothing extra to say
            }

            string names = string.Join(", ", properties.Select(p => p.DisplayName));
            string text = Mod.GetLocalization("Tooltips.AttackProperties").Format(names);

            TooltipLine line = new(Mod, "BaneAndBrewAttackType", text);
            line.OverrideColor = new(190, 205, 230);

            // Sit right after the "Damage" line so it reads naturally, instead of trailing
            // at the very bottom of the tooltip where it's easy to miss.
            int damageIndex = tooltips.FindIndex(t => t.Name == "Damage");
            if (damageIndex >= 0)
            {
                tooltips.Insert(damageIndex + 1, line);
            }
            else
            {
                tooltips.Add(line);
            }
        }
    }
}