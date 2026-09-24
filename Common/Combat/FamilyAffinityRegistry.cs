using BaneAndBrew.Common.Families;
using System.Collections.Generic;

namespace BaneAndBrew.Common.Combat
{
    /// <summary>
    /// Maps NPC identities and alignments (see <see cref="NPCIdentity"/> and
    /// <see cref="NPCAlignment"/>) to their affinity against specific attack properties.
    /// </summary>
    public static class FamilyAffinityRegistry
    {
        private static readonly Dictionary<NPCIdentity, Dictionary<AttackProperty, Affinity>> _identityTraits = new();
        private static readonly Dictionary<NPCAlignment, Dictionary<AttackProperty, Affinity>> _alignmentTraits = new();

        public static void Load()
        {
            RegisterDefaultTraits();
        }

        public static void Unload()
        {
            _identityTraits.Clear();
            _alignmentTraits.Clear();
        }

        private static void RegisterDefaultTraits()
        {
            // --- Identities: baseline traits shared by the whole family ---

            // Slimes: blades pass through gelatinous bodies, but fire and frost finish them off.
            SetTraits(NPCIdentity.Slime,
                (AttackPropertyRegistry.Piercing, Affinity.Resistant),
                (AttackPropertyRegistry.Fire, Affinity.Vulnerable),
                (AttackPropertyRegistry.Frost, Affinity.Vulnerable));

            // Undead: no organs left to poison, but bones shatter under blunt force
            // and recoil from holy light.
            SetTraits(NPCIdentity.Undead,
                (AttackPropertyRegistry.Poison, Affinity.Immune), // classic trope, earns the rare Immune
                (AttackPropertyRegistry.Blunt, Affinity.Vulnerable),
                (AttackPropertyRegistry.Holy, Affinity.Vulnerable));

            // Spirits: incorporeal, so mundane weapons mostly pass straight through.
            SetTraits(NPCIdentity.Spirit,
                (AttackPropertyRegistry.Piercing, Affinity.Resistant),
                (AttackPropertyRegistry.Blunt, Affinity.Resistant),
                (AttackPropertyRegistry.Holy, Affinity.Vulnerable));

            // Demons: creatures of hellfire, burned instead by holy light.
            SetTraits(NPCIdentity.Demon,
                (AttackPropertyRegistry.Fire, Affinity.Resistant),
                (AttackPropertyRegistry.Holy, Affinity.Vulnerable));

            // Beasts: mundane animals
            SetTraits(NPCIdentity.Beast,
                (AttackPropertyRegistry.Poison, Affinity.Vulnerable));

            // Humanoids: ordinary people. No exotic resistances - just flesh, blood, and poison.
            SetTraits(NPCIdentity.Humanoid,
                (AttackPropertyRegistry.Poison, Affinity.Vulnerable));

            // Insects: fragile against fire and cold, but happily marinate in their own toxins.
            SetTraits(NPCIdentity.Insect,
                (AttackPropertyRegistry.Fire, Affinity.Vulnerable),
                (AttackPropertyRegistry.Frost, Affinity.Vulnerable),
                (AttackPropertyRegistry.Poison, Affinity.Resistant));

            // Plants: kindling with roots. Tough bark shrugs off punctures, and their own
            // toxins make poison a wasted effort.
            SetTraits(NPCIdentity.Plant,
                (AttackPropertyRegistry.Fire, Affinity.Vulnerable),
                (AttackPropertyRegistry.Piercing, Affinity.Resistant),
                (AttackPropertyRegistry.Poison, Affinity.Resistant));

            // Aquatics: right at home in water, less so against a hard freeze or a live current.
            SetTraits(NPCIdentity.Aquatic,
                (AttackPropertyRegistry.Fire, Affinity.Resistant),
                (AttackPropertyRegistry.Frost, Affinity.Vulnerable),
                (AttackPropertyRegistry.Lightning, Affinity.Vulnerable));

            // Constructs: armored and mindless. Blades skate off the plating, but a solid
            // blow or a explosive finds the gaps in the machinery or magic. No biology to poison.
            SetTraits(NPCIdentity.Construct,
                (AttackPropertyRegistry.Poison, Affinity.Immune), // no organs, earns the 2nd rare Immune
                (AttackPropertyRegistry.Piercing, Affinity.Resistant),
                (AttackPropertyRegistry.Blunt, Affinity.Vulnerable),
                (AttackPropertyRegistry.Explosive, Affinity.Vulnerable));

            // Eldritch: horrors from beyond, allergic to holy light and right at home in the dark.
            SetTraits(NPCIdentity.Eldritch,
                (AttackPropertyRegistry.Holy, Affinity.Vulnerable),
                (AttackPropertyRegistry.Cursed, Affinity.Resistant));

            // --- Alignments: elemental "home turf" traits, layered on top of identity ---
            // These mirror the five alignments 1:1 with their matching damage property, and
            // win ties against identity traits (see GetAffinity(identity, alignment, property)
            // below) since an NPC's specific alignment is a stronger signal than its broad
            // family. This is also how a Lava Slime ends up fire-resistant despite Slime
            // identity being fire-vulnerable - the alignment overrides just that one property.

            SetTraits(NPCAlignment.Infernal,
                (AttackPropertyRegistry.Fire, Affinity.Resistant),
                (AttackPropertyRegistry.Frost, Affinity.Vulnerable));

            SetTraits(NPCAlignment.Frigid,
                (AttackPropertyRegistry.Frost, Affinity.Resistant),
                (AttackPropertyRegistry.Fire, Affinity.Vulnerable));

            SetTraits(NPCAlignment.Storm,
                (AttackPropertyRegistry.Lightning, Affinity.Resistant));
            // (No paired vulnerability - not every alignment needs an opposite number.)

            SetTraits(NPCAlignment.Corrupted,
                (AttackPropertyRegistry.Cursed, Affinity.Resistant),
                (AttackPropertyRegistry.Holy, Affinity.Vulnerable));

            SetTraits(NPCAlignment.Hallowed,
                (AttackPropertyRegistry.Holy, Affinity.Resistant),
                (AttackPropertyRegistry.Cursed, Affinity.Vulnerable));
        }

        public static void SetTraits(NPCIdentity identity, params (AttackProperty Property, Affinity Affinity)[] traits)
            => SetTraits(_identityTraits, identity, traits);

        public static void SetTraits(NPCAlignment alignment, params (AttackProperty Property, Affinity Affinity)[] traits)
            => SetTraits(_alignmentTraits, alignment, traits);

        public static Affinity GetAffinity(NPCIdentity identity, AttackProperty property)
            => TryGetAffinity(_identityTraits, identity, property, out var affinity) ? affinity : default;

        public static Affinity GetAffinity(NPCAlignment alignment, AttackProperty property)
            => TryGetAffinity(_alignmentTraits, alignment, property, out var affinity) ? affinity : default;

        /// <summary>
        /// Resolves the effective affinity for an NPC that has both an identity and an alignment.
        /// Alignment is treated as the more specific trait, so it wins if both define the property.
        /// </summary>
        public static Affinity GetAffinity(NPCIdentity identity, NPCAlignment alignment, AttackProperty property)
        {
            if (TryGetAffinity(_alignmentTraits, alignment, property, out var alignmentAffinity))
                return alignmentAffinity;

            if (TryGetAffinity(_identityTraits, identity, property, out var identityAffinity))
                return identityAffinity;

            return default;
        }

        private static void SetTraits<TKey>(
            Dictionary<TKey, Dictionary<AttackProperty, Affinity>> table,
            TKey key,
            (AttackProperty Property, Affinity Affinity)[] traits) where TKey : notnull
        {
            if (!table.TryGetValue(key, out var entry))
            {
                entry = new Dictionary<AttackProperty, Affinity>();
                table[key] = entry;
            }

            foreach (var (property, affinity) in traits)
            {
                entry[property] = affinity; // overwrite on repeat calls, rather than throwing
            }
        }

        private static bool TryGetAffinity<TKey>(
            Dictionary<TKey, Dictionary<AttackProperty, Affinity>> table,
            TKey key,
            AttackProperty property,
            out Affinity affinity) where TKey : notnull
        {
            affinity = default;
            return table.TryGetValue(key, out var traits) && traits.TryGetValue(property, out affinity);
        }
    }
}