using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.weapons
{

	public class PeregrineFlight : ModItem
	{

        int _bird = 8;

		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Lyralei counts amongst her allies a number of winged hunters held aloft by mother wind.");

        }

		public override void SetDefaults()
		{

			item.damage = 89;
			item.ranged = true;
			item.width = 56;
			item.height = 96;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7;
			item.value = 220000;
			item.rare = -11;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Arrow;

        }

		public override void AddRecipes()
		{

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3467, 15);//Luminite Bars
            recipe.AddIngredient(3456, 10);//Vortex Fragments
            recipe.AddIngredient(320, 15);//Feather
            recipe.AddIngredient(2889, 1);//Golden Bird
            recipe.AddTile(412);//Ancient Manipulator
			recipe.SetResult(this);
			recipe.AddRecipe();

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if(_bird >= 8)//if the player has shot the bow X amount of times
            {

                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PeregrineFlightBird"), damage, knockBack, player.whoAmI);//Bird

                _bird = 0;

            }
            else
            {


                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);//Original Arrow

                _bird++;//increment the shot counter

            }

            return false; // return false because we don't want tmodloader to shoot projectile

        }

    }

}
