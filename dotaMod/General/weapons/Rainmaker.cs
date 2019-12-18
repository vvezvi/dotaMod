using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.weapons
{

	public class Rainmaker : ModItem
	{

		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("This bow is crafted from the wood of the tallest tree in all of the Western forests. It is said that the tree's branches reach the rain clouds, giving the bow its power");

        }

		public override void SetDefaults()
		{

			item.damage = 40;
			item.ranged = true;
			item.width = 28;
			item.height = 70;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = 220000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 13f;
			item.useAmmo = AmmoID.Arrow;

        }

		public override void AddRecipes()
		{

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(751, 50);//Cloud
            recipe.AddIngredient(765, 25);//RainCloud
            recipe.AddIngredient(832, 1);//Living Wood Wand
            recipe.AddIngredient(1244, 1);//Nimbus Rod
            recipe.AddTile(305);//Sky Mill
			recipe.SetResult(this);
			recipe.AddRecipe();

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            type = mod.ProjectileType("RainmakerArrowProjectile");

            return true;

        }

	}

}
