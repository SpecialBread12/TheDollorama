using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Buffs
{
    public class Drying : ModBuff
    {
        //public static readonly int DefenseBonus = 10;

        //public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 5;
            player.moveSpeed -= 0.30f;
            player.lifeRegen = 0;
            Main.debuff[Type] = true;
        }
    }
}
