using TheDollorama.Content.Items.Placeable;
using TheDollorama.Content.Items.Placeable.Furniture;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.IO;

namespace TheDollorama.Content.Items
{
	public class BoosterPack : ModItem
	{
		public override void SetStaticDefaults() {
			// The text shown below some item names is called a tooltip. Tooltips are defined in the localization files. See en-US.hjson.

			// How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.wiki.gg/wiki/Journey_Mode#Research for a list of commonly used research amounts depending on item type. This defaults to 1, which is what most items will use, so you can omit this for most ModItems.
			Item.ResearchUnlockCount = 100;

            // This item is a custom currency (registered in ExampleMod), so you might want to make it give "coin luck" to the player when thrown into shimmer. See https://terraria.wiki.gg/wiki/Luck#Coins
            // However, since this item is also used in other shimmer related examples, it's commented out to avoid the item disappearing
            //ItemID.Sets.CoinLuckValue[Type] = Item.value;

        }

		public override void SetDefaults() {
			Item.width = 20; // The item texture's width
			Item.height = 20; // The item texture's height

			Item.maxStack = 10; // The item's max stack value
			Item.value = Item.buyPrice(gold: 10); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe(1)
                //.AddIngredient(ItemID.DirtBlock, 10)
                .AddIngredient(ItemID.PlatinumCoin, 20)
                .AddTile(TileID.WorkBenches)
				.Register();
		}

		// Researching the Example item will give you immediate access to the torch, block, wall and workbench!
	}
}
