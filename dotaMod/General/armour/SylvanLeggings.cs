using Terraria;
using Terraria.ModLoader;

namespace dotaMod.General.armour
{
	[AutoloadEquip(EquipType.Legs)]
	public class SylvanLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sylvan Leggings");
            Tooltip.SetDefault("Leggings blessed by the wind, once worn by a master archer."
				+ "\n20% increased movement speed"
                + "\n25% increased ranged damage"
                + "\n10% increased critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 75;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
            player.rangedDamage += 0.25f;
            player.rangedCrit += 10;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EquipMaterial", 45);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}