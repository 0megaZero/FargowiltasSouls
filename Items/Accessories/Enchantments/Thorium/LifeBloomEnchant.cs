using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class LifeBloomEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Bloom Enchantment");
            Tooltip.SetDefault(
                @"'You are one with nature'
 Minion damage has a 33% chance to heal you slightly
 Your symphonic damage will empower all nearby allies with: Ammo Consumption II
 Pressing the 'Encase' key will place you within a fragile cocoon
You have greatly reduced damage reduction and increased aggro while within the cocoon
If you survive the process, your attack speed and damage are briefly increased significantly
The cocoon may be activated every 1 minute");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            LifeBloomEffect(player);
        }
        
        private void LifeBloomEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "LifeBloomMask",
            "LifeBloomMail",
            "LifeBloomLeggings",
            "FlawlessChrysalis",
            "TunePlayerAmmoConsume",
            "GroundedTotemCaller",
            "ButterflyStaff5",
            "HoneyBlade",
            "OdinsEye",
            "HiveMind"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;

            //living wood
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
