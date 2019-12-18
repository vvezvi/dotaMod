using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.weapons
{

	public class Daedalus : ModItem
	{

		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("A weapon of incredible power that is difficult for even the strongest of warriors to control.");

        }

		public override void SetDefaults()
		{

			item.damage = 40;
			item.ranged = true;
			item.width = 52;
			item.height = 20;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = 300000;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 11f;
			item.useAmmo = AmmoID.Arrow;
            item.crit = 50;

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            type = mod.ProjectileType("DaedalusArrowProjectile");

            return true;

        }

	}

}
