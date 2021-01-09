using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.accessories
{

    class InvokerCage : ModItem
    {
        
        public override void SetStaticDefaults()
        {

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            Tooltip.SetDefault("An Intricate cage designed to harness... Something.");

        }
        
        public override void SetDefaults()
        {

            item.width = 36;
            item.height = 36;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 30);
            item.rare = ItemRarityID.LightPurple;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            DotaPlayer modPlayer = player.GetModPlayer<DotaPlayer>();
            modPlayer.invokerMinionEquipped = true;

        }

    }

}