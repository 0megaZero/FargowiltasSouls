using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class NebulaEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Enchantment");
            Tooltip.SetDefault(
                @"'The pillars of creation have shined upon you'
Hurting enemies has a chance to spawn buff boosters
Maintain maxed buff boosters for 5 seconds to gain drastically increased magic attack speed");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 400000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoPlayer>(mod).NebulaEffect();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NebulaHelmet);
            recipe.AddIngredient(ItemID.NebulaBreastplate);
            recipe.AddIngredient(ItemID.NebulaLeggings);
            
            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(ItemID.WingsNebula);
                recipe.AddIngredient(thorium.ItemType("BlackStaff"));
                recipe.AddIngredient(thorium.ItemType("CatsEye"));
                recipe.AddIngredient(thorium.ItemType("NebulaReflection"));
            }
            else
            {
                recipe.AddIngredient(ItemID.ShadowbeamStaff);
            }
            
            recipe.AddIngredient(ItemID.NebulaArcanum);
            recipe.AddIngredient(ItemID.NebulaBlaze);
            recipe.AddIngredient(ItemID.LunarFlareBook);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
