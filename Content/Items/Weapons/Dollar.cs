using TheDollorama.Content.Projectiles;
using TheDollorama.Content.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Weapons
{
    public class Dollar : ModItem
    {
        public override void SetDefaults()
        {
            //Item.value = Item.buyPrice(silver: 1);
           
            Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 500; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = 10;
            Item.shoot = ProjectileID.GoldCoin;

            //Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 10f;
            Item.rare = ItemRarityID.Purple;
            Item.value = 1000000;
        }
        /*
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 10)
                .AddTile<Tiles.Furniture.CommonDolloWorkbench>()
                .Register();
        }
        */
    }
}