using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Consumables
{
	public class Necronomicon : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(240, 0, 0),
				new Color(200, 0, 0),
				new Color(140, 0, 0)
			};
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<Buffs.CurseOfProgramming>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 600; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldCoin, 50)
                .AddTile<Tiles.Furniture.CommonDolloWorkbench>()
                .Register();
        }
    }
}
