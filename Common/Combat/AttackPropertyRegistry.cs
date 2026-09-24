using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Collection of Attack properties.
    /// </summary>
    public static class AttackPropertyRegistry
    {
        private  static readonly Dictionary<string, AttackProperty> _propertyIdMap = new(StringComparer.OrdinalIgnoreCase);

        // BUILT-IN PROPERTIES
        //
        /// <summary>
        /// Flamethrowers, molten gear, hellfire arrows.
        /// </summary>
        public static readonly AttackProperty Fire = Register("Fire");
        /// <summary>
        /// Ice weapons, frostburn ammo.
        /// </summary>
        public static readonly AttackProperty Frost = Register("Frost");
        /// <summary>
        /// Thunder/tech weapons, storm staves.
        /// </summary>
        public static readonly AttackProperty Lightning = Register("Lightning");
        /// <summary>
        /// Blade of Grass?, stingers, venom (merged in).
        /// </summary>
        public static readonly AttackProperty Poison = Register("Poison");
        /// <summary>
        /// Hallowed gear, holy arrows.
        /// </summary>
        public static readonly AttackProperty Holy = Register("Holy");
        /// <summary>
        /// Cursed flames, shadowflame, ichor, demonite
        /// </summary>
        public static readonly AttackProperty Cursed = Register("Cursed");
        /// <summary>
        /// Spears, arrows, bolts, darts
        /// </summary>
        public static readonly AttackProperty Piercing = Register("Piercing");
        /// <summary>
        /// Hammers, maces, flails
        /// </summary>
        public static readonly AttackProperty Blunt = Register("Blunt");
        /// <summary>
        /// Bombs, rockets, grenades
        /// </summary>
        public static readonly AttackProperty Explosive = Register("Explosive");

        /// <summary>
        /// Every registered property (built-in and from other mods).
        /// </summary>
        public static IEnumerable<AttackProperty> All => _propertyIdMap.Values;

        /// <summary>
        /// Looks up a property by id. Returns false when nobody registered it.
        /// </summary>
        public static bool TryGet(string id, [NotNullWhen(true)] out AttackProperty? property)
            => _propertyIdMap.TryGetValue(id, out property);

        /// <summary>
        /// Registers a property, or returns the existing one if the id is already known.
        /// Safe to call twice, so two mods can both register the same shared property.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static AttackProperty Register(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Attack property id must not be empty.", nameof(id));
            }

            if (!_propertyIdMap.TryGetValue(id, out AttackProperty? property))
            {
                _propertyIdMap[id] = property = new AttackProperty(id);
            }

            return property;
        }

        /// <summary>
        /// Gives every property registered so far (= the built-ins above) its localized name.
        /// Key: Mods.BaneAndBrew.AttackProperties.[Id], see the .hjson file. Called once from LocalizationSystem.
        /// Properties added later by other mods bring their own name through Mod.Call.
        /// </summary>
        internal static void LoadBuiltInNames(Mod mod)
        {
            foreach (AttackProperty property in _propertyIdMap.Values)
            {
                string id = property.Id;
                property.Name ??= mod.GetLocalization($"AttackProperties.{id}", () => id);
            }
        }

        /// <summary>
        /// Called when the mod unloads (see FamilyTraitSystem.Unload).
        /// </summary>
        internal static void Clear() => _propertyIdMap.Clear();
    }
}
