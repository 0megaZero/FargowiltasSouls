using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class SilverEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Enchantment");
            Tooltip.SetDefault(
                @"'Have you power enough to wield me?'
Summons a sword familiar that scales with minion damage");

//While in combat, you generate a 14 life shield
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 30000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            modPlayer.SilverEnchant = true;
            modPlayer.AddMinion("Silver Sword Familiar", mod.ProjectileType("SilverSword"), (int) (20 * player.minionDamage), 0f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverHelmet);
            recipe.AddIngredient(ItemID.SilverChainmail);
            recipe.AddIngredient(ItemID.SilverGreaves);

            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("SilverBulwark"));
                
                recipe.AddIngredient(ItemID.SilverBroadsword);
                recipe.AddIngredient(ItemID.SilverBow);
                recipe.AddIngredient(ItemID.SapphireStaff);
                recipe.AddIngredient(ItemID.BluePhaseblade);
                recipe.AddIngredient(thorium.ItemType("ArcaneDust"), 10); 
                recipe.AddIngredient(thorium.ItemType("SapphireButterfly"));
            }
            else
            {
                recipe.AddIngredient(ItemID.SilverBroadsword);
                recipe.AddIngredient(ItemID.SapphireStaff);
                recipe.AddIngredient(ItemID.BluePhaseblade);
            }

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
