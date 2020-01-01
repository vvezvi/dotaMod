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
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Daedalus Arrow");     //The English name of the projectile
            Main.projFrames[projectile.type] = 4;

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

            float velGain = 0.5f;
            float maxVel = 6;
            float targetX;
            float targetY;
            float selfX;
            float selfY;

            Player player = Main.player[projectile.owner];
            targetX = player.position.X - 200;
            targetY = player.position.Y - 200;
            selfX = projectile.position.X;
            selfY = projectile.position.Y;
            //Main.NewText("I have set targets: X=" + targetX + "Y=" + targetY + "selfX=" + selfX);
            //Main.NewText("My Velocity X=" + projectile.velocity.X + "Y=" + projectile.velocity.Y);
            if (selfX < targetX)
            {
                //Main.NewText("I am larger");
                projectile.spriteDirection = projectile.direction = 1;
                if (projectile.velocity.X > (maxVel - velGain))
                {

                    projectile.velocity.X = maxVel;

                }
                else if (projectile.velocity.X < 0)
                {

                    projectile.spriteDirection = projectile.direction = -1;
                    projectile.velocity.X += (velGain / 4);

                }
                else
                {

                    projectile.velocity.X += velGain;

                }


            }
            else
            {
                //Main.NewText("I am smaller");
                projectile.spriteDirection = projectile.direction = -1;
                if (projectile.velocity.X < (maxVel - velGain))
                {

                    projectile.velocity.X = -maxVel;

                }
                else if (projectile.velocity.X > 0)
                {

                    projectile.spriteDirection = projectile.direction = 1;
                    projectile.velocity.X -= (velGain / 4);

                }
                else
                {

                    projectile.velocity.X -= velGain;

                }

            }

            if (selfY < targetY)
            {
                //Main.NewText("I am high");
                if (projectile.velocity.Y > (maxVel - velGain))
                {

                    projectile.velocity.Y = maxVel;

                }
                else if (projectile.velocity.Y < 0)
                {

                    projectile.velocity.Y += (velGain / 4);

                }
                else
                {

                    projectile.velocity.Y += velGain;

                }


            }
            else
            {
                //Main.NewText("I am low");
                if (projectile.velocity.Y < (maxVel - velGain))
                {

                    projectile.velocity.Y = -maxVel;

                }
                else if (projectile.velocity.Y > 0)
                {

                    projectile.spriteDirection = projectile.direction = 1;
                    projectile.velocity.Y -= (velGain / 4);

                }
                else
                {

                    projectile.velocity.Y -= velGain;

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
            
        //stay on each frame for 20 ticks, then cycle to next frame. 

        public override void ChooseFrame()
        {
            if (++projectile.frameCounter >= 20)        
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)            
                {
                    projectile.frame = 0;
                }
            }
        }

    }

}
