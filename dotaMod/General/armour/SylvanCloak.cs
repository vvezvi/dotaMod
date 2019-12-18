using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.armour
{
	[AutoloadEquip(EquipType.Body)]
	public class SylvanCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Sylvan Cloak");
			Tooltip.SetDefault("An old battle cloak, once worn by a master archer."
				+ "\nImmunity to 'On Fire!'"
				+ "\n+100 max mana, +35% ranged damage and +1 max minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 98;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
			player.statManaMax2 += 100;
			player.maxMinions++;
            player.rangedDamage += .35f;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EquipMaterial", 60);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}