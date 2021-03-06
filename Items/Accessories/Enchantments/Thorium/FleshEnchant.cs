using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class FleshEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flesh Enchantment");
            Tooltip.SetDefault(
                @"'Symbiotically attached to your body'
Struck enemies might drop Suitable Flesh, which heals and grants +8% damage for 5 seconds
Your damage will have a 10% chance to cause an eruption of blood
This blood can be picked up by players to heal themselves for 15% of the damage you dealt 
Healing amount cannot exceed 15 life and picking up blood causes bleeding for 5 seconds
Summons an annoying blister to follow you around");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            FleshEffect(player);
        }
        
        private void FleshEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "FleshMask",
            "FleshBody",
            "FleshLegs",
            "FleshWings",
            "VampireGland",
            "GrimFlayer",
            "FleshMace",
            "BloodBelcher",
            "HungerStaff",
            "BlisterSack"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;

            //crimson
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
