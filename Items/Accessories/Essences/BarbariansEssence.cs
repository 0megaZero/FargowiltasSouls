using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Essences
{
    public class BarbariansEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barbarian's Essence");
            Tooltip.SetDefault(
                @"'This is only the beginning..' 
18% increased melee damage 
10% increased melee speed 
5% increased melee crit chance");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 150000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += .18f;
            player.meleeSpeed += .1f;
            player.meleeCrit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            if (Fargowiltas.Instance.ThoriumLoaded)
            {
                //just thorium
                recipe.AddIngredient(ItemID.WarriorEmblem);

                recipe.AddIngredient(ItemID.ZombieArm);
                recipe.AddIngredient(ItemID.Trident);
                recipe.AddIngredient(ItemID.ChainKnife);
                //red hourglass
                recipe.AddIngredient(ItemID.StylistKilLaKillScissorsIWish);
                recipe.AddIngredient(ItemID.IceBlade);
                //bellerose
                recipe.AddIngredient(ItemID.Starfury);
                //drenched dirk
                //whip
                recipe.AddIngredient(ItemID.BeeKeeper);
                //energy storm partizan //energy storm
                //sanguine/nocturne yoyo
            }
            else
            {
                //no others
                recipe.AddIngredient(ItemID.WarriorEmblem);
                recipe.AddIngredient(ItemID.ZombieArm);
                recipe.AddIngredient(ItemID.Trident);
                recipe.AddIngredient(ItemID.ChainKnife);
                recipe.AddIngredient(ItemID.StylistKilLaKillScissorsIWish);
                recipe.AddIngredient(ItemID.IceBlade);
                recipe.AddIngredient(ItemID.Starfury);
                recipe.AddIngredient(ItemID.BeeKeeper);
                recipe.AddIngredient(ItemID.Cascade);
            }

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
