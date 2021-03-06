﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Weapons.SwarmDrops
{
    public class TheBigSting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Big Sting");
            Tooltip.SetDefault("''");
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.ranged = true;
            item.width = 24;
            item.height = 24;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1.5f;
            item.UseSound = new LegacySoundStyle(4, 13);
            item.value = 50000;
            item.rare = 5;
            item.autoReuse = true;
            item.shoot = ProjectileID.HornetStinger;
            //item.useAmmo = ItemID.Stinger;
            item.shootSpeed = 20f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);

            return false;
        }

        //make them hold it different
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}