using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;

namespace AstroMonkey.UI
{
    class PlayerHUD : GameObject
    {
        private Health health;
        private Gun gun;

        private Image healthBar;
        private AmmoDisplay ammoDisplay;
        //private Text ammoDisplay;

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
