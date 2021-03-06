using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class DurasteelEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Durasteel Enchantment");
            Tooltip.SetDefault(
                @"'Masterfully forged by the Blacksmith'
+12% damage reduction
Magnetizes all loose items on the screen
15% increased movement speed
Landing on solid ground releases a powerful shockwave
The damage, knockback, and range of the shock wave is increased by the fall distance");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            DurasteelEffect(player);
        }
        
        private void DurasteelEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "OgreSandals",
            "DurasteelRepeater",
            "SpudBomber",
            "ThiefDagger",
            "SeaMine",
            "GreedyMagnet"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            recipe.AddIngredient(thorium.ItemType("DurasteelHelmet"));
            recipe.AddIngredient(thorium.ItemType("DurasteelChestplate"));
            recipe.AddIngredient(thorium.ItemType("DurasteelGreaves"));
            recipe.AddIngredient(null, "DarksteelEnchant");
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
