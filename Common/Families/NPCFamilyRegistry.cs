using Terraria.ModLoader;

namespace BaneAndBrew.Common.Families
{
    public static class NPCFamilyRegistry
    {
        private const int NegativeIdCount = 65; // vanilla negative IDs run from -1 to -65

        private static NPCClassification[] _classifications = [];
        private static NPCClassification[] _legacyClassifications = new NPCClassification[NegativeIdCount];

        private static bool _initialized;

        public static void Initialize()
        {
            if (_initialized) return;

            _classifications = new NPCClassification[NPCLoader.NPCCount];

            VanillaNPCFamilies.Register();
        }

        /// <summary>
        /// Gets the classification of the NPC with the specified type.
        /// </summary>
        /// <param name="npcType"></param>
        /// <returns></returns>
        public static NPCClassification Get(int npcType)
        {
            if (npcType < 0)
            {
                int index = -npcType - 1; // -1 -> 0, -65 -> 64
                return (uint)index < (uint)_legacyClassifications.Length
                    ? _legacyClassifications[index]
                    : default;
            }

            return (uint)npcType < (uint)_classifications.Length
                ? _classifications[npcType]
                : default;
        }

        public static NPCIdentity GetIdentity(int npcType)
            => Get(npcType).Identity;

        public static NPCAlignment GetAlignment(int npcType)
            => Get(npcType).Alignment;

        public static bool IsIdentity(int npcType, NPCIdentity identity)
            => GetIdentity(npcType) == identity;

        public static bool HasAlignment(int npcType, NPCAlignment alignment)
            => GetAlignment(npcType) == alignment;

        /// <summary>
        /// Registers the identity for the specified npc type.
        /// </summary>
        /// <param name="npcType"></param>
        /// <param name="identity"></param>
        /// <param name="alignment"></param>
        internal static void Register(int npcType, NPCIdentity identity, NPCAlignment alignment = NPCAlignment.None)
        {
            Set(npcType, new NPCClassification(identity, alignment));
        }

        internal static void SetAlignment(int npcType, NPCAlignment alignment)
        {
            var old = Get(npcType);
            Set(npcType, new NPCClassification(old.Identity, alignment));
        }

        internal static void SetAlignments(NPCAlignment alignment, params int[] targets)
        {
            foreach (int target in targets)
                SetAlignment(target, alignment);
        }

        internal static void Copy(int source, params int[] targets)
        {
            NPCClassification classification = Get(source);

            foreach (int target in targets)
            {
                Set(target, classification);
            }
        }

        private static void Set(int npcType, NPCClassification classification)
        {
            if (npcType < 0)
            {
                int index = -npcType - 1;
                if ((uint)index < (uint)_legacyClassifications.Length)
                    _legacyClassifications[index] = classification;

                return;
            }

            if ((uint)npcType < (uint)_classifications.Length)
                _classifications[npcType] = classification;
        }
    }
}

