//using TheDollorama.Content.Walls;
using Humanizer;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using TheDollorama.Content.Items.Accessories;

//using TheDollorama.Common.Configs;
//using TheDollorama.Content.Biomes;
//using TheDollorama.Content.EmoteBubbles;
//using TheDollorama.Content.Items.Accessories;
using TheDollorama.Content.Items.Consumables;
using TheDollorama.Content.Items.Weapons;

namespace TheDollorama.Content.NPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class K : ModNPC
    {
        private int auraTimer;
        private int collectedCoins;
        private int collectionRate = 10; // Le taux auquel les pièces sont collectées (ex. toutes les 1000 ticks)

        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;

        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25; // The total amount of frames the NPC has

            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
            NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 1; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 1; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.
            NPCID.Sets.ShimmerTownTransform[NPC.type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Connects this NPC with a custom emote.
            // This makes it when the NPC is in the world, other NPCs will "talk about him".
            // By setting this you don't have to override the PickEmote method for the emote to appear.
            //NPCID.Sets.FaceEmote[Type] = ModContent.EmoteBubbleType<ExamplePersonEmote>();

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.

                
                .SetNPCAffection(ModContent.NPCType<Dev>(), AffectionLevel.Hate)
            ; // < Mind the semicolon!

            // This creates a "profile" for ExamplePerson, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
            // SparklingBall is not affected by gravity, so gravityCorrection is left alone.
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = false; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 7;
            AnimationType = NPCID.TaxCollector;
        }

        public override void AI()
        {
            auraTimer++;

            if (auraTimer >= 15) // toutes les 30 frames (0,5 seconde)
            {
                auraTimer = 0;

                float auraRadius = 180f;
                int damage = 2;

                // JOUEURS
                foreach (Player player in Main.ActivePlayers)
                {
                    if (player.dead)
                        continue;

                    if (Vector2.Distance(NPC.Center, player.Center) <= auraRadius)
                    {
                        player.Hurt(
                            PlayerDeathReason.ByCustomReason($"{player.name} was consumed by the fish smell"),
                            damage,
                            player.Center.X < NPC.Center.X ? -1 : 1
                        );
                    }
                }

                // TOUS LES NPC (alliés et ennemis)
                foreach (NPC target in Main.ActiveNPCs)
                {
                    if (target.whoAmI == NPC.whoAmI)
                        continue;

                    if (target.dontTakeDamage || target.life <= 0)
                        continue;

                    if (Vector2.Distance(NPC.Center, target.Center) <= auraRadius)
                    {
                        target.SimpleStrikeNPC(
                            damage,
                            hitDirection: target.Center.X < NPC.Center.X ? -1 : 1
                        );
                    }
                }
                
                // 1 chance sur 1 000 000 chaque frame
                if (Main.rand.Next(1_000_000) == 0)
                {
                    SoundEngine.PlaySound(SoundID.Item38, NPC.Center);

                    // Message dans le chat
                    if (Main.netMode != NetmodeID.Server)
                    {
                        Main.NewText($"{NPC.GivenName} suddenly shot herself...", 200, 15, 210);
                    }
                    else
                    {
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(
                            Terraria.Localization.NetworkText.FromLiteral($"{NPC.GivenName} suddenly shot herself..."),
                            new Microsoft.Xna.Framework.Color(200, 15, 210)
                        );
                    }

                    // Tue instantanément le NPC
                    NPC.StrikeInstantKill();
                    return;
                }
                
            }

            // Effet visuel de l'aura (optionnel)
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = NPC.Center + Main.rand.NextVector2Circular(200f, 200f);
                Dust.NewDustPerfect(pos, DustID.Cloud);
            }

            // Collecte des pièces toutes les 'collectionRate' ticks
            if (Main.time % collectionRate == 0)
            {
                collectedCoins++;
            }
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();


            chat.Add(Language.GetTextValue("Leave me alone"));
            chat.Add(Language.GetTextValue("Isn't my cloud killing you, GET OUT"));
            chat.Add(Language.GetTextValue("You and your fucking face, you are useless, FUCK OFF"));
            chat.Add(Language.GetTextValue("Every second that come and go, I am closer to ending it"));
            string chosenChat = chat;
            return chosenChat;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Kelly-Ann"
            };
        }

        public override bool CanChat()
        {
            return true;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            // Convertir le montant total en pièces de cuivre, d'argent, d'or et de platine
            int platinum = collectedCoins / 1000000;
            int gold = (collectedCoins % 1000000) / 10000;
            int silver = (collectedCoins % 10000) / 100;
            int copper = collectedCoins % 100;

            // Afficher le montant collecté dans le texte du bouton
            button = "Collect" + $"[i/s{platinum}:{ItemID.PlatinumCoin}]" + $"[i/s{gold}:{ItemID.GoldCoin}]" + $"[i/s{silver}:{ItemID.SilverCoin}]" + $"[i/s{copper}:{ItemID.CopperCoin}]";




        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                Player player = Main.player[Main.myPlayer];

                // Si des pièces ont été collectées, les donner au joueur
                if (collectedCoins > 0)
                {
                    player.QuickSpawnItem(NPC.GetSource_GiftOrReward(), ItemID.PlatinumCoin, collectedCoins / 1000000);
                    player.QuickSpawnItem(NPC.GetSource_GiftOrReward(), ItemID.GoldCoin, (collectedCoins % 1000000) / 10000);
                    player.QuickSpawnItem(NPC.GetSource_GiftOrReward(), ItemID.SilverCoin, (collectedCoins % 10000) / 100);
                    player.QuickSpawnItem(NPC.GetSource_GiftOrReward(), ItemID.CopperCoin, collectedCoins % 100);

                    collectedCoins = 0; // Remet à zéro après transfert
                }
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        { // Requirements for the town NPC to spawn.
            foreach (var player in Main.ActivePlayers)
            {
                // Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
                if (player.inventory.Any(item => item.type == ModContent.ItemType<Depression>()))
                {
                    return true;
                }
            }

            return false;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StinkCloud>()));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("You can get a lot of money, but your soul will never be the same"),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("She don't really wash herself, might explain the deadly cloud around")
            });

        }
    }
}