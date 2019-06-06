using System;
using System.Collections.Generic;
using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;
using AstroMonkey.Assets.Objects;

namespace AstroMonkey.UI
{
    class PlayerHUD : GameObject
    {
        private Health health;
        private Gun gun;

        private Image healthBar;
        private AmmoDisplay ammoDisplay;

        private Dictionary<Type, Graphics.Widget> gunIcons = new Dictionary<Type, Graphics.Widget>
        {
            [typeof(PistolBullet)] = new Graphics.Widget(new Vector2(0.8f, 0.8f)),
            [typeof(RifleBullet)] = new Graphics.Widget(new Vector2(0.8f, 0.8f)),
            [typeof(Rocket)] = new Graphics.Widget(new Vector2(0.8f, 0.8f)),
            [typeof(ShotgunProjectile)] = new Graphics.Widget(new Vector2(0.8f, 0.8f))
        };

        public PlayerHUD(GameObject parent)
        {
            health = parent.GetComponent<Health>();
            gun = parent.GetComponent<Gun>();

            //health.OnDamageTaken += HealthChanged;
            gun.OnAmmoChange += GunChange;
            gun.OnWeaponChange += GunChange;

            ammoDisplay = GameManager.SpawnObject(new AmmoDisplay(parent));

            healthBar = GameManager.SpawnObject(new Image(new Transform(parent.transform)));
            healthBar.image = new Graphics.Sprite(healthBar, "bar", new List<Rectangle>() { new Rectangle(0, 0, 20, 2) }, 100);

            GunChange(gun);
        }

        private void GunChange(Gun gun)
        {
            AmmoInfo currentAmmo = gun.currentClip.GetAmmoInfo();
            ammoDisplay.SetAmmoCount(currentAmmo);
            //ammoDisplay.SetText("" + currentAmmo.loaded + "/" + currentAmmo.reservesLeft + "\n" +
            //    gun.currentClip.ammoType.Name);
            // TODO: change this to picture
        }

        private void HealthChanged(Health damaged, DamageInfo damageInfo)
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            gun.OnWeaponChange -= GunChange;
            gun.OnAmmoChange -= GunChange;

            healthBar.Destroy();
            ammoDisplay.Destroy();
            base.Destroy();
        }
    }
}
