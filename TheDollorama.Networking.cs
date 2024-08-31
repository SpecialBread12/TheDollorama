using TheDollorama.Common.Players;
using TheDollorama.Common.Systems;
using TheDollorama.Content.Items.Consumables;
using TheDollorama.Content.NPCs;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama
{
	// This is a partial class, meaning some of its parts were split into other files. See ExampleMod.*.cs for other portions.
	// The class is partial to organize similar code together to clarify what is related.
	// This class extends from the Mod class as seen in ExampleMod.cs. Make sure to extend from the mod class, ": Mod", in your own code if using this file as a template for you mods Mod class.
	partial class TheDollorama
	{
		internal enum MessageType : byte
		{
			ExampleStatIncreasePlayerSync,
            MeleeDamageIncreasePlayerSync,
            RangedDamageIncreasePlayerSync,
            MagicDamageIncreasePlayerSync,
            SummonDamageIncreasePlayerSync,
            ExampleTeleportToStatue,
			ExampleDodge,
			ExampleTownPetUnlockOrExchange,
			ExampleResourceEffect
		}

		// Override this method to handle network packets sent for this mod.
		//TODO: Introduce OOP packets into tML, to avoid this god-class level hardcode.
		public override void HandlePacket(BinaryReader reader, int whoAmI) {
			MessageType msgType = (MessageType)reader.ReadByte();
			byte playerNumber = 0;

            switch (msgType) {
				// This message syncs ExampleStatIncreasePlayer.exampleLifeFruits and ExampleStatIncreasePlayer.exampleManaCrystals
				case MessageType.ExampleStatIncreasePlayerSync:
					playerNumber = reader.ReadByte();
					ExampleStatIncreasePlayer examplePlayer = Main.player[playerNumber].GetModPlayer<ExampleStatIncreasePlayer>();
					examplePlayer.ReceivePlayerSync(reader);

					if (Main.netMode == NetmodeID.Server) {
						// Forward the changes to the other clients
						examplePlayer.SyncPlayer(-1, whoAmI, false);
					}
					break;

                case MessageType.MeleeDamageIncreasePlayerSync:
                    playerNumber = reader.ReadByte();
                    int MeleeDamageBoosts = reader.ReadInt32();

                    Player meleeplayer = Main.player[playerNumber];
                    meleeplayer.GetModPlayer<DamageIncreasePlayerMelee>().damageBoostsMelee = MeleeDamageBoosts;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)MessageType.MeleeDamageIncreasePlayerSync);
                        packet.Write(playerNumber);
                        packet.Write(MeleeDamageBoosts);
                        packet.Send(-1, playerNumber);
                    }
                    break;

                case MessageType.RangedDamageIncreasePlayerSync:
                    playerNumber = reader.ReadByte();
                    int RangedDamageBoosts = reader.ReadInt32();

                    Player rangedplayer = Main.player[playerNumber];
                    rangedplayer.GetModPlayer<DamageIncreasePlayerRanged>().damageBoostsRanged = RangedDamageBoosts;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)MessageType.RangedDamageIncreasePlayerSync);
                        packet.Write(playerNumber);
                        packet.Write(RangedDamageBoosts);
                        packet.Send(-1, playerNumber);
                    }
                    break;

                case MessageType.MagicDamageIncreasePlayerSync:
                    playerNumber = reader.ReadByte();
                    int MagicDamageBoosts = reader.ReadInt32();

                    Player magicplayer = Main.player[playerNumber];
                    magicplayer.GetModPlayer<DamageIncreasePlayerMelee>().damageBoostsMelee = MagicDamageBoosts;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)MessageType.MagicDamageIncreasePlayerSync);
                        packet.Write(playerNumber);
                        packet.Write(MagicDamageBoosts);
                        packet.Send(-1, playerNumber);
                    }
                    break;

                case MessageType.SummonDamageIncreasePlayerSync:
                    playerNumber = reader.ReadByte();
                    int SummonDamageBoosts = reader.ReadInt32();

                    Player summonplayer = Main.player[playerNumber];
                    summonplayer.GetModPlayer<DamageIncreasePlayerMelee>().damageBoostsMelee = SummonDamageBoosts;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)MessageType.SummonDamageIncreasePlayerSync);
                        packet.Write(playerNumber);
                        packet.Write(SummonDamageBoosts);
                        packet.Send(-1, playerNumber);
                    }
                    break;


                case MessageType.ExampleTeleportToStatue:
					if (Main.npc[reader.ReadByte()].ModNPC is ExamplePerson person && person.NPC.active) {
						person.StatueTeleport();
					}

					break;
					
				case MessageType.ExampleDodge:
					ExampleDamageModificationPlayer.HandleExampleDodgeMessage(reader, whoAmI);
					break;
					
				case MessageType.ExampleTownPetUnlockOrExchange:
					// Call a custom function that we made in our License item.
					ExampleTownPetLicense.ExampleTownPetUnlockOrExchangePet(ref ExampleTownPetSystem.boughtExampleTownPet, ModContent.NPCType<Content.NPCs.TownPets.ExampleTownPet>(), ModContent.GetInstance<ExampleTownPetLicense>().GetLocalizationKey("LicenseExampleTownPetUse"));
					break;

				case MessageType.ExampleResourceEffect:
					ExampleResourcePlayer.HandleExampleResourceEffectMessage(reader, whoAmI);
					break;

				default:
					Logger.WarnFormat("ExampleMod: Unknown Message type: {0}", msgType);
					break;
					
			}
		}
	}
}