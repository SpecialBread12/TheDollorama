using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheDollorama.Content.Items;
//using TheDollorama.Common.ItemDropRules.DropConditions;

namespace TheDollorama.Common.GlobalNPCs
{
    class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (Main.rand.NextFloat() < 0.0001) // 1% chance to drop
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoosterPack>(), 1));
            }
        }
        /*
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!NPCID.Sets.CountsAsCritter[npc.type])
            { // If npc is not a critter
              // Make it drop ExampleItem.
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ExampleItem>(), 1));

                // Drop an ExampleResearchPresent in journey mode with 2/7ths base chance, but only in journey mode
                npcLoot.Add(ItemDropRule.ByCondition(new ExampleJourneyModeDropCondition(), ModContent.ItemType<ExampleResearchPresent>(), chanceDenominator: 7, chanceNumerator: 2));
            }
        */
    }
}
