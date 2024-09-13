using TheDollorama.Common.Players;
using TheDollorama.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDollorama.Content.Items.Consumables;

namespace TheDollorama.Content.Items.Accessories
{
	/// <summary>
	/// AbsorbTeamDamageAccessory mimics the unique effect of the Paladin's Shield item.
	/// This example showcases some advanced interplay between accessories, buffs, and ModPlayer hooks.
	/// Of particular note is how this accessory gives other players a buff and how a player might act on another player being hit.
	/// </summary>
	[AutoloadEquip(EquipType.Shield)]
	public class JoseeBadge : ModItem
	{

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.accessory = true;
			Item.rare = ItemRarityID.Purple;
			Item.defense = 16;
			Item.value = Item.buyPrice(0, 30, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.noKnockback = true;
			player.lifeRegen += 30;
            player.GetAttackSpeed(DamageClass.Generic) += 0.8f;
            player.GetDamage(DamageClass.Generic) += 0.8f;
			player.manaCost -= 25;
			player.maxMinions += 6;
			player.maxRegenDelay -= 20;
			player.statLifeMax += 100;
			player.statLifeMax2 += 100;
            player.statManaMax += 40;
            player.statManaMax2 += 40;
			player.maxRunSpeed += 10;
			player.wingTimeMax += 200;
			
		}
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.AnkhShield)
                .AddIngredient(ModContent.ItemType<FruitPunchRockStar>(), 5)
                .AddIngredient(ModContent.ItemType<BoosterPack>(), 5)
                .AddIngredient(ItemID.PlatinumCoin, 50)
                .AddTile<Tiles.Furniture.CommonDolloWorkbench>()
                .Register();
        }
    }
}
