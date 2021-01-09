using dotaMod.General.projectilestuffs.minions;
using dotaMod.General.accessories;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static dotaMod.General.projectilestuffs.minions.AxeMinion;

namespace dotaMod.Buffs
{

    public class AxeBuff : ModBuff
    {

        public override void SetDefaults() {

            DisplayName.SetDefault("Axe");
            Description.SetDefault("AXE IS A DUMB DUMB! AXE LIKES PUNCH!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            DotaPlayer modPlayer = player.GetModPlayer<DotaPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<General.projectilestuffs.minions.AxeMinion>()] < 1)
            {

                int k;
                for (k = 3; k < 8 + player.extraAccessorySlots; k++)
                {
                    if (player.armor[k].type == ItemType<LeafyLoincloth>())
                    {
                        break;
                    }
                }
                Projectile.NewProjectile(player.Center.X - 200, player.Center.Y - 200, 0f, 0f, ProjectileType<AxeMinion>(), player.GetWeaponDamage(player.armor[k]), player.GetWeaponKnockback(player.armor[k], 2f), player.whoAmI); ;

            }
            if (!modPlayer.axeMinionEquipped)
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