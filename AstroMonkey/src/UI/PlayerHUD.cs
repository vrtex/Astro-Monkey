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
        private Text ammoDisplay;

        public PlayerHUD(GameObject parent)
        {
            health = parent.GetComponent<Health>();
            gun = parent.GetComponent<Gun>();

            // health.OnDamageTaken += HealthChanged;
            gun.OnAmmoChange += GunChange;
            gun.OnWeaponChange += GunChange;

            ammoDisplay = GameManager.SpawnObject(new Text("0/0", "planetary", new Vector2(0.8f, 0.8f), new Vector2(0.1f, 0.1f)));
            GunChange(gun);
        }

        private void GunChange(Gun gun)
        {
            AmmoInfo currentAmmo = gun.currentClip.GetAmmoInfo();
            ammoDisplay.SetText("" + currentAmmo.loaded + "/" + currentAmmo.reservesLeft + "\n" +
                gun.currentClip.ammoType.Name);
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

            ammoDisplay.Destroy();
            base.Destroy();
        }
    }
}
