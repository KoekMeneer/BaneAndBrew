using BaneAndBrew.Common.Combat;
using Terraria.ModLoader;

namespace BaneAndBrew
{
    public class BaneAndBrew : Mod
    {
        public override void Load()
        {
            FamilyAffinityRegistry.Load();
        }

        public override void Unload()
        {
            FamilyAffinityRegistry.Unload();
        }
    }
}