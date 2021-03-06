using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class TerrariumEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrarium Enchantment");
            Tooltip.SetDefault(
                @"'All will fall before your might...'
Grants night vision
Colourful homing spirits appear that deal damage and inflict a variety of debuffs on enemies
Your symphonic damage empowers all nearby allies with: Terrarian. Increases symphonic damage by 10%. Doubles the range of your empowerments effect radius.
infinite terrarium mix meme");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2; //rainbow
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            TerrariumEffect(player);
        }
        
        private void TerrariumEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "TerrariumHelmet",
            "TerrariumBreastPlate",
            "TerrariumGreaves",
            "TerrariumSubwoofer",
            "EssenceofFlame",
            "SearingBlade",
            "TerrariumSaber",
            "SickThrow",
            "TerrariumLongbow",
            "TerrariumBomber"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
