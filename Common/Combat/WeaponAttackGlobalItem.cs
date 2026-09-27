using Terraria;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Applies affinity-based damage and shows effectiveness text for direct (non-projectile)
    /// weapon hits - melee swings, whips, anything that damages an NPC through the item
    /// itself rather than through a spawned projectile.
    /// See <see cref="WeaponAttackGlobalProjectile"/> for the projectile side.
    /// </summary>
    public class WeaponAttackGlobalItem : GlobalItem
    {
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            AttackProperty[] properties = WeaponPropertyRegistry.Get(item.type);
            if (properties.Length == 0)
            {
                return; // pure physical damage, nothing to adjust
            }

            modifiers.FinalDamage *= FamilyAffinityRegistry.GetMultiplier(target.type, properties);
        }

        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            AttackProperty[] properties = WeaponPropertyRegistry.Get(item.type);
            if (properties.Length == 0)
            {
                return;
            }

            Affinity affinity = FamilyAffinityRegistry.GetAffinity(target.type, properties);
            target.GetGlobalNPC<EffectivenessNpc>().TryShow(target, affinity);
        }
    }
}