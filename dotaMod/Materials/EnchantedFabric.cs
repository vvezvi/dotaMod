using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.Materials
{
    public class EnchantedFabric : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A piece of fabric historically woven by those residing in the Western Forest village of Zaru'Kina.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.value = 50000;
            item.rare = 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(225, 5);               //Silk 
            recipe.AddIngredient(1006, 1);              //Chlorophyte Bar
            recipe.AddTile(86);                         //Loom
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}