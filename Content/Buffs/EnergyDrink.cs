using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
	public class EnergyDrink : ModBuff
	{
		//public static readonly int DefenseBonus = 10;

		//public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 10; // Grant a +10 defense boost to the player while the buff is active.
            player.moveSpeed += 0.30f;
            player.lifeRegen += 1;

            player.GetAttackSpeed(DamageClass.Melee) += 0.30f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.30f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.30f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.30f;
            player.GetAttackSpeed(DamageClass.Throwing) += 0.30f;
            Main.debuff[Type] = false;

            player.GetDamage(DamageClass.Generic) += 0.2f;
        }
	}
}
