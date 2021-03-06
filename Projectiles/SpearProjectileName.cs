using System;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles
{
    public class SpearProjectileName : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wasp Lance");
        }

        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 50;
            projectile.scale = 1.1f;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.timeLeft = 90;
            projectile.hide = true;
        }

        public override void AI()
        {
            Main.player[projectile.owner].direction = projectile.direction;
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - projectile.width / 2;
            projectile.position.Y = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - projectile.height / 2;
            projectile.position += projectile.velocity * projectile.ai[0];
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }

            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
                projectile.ai[0] -= 1.1f;
            else
                projectile.ai[0] += 0.95f;

            if (Main.player[projectile.owner].itemAnimation == 0) projectile.Kill();

            projectile.rotation = (float) Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 2.355f;
            if (projectile.spriteDirection == -1) projectile.rotation -= 1.57f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("GoldenFire"), 500);
        }
    }
}