using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.accessories
{

    class StackOfLatex : ModItem
    {
        
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("I came for ******, it'll be a good show!");

        }
        
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 30;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 30);
            item.rare = ItemRarityID.LightPurple;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            modPlayer.lunaMinion = true;

        }

    }

}