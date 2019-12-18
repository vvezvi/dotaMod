using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace dotaMod
{

	public class dotaPlayer : ModPlayer
	{

        public bool windrangerCapeMinion;
        public bool lunaMinion;
        public bool invokerMinion;

        public override void ResetEffects() {

            windrangerCapeMinion = false;
            lunaMinion = false;
            invokerMinion = false;

        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {

            if (windrangerCapeMinion == true)
            {

                player.AddBuff(BuffType<Buffs.WindrangerBuff>(), 60, true); //best buff

            }

            if (lunaMinion == true)
            {

                player.AddBuff(BuffType<Buffs.LunaBuff>(), 60, true); //penis

            }

            if (invokerMinion == true)
            {

                player.AddBuff(BuffType<Buffs.InvokerBuff>(), 60, true);

            }

            /*
            if (axeMinion == true)
            {  

                player.AddBuff(BuffType<Buffs.AxeBuff>(), 60, true);        //Worst hero

            }
            */

        }

    }
}
