using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Maps a weapon's item type to the <see cref="AttackProperty"/> values its attacks carry
    /// (e.g. Molten Fury might carry Fire). Unregistered items carry none, i.e. they hit as
    /// ordinary physical damage - see <see cref="FamilyAffinityRegistry"/> for how those
    /// properties turn into a damage multiplier against a given NPC.
    /// </summary>
    public static class WeaponPropertyRegistry
    {
        private static AttackProperty[][] _properties = [];

        private static bool _initialized;

        public static void Initialize()
        {
            if (_initialized) return;

            _properties = new AttackProperty[ItemLoader.ItemCount][];

            VanillaWeaponProperties.Register();

            _initialized = true;
        }

        public static void Unload()
        {
            _properties = [];
            _initialized = false;
        }

        /// <summary>
        /// Gets the properties registered for an item type. Never null - an unregistered
        /// item simply returns an empty array (ordinary physical damage).
        /// </summary>
        public static AttackProperty[] Get(int itemType)
            => (uint)itemType < (uint)_properties.Length
                ? _properties[itemType] ?? []
                : [];

        /// <summary>
        /// Registers (or replaces) the properties carried by an item's attacks.
        /// </summary>
        public static void SetProperties(int itemType, params AttackProperty[] properties)
        {
            if ((uint)itemType < (uint)_properties.Length)
                _properties[itemType] = properties;
        }

        /// <summary>
        /// Gives one or more item types the same properties as an already-registered source -
        /// handy for a family of reskinned weapons that should all behave the same.
        /// </summary>
        public static void Copy(int source, params int[] targets)
        {
            AttackProperty[] properties = Get(source);

            foreach (int target in targets)
                SetProperties(target, properties);
        }
    }
}