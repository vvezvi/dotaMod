using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace dotaMod.General.accessories
{

    class WindwaifuBottle : ModItem
    {
        
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Summons the best hero from Dota 2 to help you fight!");

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

            dotaPlayer modPlayer = player.GetModPlayer<dotaPlayer>();
            modPlayer.windrangerCapeMinion = true;

        }

    }

}