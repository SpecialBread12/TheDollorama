using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDollorama.Content.Items.Consumables;

namespace TheDollorama.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class SupervisorBreastplate : ModItem
	{
		public static readonly int MaxManaIncrease = 20;
		

		//public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxManaIncrease, MaxMinionIncrease);

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 9; // The amount of defense the item will give when equipped
		}

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Card10>(), 1);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ModContent.ItemType<DollaramaBox>(), 10);
            recipe.AddConsumeIngredientCallback((Recipe recipe, int type, ref int amount, bool isDecrafting) =>
            {
                if (type == ModContent.ItemType<Card10>())
                {
                    amount = 0;
                }
                if (!isDecrafting && type == ModContent.ItemType<Card10>())
                {
                    amount = 0;
                }
            });
            recipe.AddTile<Tiles.Furniture.PreHardModePallet>();
            recipe.Register();
        }
    }
}
