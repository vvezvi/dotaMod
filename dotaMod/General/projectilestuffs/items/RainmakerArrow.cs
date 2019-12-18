using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.projectilestuffs.items
{

	public class RainmakerArrow : ModItem
	{
        
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("The arrows used in the Rainmaker bow. You shouldn't have this...");

		}

		public override void SetDefaults()
		{

			item.damage = 13;
			item.ranged = true;
			item.width = 7;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1f;
			item.value = 10;
			item.rare = 6;
			item.shoot = mod.ProjectileType("RainmakerArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 11f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.

		}

	}

}
