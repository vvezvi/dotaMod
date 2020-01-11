using dotaMod.General.projectilestuffs.minions;
using dotaMod.General.accessories;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.Buffs
{

    public class MaidenBuff : ModBuff
    {

        public override void SetDefaults() {

            DisplayName.SetDefault("CRYSTAL MAIDEN!");
            Description.SetDefault("One day, I'll return to the Blueheart Glaciers, and sleep for a thousand years!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<General.projectilestuffs.minions.MaidenMinion>()] < 1)
            {

                int k;
                for (k = 3; k < 8 + player.extraAccessorySlots; k++)
                {
                    if (player.armor[k].type == ItemType<GlacialChunk>())
                    {
                        break;
                    }
                }
                Projectile.NewProjectile(player.Center.X + 200, player.Center.Y - 200, 0f, 0f, ProjectileType<MaidenMinion>(), player.GetWeaponDamage(player.armor[k]), player.GetWeaponKnockback(player.armor[k], 2f), player.whoAmI);

            }
            if (!modPlayer.maidenMinionMinion)
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