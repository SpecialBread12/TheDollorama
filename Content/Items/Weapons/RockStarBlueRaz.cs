﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Weapons
{
	public class RockStarBlueRaz : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.shootSpeed = 12f;
			Item.shoot = ModContent.ProjectileType<Projectiles.RockStarBlueRaz>();
			Item.width = 8;
			Item.height = 28;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 40;
			Item.useTime = 40;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.buyPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
