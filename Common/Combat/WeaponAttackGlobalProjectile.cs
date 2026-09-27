using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Applies affinity-based damage and shows effectiveness text for projectile hits
    /// (arrows, bullets, magic bolts, thrown weapons, ...). The properties come from the
    /// weapon that fired the projectile - and, for ranged weapons, the ammo too - captured
    /// once at spawn time rather than looked up by projectile type, since the same wooden
    /// arrow means something different depending on what fired it.
    /// </summary>
    public class WeaponAttackGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        private AttackProperty[] _properties = [];

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is not EntitySource_ItemUse weaponSource)
            {
                return; // not fired by an item - e.g. spawned by another projectile
            }

            AttackProperty[] properties = WeaponPropertyRegistry.Get(weaponSource.Item.type);

            // Ranged weapons: the ammo can carry its own properties too (a Frostburn Arrow
            // stays frosty even out of a plain wooden bow). Union the two, skipping anything
            // the weapon already contributes so a shared property isn't applied twice.
            if (source is EntitySource_ItemUse_WithAmmo ammoSource)
            {
                AttackProperty[] ammoProperties = WeaponPropertyRegistry.Get(ammoSource.AmmoItemIdUsed);
                if (ammoProperties.Length > 0)
                {
                    properties = [.. properties, .. ammoProperties.Except(properties)];
                }
            }

            _properties = properties;
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (_properties.Length == 0)
            {
                return;
            }

            modifiers.FinalDamage *= FamilyAffinityRegistry.GetMultiplier(target.type, _properties);
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (_properties.Length == 0)
            {
                return;
            }

            Affinity affinity = FamilyAffinityRegistry.GetAffinity(target.type, _properties);
            target.GetGlobalNPC<EffectivenessNpc>().TryShow(target, affinity);
        }
    }
}