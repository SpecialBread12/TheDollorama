using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDollorama.Common.Systems;

namespace TheDollorama.Content.Items.Consumables
{
	public class DollaramaBox : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(240, 0, 0),
				new Color(200, 0, 0),
				new Color(140, 0, 0)
			};
		}

		public override void SetDefaults() {
			Item.width = 10;
			Item.height = 15;
			Item.useStyle = ItemUseStyleID.Guitar;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Roar;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<Buffs.Depressed>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 3000; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

        public override bool? UseItem(Player player)
        {
            List<int> pool = new List<int>();

            // Toujours disponibles
            pool.Add(ItemID.Wood);
            pool.Add(ItemID.IronBar);
            pool.Add(ModContent.ItemType<CutPotion>());
            pool.Add(ModContent.ItemType<FourFun>());

            // Après Le Supervisor
            if (DownedBossSystem.downedSupervisor)
            {
                pool.Add(ItemID.DemoniteBar);
                //pool.Add(ModContent.ItemType<MyModItem2>());
            }

            // Après Skeletron
            if (NPC.downedBoss3)
            {
                pool.Add(ItemID.Bone);
                //pool.Add(ModContent.ItemType<MyModItem3>());
            }

            // Hardmode
            if (Main.hardMode)
            {
                pool.Add(ItemID.CobaltBar);
                pool.Add(ItemID.MythrilBar);
                //pool.Add(ModContent.ItemType<MyModHardmodeItem>());
            }

            // Choisir un objet au hasard
            int chosenItem = pool[Main.rand.Next(pool.Count)];

            // Quantité (optionnelle)
            int amount = Main.rand.Next(1, 4);

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), chosenItem, amount);

            return true;
        }
    }
}
