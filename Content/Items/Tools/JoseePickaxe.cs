using TheDollorama.Content.Dusts;
//using TheDollorama.Content.EmoteBubbles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TheDollorama.Content.Items.Tools
{
	public class JoseePickaxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 2;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.pick = 800; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
			Item.axe = 300;
			Item.attackSpeedOnlyAffectsWeaponAnimation = false; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<ExampleCustomDrawDust>());
			}
		}
        public override void HoldItem(Player player)
        {
            // Augmente la portée de minage de 3 blocs lorsque cette pioche est utilisée
            player.blockRange += 5;
        }
        public override void UseAnimation(Player player) {
            // Randomly causes the player to use Example Pickaxe Emote when using the item
            if (Main.myPlayer == player.whoAmI && player.ItemTimeIsZero && Main.rand.NextBool(1))
            {
                int damage = 9; // Le montant de dégâts infligés au joueur
               
				player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} as been too careless with his pickaxe"), 1, 0);
                player.statLife -= damage;
                // Optionnel: Ajoute des effets visuels ou sonores ici si nécessaire
                CombatText.NewText(player.getRect(), Microsoft.Xna.Framework.Color.Red, "10 damage !");
            }
        }

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				//.AddIngredient<ExampleItem>()
				.AddTile<Tiles.Furniture.CommonDolloWorkbench>()
				.Register();
		}
	}
}
