using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BaneAndBrew.Common.Combat
{
    public class ClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool ShowAffinityText;

        [DefaultValue(true)]
        public bool ShowWeaponPropertyTooltip;
    }
}