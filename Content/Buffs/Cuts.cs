using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDollorama.Content.DamageClasses;

namespace TheDollorama.Content.Buffs
{
	public class Cuts : ModBuff
	{

		//public override LocalizedText Description => base.Description.WithFormatArgs(D);

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense -= 4; // Grant a +10 defense boost to the player while the buff is active.
            player.lifeRegen = 0;
            //player.meleeSpeed -= 0.10f;
            player.moveSpeed -= 0.30f;

            player.GetAttackSpeed(DamageClass.Melee) -= 0.30f;
            player.GetAttackSpeed(DamageClass.Ranged) -= 0.30f;
            player.GetAttackSpeed(DamageClass.Magic) -= 0.30f;
            player.GetAttackSpeed(DamageClass.Summon) -= 0.30f;
            player.GetAttackSpeed(DamageClass.Throwing) -= 0.30f;
            player.GetAttackSpeed(ModContent.GetInstance<SprayDamage>()) -= 0.30f;
            Main.debuff[Type] = true;
        }
	}
}
