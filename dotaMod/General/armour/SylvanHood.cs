using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace dotaMod.General.armour
{
	[AutoloadEquip(EquipType.Head)]
	public class SylvanHood : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sylvan Hood");
            Tooltip.SetDefault("An ancient hood, once worn by a master archer."
                + "\n+25% critical strike chance"
                + "\n+10% ranged damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 45;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("Sylvan Hood") && legs.type == mod.ItemType("Sylvan Leggings");
		}

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.1f;
            player.rangedCrit += 10;
        }

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You feel one with the wind - +25% ranged damage, +3 minions, and your arrows fly true.";
			player.AddBuff(BuffID.Archery, 2);
            player.rangedDamage += .25f;
            player.maxMinions += 3;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EquipMaterial", 30);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}