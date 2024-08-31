using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static TheDollorama.TheDollorama;

namespace TheDollorama.Common.Players
{
    public class DamageIncreasePlayerMelee : ModPlayer
    {
        public int damageBoostsMelee;

        public override void ResetEffects()
        {
            // Applique le bonus de dégâts permanent
            Player.GetDamage<MeleeDamageClass>() += 0.05f * damageBoostsMelee; // Augmente de 1% par utilisation
        }

        public override void SaveData(TagCompound tag)
        {
            tag["damageBoostsMelee"] = damageBoostsMelee;
        }

        public override void LoadData(TagCompound tag)
        {
            damageBoostsMelee = tag.GetInt("damageBoostsMelee");
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            DamageIncreasePlayerMelee clone = targetCopy as DamageIncreasePlayerMelee;
            clone.damageBoostsMelee = damageBoostsMelee;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)MessageType.MeleeDamageIncreasePlayerSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write(damageBoostsMelee);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            DamageIncreasePlayerMelee clone = clientPlayer as DamageIncreasePlayerMelee;
            if (clone.damageBoostsMelee != damageBoostsMelee)
            if (clone.damageBoostsMelee != damageBoostsMelee)
            {
                // Envoie une mise à jour au client
                SyncPlayer(-1, Player.whoAmI, false);
            }
        }
    }

    public class DamageIncreasePlayerRanged : ModPlayer
    {
        public int damageBoostsRanged;

        public override void ResetEffects()
        {
            // Applique le bonus de dégâts permanent
            Player.GetDamage<RangedDamageClass>() += 0.05f * damageBoostsRanged; // Augmente de 1% par utilisation
        }

        public override void SaveData(TagCompound tag)
        {
            tag["damageBoostsRanged"] = damageBoostsRanged;
        }

        public override void LoadData(TagCompound tag)
        {
            damageBoostsRanged = tag.GetInt("damageBoostsRanged");
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            DamageIncreasePlayerRanged clone = targetCopy as DamageIncreasePlayerRanged;
            clone.damageBoostsRanged = damageBoostsRanged;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)MessageType.RangedDamageIncreasePlayerSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write(damageBoostsRanged);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            DamageIncreasePlayerRanged clone = clientPlayer as DamageIncreasePlayerRanged;
            if (clone.damageBoostsRanged != damageBoostsRanged)
            {
                // Envoie une mise à jour au client
                SyncPlayer(-1, Player.whoAmI, false);
            }
        }
    }

    public class DamageIncreasePlayerMagic : ModPlayer
    {
        public int damageBoostsMagic;

        public override void ResetEffects()
        {
            // Applique le bonus de dégâts permanent
            Player.GetDamage<MagicDamageClass>() += 0.05f * damageBoostsMagic; // Augmente de 1% par utilisation
        }

        public override void SaveData(TagCompound tag)
        {
            tag["damageBoostsMagic"] = damageBoostsMagic;
        }

        public override void LoadData(TagCompound tag)
        {
            damageBoostsMagic = tag.GetInt("damageBoostsMagic");
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            DamageIncreasePlayerMagic clone = targetCopy as DamageIncreasePlayerMagic;
            clone.damageBoostsMagic = damageBoostsMagic;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)MessageType.MagicDamageIncreasePlayerSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write(damageBoostsMagic);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            DamageIncreasePlayerMagic clone = clientPlayer as DamageIncreasePlayerMagic;
            if (clone.damageBoostsMagic != damageBoostsMagic)
            {
                // Envoie une mise à jour au client
                SyncPlayer(-1, Player.whoAmI, false);
            }
        }
    }

    public class DamageIncreasePlayerSummon : ModPlayer
    {
        public int damageBoostsSummon;


        public override void ResetEffects()
        {
            // Applique le bonus de dégâts permanent
            Player.GetDamage<SummonDamageClass>() += 0.05f * damageBoostsSummon; // Augmente de 1% par utilisation
        }

        public override void SaveData(TagCompound tag)
        {
            tag["damageBoostsSummon"] = damageBoostsSummon;
        }

        public override void LoadData(TagCompound tag)
        {
            damageBoostsSummon = tag.GetInt("damageBoostsSummon");
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            DamageIncreasePlayerSummon clone = targetCopy as DamageIncreasePlayerSummon;
            clone.damageBoostsSummon = damageBoostsSummon;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)MessageType.SummonDamageIncreasePlayerSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write(damageBoostsSummon);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            DamageIncreasePlayerSummon clone = clientPlayer as DamageIncreasePlayerSummon;
            if (clone.damageBoostsSummon != damageBoostsSummon)
            {
                // Envoie une mise à jour au client
                SyncPlayer(-1, Player.whoAmI, false);
            }
        }
    }
}
