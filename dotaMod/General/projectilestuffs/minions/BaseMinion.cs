using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.projectilestuffs.minions
{

    public abstract class BaseMinion : ModProjectile
    {

		public override void AI()
		{
			CheckActive();
			Behavior();
			ChooseFrame();
			SpawnDust();
		}

		public abstract void CheckActive();

		public abstract void Behavior();

		public virtual void ChooseFrame() { }

		public virtual void SpawnDust() { }

	}

}
