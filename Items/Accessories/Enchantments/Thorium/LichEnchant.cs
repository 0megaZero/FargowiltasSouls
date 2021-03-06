using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class LichEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lich Enchantment");
            Tooltip.SetDefault(
                @"'Embrace death...'
Non-critical throwing damage applies Ichor to hit enemies
Pressing the Special Ability key will trigger True Strikes. Needs to recharge for 2 minutes after being activated");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            LichEffect(player);
        }
        
        private void LichEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "LichCowl",
            "LichCarapace",
            "LichTalon",
            "LichGaze",
            "RocketFist",
            "SoulCleaver",
            "DeathGrip",
            "CadaverCornet"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));
            
            recipe.AddIngredient(thorium.ItemType("TitanJavelin"), 300);
            recipe.AddIngredient(thorium.ItemType("PumpkinPaint"));
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
