using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class MagmaEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Enchantment");
            Tooltip.SetDefault(
                @"'Bursting with heat'
Inflicts fire damage on melee attack (Magma Stone effect)
Increases effectiveness of On Fire! and Singe debuffs
Allows you to do a triple hop super jump. Increases fall resistance
15% increased movement and maximum speed. Damaging slag drops from below your boots
Spear weapons will release a flaming spear tip");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 60000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            MagmaEffect(player);
        }
        
        private void MagmaEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            
            
        }
        
        private readonly string[] items =
        {
            "MagmaHelmet",
            "MagmaChestGuard",
            "MagmaGreaves",
            "SpringSteps",
            "SlagStompers",
            "MoltenSpearTip",
            "MagmaShiv",
            "MagmaPolearm",
            "MagmaticRicochet",
            "MagmaFlail"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
