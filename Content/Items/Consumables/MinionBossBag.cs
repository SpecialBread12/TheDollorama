﻿//using TheDollorama.Content.Items.Armor.Vanity;
using TheDollorama.Content.NPCs.Boss;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheDollorama.Content.Items.Consumables;
using TheDollorama.Content.Items.Armor;

namespace TheDollorama.Content.Items.Consumables
{
	// Basic code for a boss treasure bag
	public class MinionBossBag : ModItem
	{
		public override void SetStaticDefaults() {
			// This set is one that every boss bag should have.
			// It will create a glowing effect around the item when dropped in the world.
			// It will also let our boss bag drop dev armor..
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // ..But this set ensures that dev armor will only be dropped on special world seeds, since that's the behavior of pre-hardmode boss bags.

			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Purple;
			Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
            // We have to replicate the expert drops from MinionBossBody here

            //itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MinionBossMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DolloramaHelmet>(), 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DolloramaBreastplate>(), 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DolloramaLeggings>(), 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Depression>(), 1, 1, 1));
			itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<MinionBossBody>()));
		}
	}
}
