using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class TitanEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Enchantment");
            Tooltip.SetDefault(
                @"'Infused with primordial energy'
while beneath 75 life: +15% magic damage and +6% magic critical strike chance
increased after hit invincibility
grants vision of enemy positions (Hunter Potion effect), attacks apply Granite Surge to hit enemies
+18% damage
Your symphonic damage will empower all nearby allies with: Damage Reduction II
16% increased critical strike chance. 10% increased critical strike damage
Clicking the Encase key will place you in an impenetrable shell
While encased, you cant use items or health potions, life regeneration is heavily reduced, and damage is nearly nullified
Leaving the shell will greatly lower your speed, damage reduction and damage briefly
Leaving the shell will prohibit the use of the shell again for 20 seconds");
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
            
            TitanEffect(player);
        }
        
        private void TitanEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "TitanHeadgear",
            "TitanHelmet",
            "TitanMask",
            "TitanBreastplate",
            "TitanGreaves",
            "CrystalEyeMask",
            "AbyssalShell",
            "TunePlayerDamageReduction",
            "Executioner",
            "KineticKnife"
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
