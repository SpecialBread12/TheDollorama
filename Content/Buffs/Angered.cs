using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
	public class Angered : ModBuff
	{
		public static readonly int DefenseBonus = 5;

		public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}
