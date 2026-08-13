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
	public class BallOfPrice : ModItem
	{

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {

            player.GetAttackSpeed(DamageClass.Generic) += 0.1f;
			player.GetCritChance(DamageClass.Generic) += 0.1f;
			player.GetDamage(DamageClass.Generic) += 0.1f;

        }
    }
}
