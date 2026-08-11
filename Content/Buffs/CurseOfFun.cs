using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
	public class CurseOfFun : ModBuff
	{

		public override void Update(Player player, ref int buffIndex) {
			player.lifeRegen -= 50;
            Main.debuff[Type] = true;
        }
	}
}
