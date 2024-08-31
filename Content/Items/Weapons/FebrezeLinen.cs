using TheDollorama.Content.Projectiles;
using TheDollorama.Content.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheDollorama.Content.Items.Weapons
{
    public class FebrezeLinen : ModItem
    {
        public override void SetDefaults()
        {
           
            Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

            Item.DamageType = ModContent.GetInstance<SprayDamage>(); // Sets the damage type to ranged.
            Item.damage = 25; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = 10;
            Item.shoot = ModContent.ProjectileType<Spray>();

            //Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.Green;
            Item.value = 1000000;
        }
        /*
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ExampleItem>()
                .AddTile<Tiles.Furniture.ExampleWorkbench>()
                .Register();
        }
        */
    }
}