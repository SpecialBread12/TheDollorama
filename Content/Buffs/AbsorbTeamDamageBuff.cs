using TheDollorama.Common.Players;
using TheDollorama.Content.Items.Accessories;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
	public class AbsorbTeamDamageBuff : ModBuff
	{
		//public override LocalizedText Description => base.Description.WithFormatArgs(JoseeBadge.DamageAbsorptionPercent);

		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ExampleDamageModificationPlayer>().defendedByAbsorbTeamDamageEffect = true;
		}
	}
}
