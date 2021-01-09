using Terraria;

namespace dotaMod.General.projectilestuffs.minions
{

    public class LunaMinion : BaseMinion
    {

        private int _alternating;
        private int _ticksPerTurn = 25;
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Luna on a Glaive");
        }

        public override void SetDefaults(){
            _alternating = 0;
            
            projectile.netImportant = true;
            projectile.width = 86;
            projectile.height = 212;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void Behavior(){
            if (_alternating == _ticksPerTurn){
                projectile.spriteDirection *= -1;
                projectile.direction = projectile.spriteDirection;
                _alternating = 0;
                if (_ticksPerTurn > 0){
                    _ticksPerTurn--;
                }
            }else{
                _alternating++;
            }
            //TODO Attack and Movement
        }

        public override void CheckActive(){
            var player = Main.player[projectile.owner];
            var modPlayer = player.GetModPlayer<DotaPlayer>();
            if (player.dead){
                modPlayer.lunaMinionEquipped = false;
            }else if (modPlayer.lunaMinionEquipped){
                projectile.timeLeft = 2;
            }
        }

    }
}
