using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.accessories
{

    class GlacialChunk : ModItem
    {
        
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Ice isn't always nice!");

        }
        
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 30);
            item.rare = ItemRarityID.LightPurple;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            DotaPlayer modPlayer = player.GetModPlayer<DotaPlayer>();
            modPlayer.maidenMinionEquipped = true;

        }

    }

}