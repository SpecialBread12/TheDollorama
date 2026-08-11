using TheDollorama.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Consumables
{
	// This file showcases how to create an item that increases the player's maximum health on use.
	// Within your ModPlayer, you need to save/load a count of usages. You also need to sync the data to other players.
	// The overlay used to display the custom life fruit can be found in Common/UI/ResourceDisplay/VanillaLifeOverlay.cs
	internal class SilicaPack : ModItem
	{


		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults() {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(gold: 1);
        }

		public override bool? UseItem(Player player) {
            Item.buffType = ModContent.BuffType<Buffs.Drying>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 300; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
			return true;
        }

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.GoldCoin, 1)
                .AddTile<Tiles.Furniture.PreHardModePallet>()
				.Register();
		}
	}
}
