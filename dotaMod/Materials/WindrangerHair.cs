using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.Materials
{
    public class WindrangerHair : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Hair");
            Tooltip.SetDefault("A hair of one blessed by the wind. A surprisingly strong and durable material.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.value = 1000;
            item.rare = 7;
        }
    }
}