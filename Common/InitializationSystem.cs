using BaneAndBrew.Common.Combat;
using BaneAndBrew.Common.Families;
using Terraria.ModLoader;

namespace BaneAndBrew.Common
{
    internal class InitializationSystem : ModSystem
    {
        // Runs after all mods have registered NPCs, loot and recipes.
        // If the drop database looks empty at this stage, move the build lazily to first use.
        public override void PostAddRecipes()
        {
            NPCFamilyRegistry.Initialize();
            WeaponPropertyRegistry.Initialize();
        }
    }
}
