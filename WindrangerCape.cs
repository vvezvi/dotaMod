using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.projectilestuffs.minions      //PLEASE DON'T DELETE ME I LOVE YOU
{

    public class WindrangerCape : BaseMinion
    {

        public float velGain = 0.5f;
        public float maxVel = 4;
        public float yVelGain = 0.2f;
        public float yMaxVel = 0.8f;
        public float targetX;
        public float targetY;
        public float selfX;
        public float selfY;
        public float offset = 50;
        public float xOffset = 75;
        public bool initSelf = true;
        public bool yInPos = false;
        public bool xInPos = false;
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Daedalus Arrow");     //The English name of the projectile

        }

        public override void SetDefaults()
        {

            projectile.netImportant = true;
            projectile.width = 120;
            projectile.height = 196;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

        }

        public override void Behavior()
        {

            var rand = new Random();

            Player player = Main.player[projectile.owner];
            selfX = projectile.position.X;
            selfY = projectile.position.Y;
            if (initSelf == true) {

                targetX = player.position.X - 200;
                targetY = player.position.Y - 200;
                initSelf = false;

            }
            if ((targetX - xOffset) < selfX && selfX < (targetX + xOffset)) {

                targetX = player.position.X - 200;

            }
            if ((targetY - offset) < selfX && selfY < (targetY + offset) && yInPos == false) {

                targetY = player.position.Y - 200;

            }

            
            if (selfX < (targetX + xOffset))
            {

                projectile.spriteDirection = projectile.direction = 1;
                if (projectile.velocity.X > (maxVel - velGain))
                {

                    projectile.velocity.X = maxVel;

                }
                else if (projectile.velocity.X < 0)
                {

                    projectile.spriteDirection = projectile.direction = -1;
                    projectile.velocity.X += (velGain);

                }
                else
                {

                    projectile.velocity.X += velGain;

                }


            }
            if(selfX > (targetX - xOffset))
            {
                projectile.spriteDirection = projectile.direction = -1;
                if (projectile.velocity.X < (maxVel - velGain))
                {

                    projectile.velocity.X = -maxVel;

                }
                else if (projectile.velocity.X > 0)
                {

                    projectile.spriteDirection = projectile.direction = 1;
                    projectile.velocity.X -= (velGain);

                }
                else
                {

                    projectile.velocity.X -= velGain;

                }

            }

            if(yInPos == true)
            {
                if (projectile.velocity.Y > -0.2f && projectile.velocity.Y < 0.2f)
                {

                    projectile.velocity.Y = 0;
                    yInPos = false;

                }
                else if (projectile.velocity.Y > 0) {

                    projectile.velocity.Y -= (yVelGain*2);
                
                } else if (projectile.velocity.Y < 0) {

                    projectile.velocity.Y += (yVelGain * 2);

                }
                

            }
            else if (selfY < (targetY + offset) && selfY > (targetY - offset))
            {

                yInPos = true;
                

            }else if (selfY < (targetY + offset)) {
                
                if (projectile.velocity.Y < (yMaxVel - yVelGain))
                {

                    projectile.velocity.Y = yMaxVel;

                }
                else if (projectile.velocity.Y < 0)
                {

                    projectile.velocity.Y += (yVelGain);

                }
                else
                {

                    projectile.velocity.Y += yVelGain;

                }


            }
            else if (selfY > (targetY - offset))
            {
                if (projectile.velocity.Y > (yMaxVel - yVelGain))
                {

                    projectile.velocity.Y = -yMaxVel;

                }
                else if (projectile.velocity.Y > 0)
                {

                    projectile.velocity.Y -= (yVelGain);

                }
                else
                {

                    projectile.velocity.Y -= yVelGain;

                }

            }

        }

        public override void CheckActive()
        {

            Player player = Main.player[projectile.owner];
            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            if (player.dead)
            {

                modPlayer.windrangerCapeMinion = false;

            }
            if (modPlayer.windrangerCapeMinion)
            {

                projectile.timeLeft = 2;

            }

        }

    }

}
