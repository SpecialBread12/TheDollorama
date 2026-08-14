using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheDollorama.Common.Systems;
using TheDollorama.Content.Items.Armor;

namespace TheDollorama.Content.Items.Consumables
{
	public class DollaramaBox : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(130, 65, 0),
				new Color(120, 70, 0),
				new Color(140, 60, 0)
			};
		}

		public override void SetDefaults() {
			Item.width = 10;
			Item.height = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Grab;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			//Item.value = Item.buyPrice(gold: 1);
		}

        public override bool? UseItem(Player player)
        {
            List<int> pool = new List<int>();

            // Toujours disponibles
            pool.Add(ItemID.Wood);
            pool.Add(ItemID.TinOre);
            pool.Add(ItemID.CopperOre);
            pool.Add(ItemID.IronOre);
            pool.Add(ItemID.LeadOre);
            pool.Add(ItemID.SilverOre);
            pool.Add(ItemID.TungstenOre);
            pool.Add(ItemID.GoldOre);
            pool.Add(ItemID.PlatinumOre);


            pool.Add(ModContent.ItemType<FourFun>());

            // Après Le Supervisor
            if (DownedBossSystem.downedSupervisor)
            {
                pool.Add(ItemID.DemoniteOre);
                pool.Add(ModContent.ItemType<CutPotion>());
                pool.Add(ModContent.ItemType<SupervisorHelmet>());
                pool.Add(ModContent.ItemType<SupervisorLeggings>());
                pool.Add(ModContent.ItemType<SupervisorBreastplate>());
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
                pool.Add(ItemID.CobaltOre);
                pool.Add(ItemID.PalladiumOre);
                pool.Add(ItemID.MythrilOre);
                pool.Add(ItemID.OrichalcumOre);
                pool.Add(ItemID.TitaniumOre);
                pool.Add(ItemID.AdamantiteOre);
            }

            // Choisir un objet au hasard
            int chosenItem = pool[Main.rand.Next(pool.Count)];

            // Quantité (optionnelle)
            //int amount = Main.rand.Next(1, 4);

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), chosenItem, 1);

            return true;
        }
    }
}
