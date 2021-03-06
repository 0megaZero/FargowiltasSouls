using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class TideTurnerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tide Turner Enchantment");
            Tooltip.SetDefault(
                @"''
Pressing the Special Ability key will activate Ocean’s Buffer, causing incoming non-lethal damage to become healing
thrown damage applies Granite Surge to hit enemies for 5 seconds
Throwing damage has a 33% chance to release homing tide daggers all around the player");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2; //blood orange
            item.value = 400000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            TideEffect(player);
        }
        
        private void TideEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "TideTurnerHelmet",
            "TideTurnersGaze",
            "TideTurnerBreastplate",
            "TideTurnerGreaves",
            "PoseidonCharge", 
            "MantisPunch",
            "QuakeGauntlet",
            "TidalWave",
            "OceansJudgment",
            "Trefork"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            //SolarEnchant, white dward
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
