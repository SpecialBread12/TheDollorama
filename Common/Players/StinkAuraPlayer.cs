using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheDollorama.Content.Items.Consumables;

namespace TheDollorama.Common.Players
{
	public class StinkAuraPlayer : ModPlayer
    {
            public bool cloudAura;
            private int auraTimer;

            public override void ResetEffects()
            {
                cloudAura = false;
            }

            public override void PostUpdate()
            {
                if (!cloudAura)
                    return;

                auraTimer++;

                
                if (auraTimer >= 30) // toutes les 0,5 seconde
                {
                    auraTimer = 0;

                    float auraRadius = 180f;
                    int damage = 3;

                    // Tous les NPC
                    foreach (NPC target in Main.ActiveNPCs)
                    {
                        if (target.dontTakeDamage || target.life <= 0)
                            continue;

                        if (Vector2.Distance(Player.Center, target.Center) <= auraRadius)
                        {
                            target.SimpleStrikeNPC(
                                damage,
                                hitDirection: target.Center.X < Player.Center.X ? -1 : 1
                            );
                        }
                    }
                for (int i = 0; i < 3; i++)
                {
                    Vector2 pos = Player.Center + Main.rand.NextVector2Circular(200f, 200f);
                    Dust.NewDustPerfect(pos, DustID.Smoke);
                }
                /*
                does a circle that indicate the range
                for (int i = 0; i < 8; i++)
                {
                    float angle = MathHelper.TwoPi * i / 8f + Main.GameUpdateCount * 0.03f;
                    Vector2 offset = angle.ToRotationVector2() * auraRadius;

                    Dust dust = Dust.NewDustPerfect(Player.Center + offset, DustID.CorruptSpray);
                    dust.noGravity = true;
                    dust.velocity = Vector2.Zero;
                }
                */
                // Tous les joueurs (y compris le porteur)
                foreach (Player other in Main.ActivePlayers)
                    {
                        if (other.dead)
                            continue;
                    if (other.whoAmI == Player.whoAmI)
                        continue;

                    if (Vector2.Distance(Player.Center, other.Center) <= auraRadius)
                        {
                            other.Hurt(
                                PlayerDeathReason.ByCustomReason($"{other.name} was consumed by a toxic cloud."),
                                damage,
                                other.Center.X < Player.Center.X ? -1 : 1
                            );
                        }
                    }
                }
            }
        }

    }
