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

        int windDodgeChance = 50; //Chance for the dodge to initiate (in %)
        int windDodgeTime = 40; //Duration of the immunity frames after dodging (in ticks [60 tps])

        public bool windrangerCapeMinion;
        public bool lunaMinion;
        public bool invokerMinion;
        public bool maidenMinionMinion;

        public override void ResetEffects() {

            windrangerCapeMinion = false;
            lunaMinion = false;
            invokerMinion = false;
            maidenMinionMinion = false;

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

            if (maidenMinionMinion == true)
            {

                player.AddBuff(BuffType<Buffs.MaidenBuff>(), 60, true);

            }

            /*
            if (axeMinion == true)
            {  

                player.AddBuff(BuffType<Buffs.AxeBuff>(), 60, true);        //Worst hero

            }
            */

        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {

            Random rand = new Random();
            int randNum = rand.Next(100);
            if (windrangerCapeMinion == true && randNum < windDodgeChance) {

                    player.immune = true;
                    player.immuneTime = windDodgeTime;
                    return false;

            }
             
            return true; 

        }

    }
}
