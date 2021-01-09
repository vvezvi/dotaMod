using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod
{

	public class DotaPlayer : ModPlayer
	{

        private const int WindDodgeChance = 50; //Chance for the dodge to initiate (in %)
        private const int WindDodgeTime = 40; //Duration of the immunity frames after dodging (in ticks [60 tps])

        public bool windrangerCapeMinionEquipped;
        public bool lunaMinionEquipped;
        public bool invokerMinionEquipped;
        public bool maidenMinionEquipped;
        public bool axeMinionEquipped;

        public override void ResetEffects() {
            windrangerCapeMinionEquipped = false;
            lunaMinionEquipped = false;
            invokerMinionEquipped = false;
            maidenMinionEquipped = false;
            axeMinionEquipped = false;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
            if (windrangerCapeMinionEquipped){
                player.AddBuff(BuffType<Buffs.WindrangerBuff>(), 60, true);
            }
            if (lunaMinionEquipped){
                player.AddBuff(BuffType<Buffs.LunaBuff>(), 60, true);
            }
            if (invokerMinionEquipped){
                player.AddBuff(BuffType<Buffs.InvokerBuff>(), 60, true);
            }
            if (maidenMinionEquipped){
                player.AddBuff(BuffType<Buffs.MaidenBuff>(), 60, true);
            }
            if (axeMinionEquipped){  
                player.AddBuff(BuffType<Buffs.AxeBuff>(), 60, true);
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool critical, ref bool customDamage, 
                                    ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            var randNum = new Random().Next(100);
            if (!windrangerCapeMinionEquipped || randNum >= WindDodgeChance) return true;
            player.immune = true;
            player.immuneTime = WindDodgeTime;
            return false;
        }

    }
}
