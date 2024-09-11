using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Placeable.Furniture
{
	public class Pallets : ModItem
	{
		public override void SetDefaults() {
			// ModContent.TileType<Tiles.Furniture.ExampleWorkbench>() retrieves the id of the tile that this item should place when used.
			// DefaultToPlaceableTile handles setting various Item values that placeable items use
			// Hover over DefaultToPlaceableTile in Visual Studio to read the documentation!
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CommonDolloWorkbench>());
			Item.width = 36; // The item texture's width
			Item.height = 8; // The item texture's height
			Item.value = 150;
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 40)
                .AddIngredient(ItemID.IronBar, 2)
                .AddIngredient(ItemID.GoldCoin, 20)
                .Register();
		}
	}
}
