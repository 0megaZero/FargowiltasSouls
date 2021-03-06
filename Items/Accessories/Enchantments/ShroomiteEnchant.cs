using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class ShroomiteEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Enchantment");
            Tooltip.SetDefault(
                @"'Made with real shrooms!'
Not moving puts you in stealth
While in stealth crits deal 4x damage and spores spawn on enemies
Summons a pet Baby Truffle"); //screw spores honestly
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoPlayer>(mod).ShroomiteEffect(hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("FargowiltasSouls:AnyShroomHead");
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.MushroomSpear);
            recipe.AddIngredient(ItemID.Hammush);
            
            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("MyceliumGattlingPulser"));
                recipe.AddIngredient(ItemID.ChlorophyteShotbow);
                recipe.AddIngredient(ItemID.Uzi);
                recipe.AddIngredient(thorium.ItemType("ShroomiteButterfly"));
            }
            else
            {
                recipe.AddIngredient(ItemID.Uzi);
            }
            
            recipe.AddIngredient(ItemID.StrangeGlowingMushroom);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
