using dotaMod.General.projectilestuffs.minions;
using dotaMod.General.accessories;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.Buffs
{

    public class WindrangerBuff : ModBuff
    {

        public override void SetDefaults() {

            DisplayName.SetDefault("WINDRANGER!");
            Description.SetDefault("Windranger spreads for you!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<General.projectilestuffs.minions.WindrangerCape>()] < 1)
            {

                int k;
                for (k = 3; k < 8 + player.extraAccessorySlots; k++)
                {
                    if (player.armor[k].type == ItemType<WindwaifuBottle>())
                    {
                        break;
                    }
                }
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ProjectileType<WindrangerCape>(), player.GetWeaponDamage(player.armor[k]), player.GetWeaponKnockback(player.armor[k], 2f), player.whoAmI);

            }
            if (!modPlayer.windrangerCapeMinion)
            {

                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {

                player.buffTime[buffIndex] = 18000;

            }

        }

    }

}