using BaneAndBrew.Common.Families;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Commands
{
    public class UnclassifiedCommand : ModCommand
    {
        public static LocalizedText DescriptionText { get; private set; } = null!;

        public override void SetStaticDefaults()
        {
            DescriptionText = Mod.GetLocalization($"Commands.{nameof(UnclassifiedCommand)}.Description");
        }

        public override string Command => "bnb_unclassified";

        public override CommandType Type => CommandType.Chat;

        public override string Description => DescriptionText.Value;

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            // Optional first argument: only look at one mod
            string? modFilter = args.Length > 0 ? args[0] : null;

            // Both dictionaries are keyed by mod name and sorted, so the output order is stable
            var totals = new SortedDictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var unclassified = new SortedDictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            // Fill dictionaries with NPC's without classification
            //
            for (int type = 0; type < NPCLoader.NPCCount; type++)
            {
                if (!ContentSamples.NpcsByNetId.TryGetValue(type, out NPC? sample))
                {
                    continue;
                }

                if (sample.townNPC || sample.CountsAsACritter || sample.friendly)
                {
                    continue;
                }

                // Vanilla NPCs have no ModNPC, so they are grouped under "Terraria"
                string mod = sample.ModNPC?.Mod.Name ?? "Terraria";
                if (modFilter is not null && !mod.Equals(modFilter, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                totals.TryGetValue(mod, out int total);
                totals[mod] = total + 1;

                // Skip all but none classified NPC's
                //
                if (NPCFamilyRegistry.Get(type).Identity != NPCIdentity.None)
                {
                    continue;
                }

                if (!unclassified.TryGetValue(mod, out List<string>? keys))
                {
                    unclassified[mod] = keys = new List<string>();
                }

                keys.Add($"#{type} - {Lang.GetNPCNameValue(type)}");
            }

            // Typo in the mod name, or a mod without hostile NPCs
            if (totals.Count == 0)
            {
                caller.Reply(modFilter is null
                    ? "No classifiable NPCs found."
                    : $"No classifiable NPCs found for mod '{modFilter}'.", Color.OrangeRed);
                return;
            }

            // The full list goes to the log, one NPC per line, ready to copy
            //
            foreach ((string mod, List<string> keys) in unclassified)
            {
                keys.Sort(StringComparer.OrdinalIgnoreCase);
                Mod.Logger.Info($"Unclassified NPCs [{mod}]:\n  {string.Join("\n  ", keys)}");
            }

            // Chat output: one summary line per mod (green = fully classified, orange = work to do)
            //
            foreach ((string mod, int total) in totals)
            {
                unclassified.TryGetValue(mod, out List<string>? keys);
                int missing = keys?.Count ?? 0;

                caller.Reply($"{mod}: {missing}/{total} unclassified", missing == 0 ? Color.LightGreen : Color.Orange);

                // Only print names in chat when the user asked for one mod,
                // otherwise a big modpack would flood the chat
                //
                if (modFilter is not null && keys is not null)
                {
                    foreach (string[] line in keys.Chunk(4)) // 4 names per chat line
                    {
                        caller.Reply("  " + string.Join(", ", line), Color.LightGray);
                    }
                }
            }

            if (modFilter is null && unclassified.Count > 0)
            {
                caller.Reply("Use /bnb_unclassified <modName> to list them. The full list is in client.log.", Color.LightGray);
            }
        }
    }
}
