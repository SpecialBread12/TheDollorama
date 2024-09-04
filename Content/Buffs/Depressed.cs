using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDollorama.Content.DamageClasses;

namespace TheDollorama.Content.Buffs
{
	public class Depressed : ModBuff
	{

		//public override LocalizedText Description => base.Description.WithFormatArgs(D);

		public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen = -5;
            player.moveSpeed -= 0.90f;
            Main.debuff[Type] = true;
        }
	}
}
