using TheDollorama.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Consumables
{
	// This file showcases how to create an item that increases the player's maximum health on use.
	// Within your ModPlayer, you need to save/load a count of usages. You also need to sync the data to other players.
	// The overlay used to display the custom life fruit can be found in Common/UI/ResourceDisplay/VanillaLifeOverlay.cs
	internal class DamageBoosterSummon : ModItem
	{
        public static readonly int MaxDamageBoosts = 10;
        public static readonly float DamageIncreasePerBoost = 1000f; // 1% d'augmentation par utilisation

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncreasePerBoost * 100, MaxDamageBoosts);

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            //Item.value = 10000;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item4;
            Item.consumable = true;
            Item.maxStack = 999;
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<DamageIncreasePlayerSummon>().damageBoostsSummon < MaxDamageBoosts;
        }

        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<DamageIncreasePlayerSummon>().damageBoostsSummon >= MaxDamageBoosts)
            {
                return null;
            }

            // Augmente le compteur d'améliorations de dégâts du joueur
            player.GetModPlayer<DamageIncreasePlayerSummon>().damageBoostsSummon++;

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldCoin, 5)
                .AddIngredient(ModContent.ItemType<BoosterPack>())
                .AddTile<Tiles.Furniture.ExampleWorkbench>()
                .Register();
        }
    }
}
