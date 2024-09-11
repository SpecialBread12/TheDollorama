using TheDollorama.Content.Buffs;
using TheDollorama.Content.Items.Accessories;
using TheDollorama.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Common.Players
{
	internal class ExampleDamageModificationPlayer : ModPlayer
	{
		public float AdditiveCritDamageBonus;

		// These 3 fields relate to the Example Dodge. Example Dodge is modeled after the dodge ability of the Hallowed armor set bonus.
		// exampleDodge indicates if the player actively has the ability to dodge the next attack. This is set by ExampleDodgeBuff, which in this example is applied by the HitModifiersShowcase weapon. The buff is only applied if exampleDodgeCooldown is 0 and will be cleared automatically if an attack is dodged or if the player is no longer holding HitModifiersShowcase.
		public bool exampleDodge; // TODO: Example of custom player render
		// Used to add a delay between Example Dodge being consumed and the next time the dodge buff can be acquired.
		public int exampleDodgeCooldown;
		// Controls the intensity of the visual effect of the dodge.
		public int exampleDodgeVisualCounter;

		// If this player has an accessory which gives this effect
		public bool hasAbsorbTeamDamageEffect;
		// If the player is currently in range of a player with hasAbsorbTeamDamageEffect
		public bool defendedByAbsorbTeamDamageEffect;

		public bool exampleDefenseDebuff;

		public override void PreUpdate() {
			// Timers and cooldowns should be adjusted in PreUpdate
			if (exampleDodgeCooldown > 0) {
				exampleDodgeCooldown--;
			}
		}

		public override void ResetEffects() {
			AdditiveCritDamageBonus = 0f;

			exampleDodge = false;

			hasAbsorbTeamDamageEffect = false;
			defendedByAbsorbTeamDamageEffect = false;

			exampleDefenseDebuff = false;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
			if (AdditiveCritDamageBonus > 0) {
				modifiers.CritDamage += AdditiveCritDamageBonus;
			}
		}

		public override void PostUpdateEquips() {
			// If the conditions for the player having the buff are no longer true, remove the buff.
			// This could could technically go in ExampleDodgeBuff.Update, but typically these effects are given by armor or accessories, so showing this example here is more useful.
			/*
			if (exampleDodge && Player.HeldItem.type != ModContent.ItemType<HitModifiersShowcase>()) {
				Player.ClearBuff(ModContent.BuffType<ExampleDodgeBuff>());
			}
			*/
			// exampleDodgeVisualCounter should be updated here, not in DrawEffects, to work properly
			exampleDodgeVisualCounter = Math.Clamp(exampleDodgeVisualCounter + (exampleDodge ? 1 : -1), 0, 30);
		}

		public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			// exampleDodgeVisualCounter helps fade the color effect in and out.
			if (exampleDodgeVisualCounter > 0) {
				g = Math.Max(0, g - exampleDodgeVisualCounter * 0.03f);
			}

			if (exampleDefenseDebuff) {
				// These color adjustments match the withered armor debuff visuals.
				g *= 0.5f;
				r *= 0.75f;
			}
		}

		public override bool ConsumableDodge(Player.HurtInfo info) {
			if (exampleDodge) {
				ExampleDodgeEffects();
				return true;
			}

			return false;
		}

		// ExampleDodgeEffects() will be called from ConsumableDodge and HandleExampleDodgeMessage to sync the effect.
		public void ExampleDodgeEffects() {
			Player.SetImmuneTimeForAllTypes(Player.longInvince ? 120 : 80);

			// Some sound and visual effects
			for (int i = 0; i < 50; i++) {
				Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
				Dust d = Dust.NewDustPerfect(Player.Center + speed * 16, DustID.BlueCrystalShard, speed * 5, Scale: 1.5f);
				d.noGravity = true;
			}
			SoundEngine.PlaySound(SoundID.Shatter with { Pitch = 0.5f });

			// The visual and sound effects happen on all clients, but the code below only runs for the dodging player 
			if (Player.whoAmI != Main.myPlayer) {
				return;
			}

			// Clearing the buff and assigning the cooldown time
			Player.ClearBuff(ModContent.BuffType<ExampleDodgeBuff>());
			exampleDodgeCooldown = 180; // 3 second cooldown before the buff can be given again.

			if (Main.netMode != NetmodeID.SinglePlayer) {
				SendExampleDodgeMessage(Player.whoAmI);
			}
		}

		public static void HandleExampleDodgeMessage(BinaryReader reader, int whoAmI) {
			int player = reader.ReadByte();
			if (Main.netMode == NetmodeID.Server) {
				player = whoAmI;
			}

			Main.player[player].GetModPlayer<ExampleDamageModificationPlayer>().ExampleDodgeEffects();

			if (Main.netMode == NetmodeID.Server) {
				// If the server receives this message, it sends it to all other clients to sync the effects.
				SendExampleDodgeMessage(player);
			}
		}

		public static void SendExampleDodgeMessage(int whoAmI) {
			// This code is called by both the initial 
			ModPacket packet = ModContent.GetInstance<TheDollorama>().GetPacket();
			packet.Write((byte)TheDollorama.MessageType.ExampleDodge);
			packet.Write((byte)whoAmI);
			packet.Send(ignoreClient: whoAmI);
		}
	}
}
