using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.projectilestuffs.minions      //PLEASE DON'T DELETE ME I LOVE YOU
{

    public class LunaGlaiveSurfer : BaseMinion2
    {

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Daedalus Arrow");     //The English name of the projectile

        }

        public override void SetDefaults()
        {

            projectile.netImportant = true;
            projectile.width = 24;
            projectile.height = 32;
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

            aiType = ProjectileID.WoodenArrowFriendly;

        }

        public override void CheckActive()
        {

            Player player = Main.player[projectile.owner];
            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            if (player.dead)
            {

                modPlayer.lunaMinion = false;

            }
            if (modPlayer.lunaMinion)
            {

                projectile.timeLeft = 2;

            }

        }

    }

}
