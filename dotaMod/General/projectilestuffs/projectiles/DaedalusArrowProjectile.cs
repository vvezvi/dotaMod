using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.projectilestuffs.projectiles
{

	public class DaedalusArrowProjectile : ModProjectile
	{
        
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Daedalus Arrow");     //The English name of the projectile

        }

		public override void SetDefaults()
		{

            projectile.arrow = true;
            projectile.width = 7;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.light = 0f;
            aiType = ProjectileID.WoodenArrowFriendly;

        }

	}

}
