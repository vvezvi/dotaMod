using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.projectilestuffs.projectiles
{

	public class RainmakerArrowProjectile : ModProjectile
	{

        

		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Rainmaker Arrow");     //The English name of the projectile

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
            projectile.light = 0.5f;
            aiType = ProjectileID.WoodenArrowFriendly;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            Player p = Main.player[projectile.owner];

            Random rnd = new Random();
            int output = rnd.Next(100);

            if (output <= 9)
            {

                int rain = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 90, 0, 0, ProjectileID.RainCloudRaining, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                   // Main.projectile[rain].timeleft = 600;
                   // Main.projectile[rain].netUpdate = true;
                    //projectile.netUpdate = true;

            }

        }

	}

}
