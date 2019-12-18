using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.Materials
{
    public class PhoenixFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A feather of a fallen lesser phoenix.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.value = 50000;
            item.rare = 7;
        }
    }
}