using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheDollorama.Content.Buffs;
using TheDollorama.Content.Items.Consumables;

namespace TheDollorama.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class DolloramaBreastplate : ModItem
	{
		public static readonly int MaxManaIncrease = 20;


        //public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxManaIncrease, MaxMinionIncrease);
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

            //SetBonusText = this.GetLocalization("SetBonus");
        }

        public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 8; // The amount of defense the item will give when equipped
		}
        
        public override void UpdateArmorSet(Player player)
        {
            if (player.armor[2].type == ModContent.ItemType<DolloramaLeggings>())
            {
                player.setBonus = "3 defense and Immunity to cuts";
                player.buffImmune[ModContent.BuffType<Cuts>()] = true;
                player.statDefense += 3;
            }
        }
       
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return legs.type == ModContent.ItemType<DolloramaLeggings>();
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ModContent.ItemType<CutPotion>(), 1)
                .AddIngredient(ItemID.GoldCoin, 14)
                .AddTile<Tiles.Furniture.CommonDolloWorkbench>()
				.Register();
		}
	}
}
