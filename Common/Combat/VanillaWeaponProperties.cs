using Terraria.ID;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Default attack properties for vanilla weapons. Only weapons with an obvious elemental
    /// or thematic identity need an entry here - most weapons stay unregistered and deal
    /// ordinary physical damage.
    /// </summary>
    internal static class VanillaWeaponProperties
    {
        public static void Register()
        {
            RegisterFire();
            RegisterFrost();

            RegisterExplosive();
        }

        private static void RegisterFire()
        {
            // Ammo
            WeaponPropertyRegistry.SetProperties(ItemID.FlamingArrow, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Gel, AttackPropertyRegistry.Fire); // Used by flamethrowers, but may be debatable.
            WeaponPropertyRegistry.SetProperties(ItemID.Flare, AttackPropertyRegistry.Fire);

            // Weapons
            WeaponPropertyRegistry.SetProperties(ItemID.FieryGreatsword, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.DD2SquireDemonSword, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.HelFire, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamarang, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FlamingMace, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Sunfury, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.DayBreak, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.SolarEruption, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Sunfury, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.MolotovCocktail, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamethrower, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.WandofSparking, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.FlowerofFire, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamelash, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.InfernoFork, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.HeatRay, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.ImpStaff, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FireWhip, AttackPropertyRegistry.Fire);
        }

        public static void RegisterFrost()
        {
            // Ammo
            WeaponPropertyRegistry.SetProperties(ItemID.FrostburnArrow, AttackPropertyRegistry.Frost);

            // Weapons
            WeaponPropertyRegistry.SetProperties(ItemID.IceBlade, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.Frostbrand, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.IceSickle, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.Amarok, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.NorthPole, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.IceBoomerang, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.FrostDaggerfish, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.SnowballCannon, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.WandofFrosting, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.FlowerofFrost, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.FrostStaff, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.BlizzardStaff, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.IceRod, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.StaffoftheFrostHydra, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.CoolWhip, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.SnowballLauncher, AttackPropertyRegistry.Frost);
        }

        public static void RegisterExplosive()
        {
            // Ammo
            WeaponPropertyRegistry.SetProperties(ItemID.RocketI, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.RocketII, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.RocketIII, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.RocketIV, AttackPropertyRegistry.Explosive);

            // Weapons
            WeaponPropertyRegistry.SetProperties(ItemID.Grenade, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.StickyGrenade, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.BouncyGrenade, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.PartyGirlGrenade, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.Bomb, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.StickyBomb, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.BouncyBomb, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.ScarabBomb, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.BombFish, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.Dynamite, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.StickyDynamite, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.BouncyDynamite, AttackPropertyRegistry.Explosive);
            WeaponPropertyRegistry.SetProperties(ItemID.DynamiteFish, AttackPropertyRegistry.Explosive);
            // TODO: What magic and other weapons are explosive?
        }
    }
}
