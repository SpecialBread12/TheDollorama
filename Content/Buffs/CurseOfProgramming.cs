using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
	public class CurseOfProgramming : ModBuff
	{

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense -= 20;
			player.lifeRegen -= 50;
            player.GetDamage(DamageClass.Generic) += 3f;
            Main.debuff[Type] = true;
        }
	}
}
