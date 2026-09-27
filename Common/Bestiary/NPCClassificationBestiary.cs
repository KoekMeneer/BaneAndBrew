using BaneAndBrew.Common.Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader;

namespace BaneAndBrew.Common.Bestiary
{
    /// <summary>
    /// Adds "Family: X" and, if set, "Alignment: Y" rows to the Bestiary entry of any NPC
    /// that has been given a classification - purely informational, alongside vanilla's own
    /// biome/time rows. Unclassified NPCs (most town NPCs, critters, etc.) get nothing added,
    /// so this never clutters an entry that has nothing to say.
    /// </summary>
    public class NPCClassificationBestiary : GlobalNPC
    {
        public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            NPCClassification classification = NPCFamilyRegistry.Get(npc.type);

            // Add family info if the NPC has a family classification
            //
            string? familyLine = NPCClassificationText.FormatFamilyLine(classification.Identity);
            if (familyLine != null)
            {
                var familyIcon = NPCClassificationIcons.Get(classification.Identity);
                bestiaryEntry.Info.Add(new NPCClassificationBestiaryInfoElement(familyLine, familyIcon));
            }

            // Add alignment info if the NPC has an alignment classification
            //
            string? alignmentLine = NPCClassificationText.FormatAlignmentLine(classification.Alignment);
            if (alignmentLine != null)
            {
                var alignmentIcon = NPCClassificationIcons.Get(classification.Alignment);
                bestiaryEntry.Info.Add(new NPCClassificationBestiaryInfoElement(alignmentLine, alignmentIcon));
            }
        }
    }
}