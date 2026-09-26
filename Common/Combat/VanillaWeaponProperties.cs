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
            // A handful of examples to seed the pattern - not exhaustive yet.
            //
            WeaponPropertyRegistry.SetProperties(ItemID.MoltenFury, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FrostStaff, AttackPropertyRegistry.Frost);
            WeaponPropertyRegistry.SetProperties(ItemID.NightsEdge, AttackPropertyRegistry.Cursed);

            // TODO: same treatment as VanillaNPCFamilies - happy to pass over the full
            // vanilla weapon list once this shape feels right to you.
        }

        private static void RegisterFire()
        {
            WeaponPropertyRegistry.SetProperties(ItemID.FieryGreatsword, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.DD2SquireDemonSword, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.HelFire, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamarang, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FlamingMace, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Sunfury, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.DayBreak, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Sunfury, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.MolotovCocktail, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamethrower, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FlowerofFire, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.Flamelash, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.InfernoFork, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.ImpStaff, AttackPropertyRegistry.Fire);
            WeaponPropertyRegistry.SetProperties(ItemID.FireWhip, AttackPropertyRegistry.Fire);
        }

        public static void RegisterFrost()
        {

        }
    }
}
