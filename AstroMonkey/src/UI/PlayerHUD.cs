using System;
using System.Collections.Generic;
using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;
using AstroMonkey.Assets.Objects;
using AstroMonkey.Graphics;

namespace AstroMonkey.UI
{
    class PlayerHUD : GameObject
    {
        private Health health;
        private Gun gun;

        // private AmmoDisplay ammoDisplay;

        private ProgressBarWidget healthBarWidget = new ProgressBarWidget(new Vector2(0.1f, 0.9f), new Vector2(0.3f, 0.05f))
        {
            Texture = SpriteContainer.Instance.GetImage("bar"),
            SourceRectangle = new Rectangle(0, 0, 40, 2)
        };

        private Widget healthBarBackground = new Widget(new Vector2(0.1f, 0.9f), new Vector2(0.3f, 0.05f))
        {
            Texture = SpriteContainer.Instance.GetImage("bar"),
            SourceRectangle = new Rectangle(0, 2, 40, 2),
            ZOrder = -1
        };

        private TextWidget ammoDisplayWidget = new TextWidget(new Vector2());

        private Dictionary<Type, Graphics.Widget> gunIcons = new Dictionary<Type, Graphics.Widget>
        {
            [typeof(PistolBullet)] = new Widget(new Vector2(0.8f, 0.8f))
            { Texture = SpriteContainer.Instance.GetImage("gunIcons"), SourceRectangle = new Rectangle(0, 0, 20, 20), Scale = new Vector2(3, 3)},
            [typeof(RifleBullet)] = new Widget(new Vector2(0.8f, 0.8f))
            { Texture = SpriteContainer.Instance.GetImage("gunIcons"), SourceRectangle = new Rectangle(20, 0, 20, 20), Scale = new Vector2(3, 3)},
            [typeof(ShotgunProjectile)] = new Widget(new Vector2(0.8f, 0.8f))
            { Texture = SpriteContainer.Instance.GetImage("gunIcons"), SourceRectangle = new Rectangle(40, 0, 20, 20), Scale = new Vector2(3, 3)},
            [typeof(Rocket)] = new Widget(new Vector2(0.8f, 0.8f))
            { Texture = SpriteContainer.Instance.GetImage("gunIcons"), SourceRectangle = new Rectangle(60, 0, 20, 20), Scale = new Vector2(3, 3)}
        };

        private Widget currentGunWiget;

        public PlayerHUD(GameObject parent)
        {
            health = parent.GetComponent<Health>();
            gun = parent.GetComponent<Gun>();

            health.OnDamageTaken += HealthChanged;
            gun.OnAmmoChange += GunChange;
            gun.OnWeaponChange += GunChange;

            // ammoDisplay = GameManager.SpawnObject(new AmmoDisplay(parent));

            WidgetManager.AddWidget(healthBarWidget);
            WidgetManager.AddWidget(healthBarBackground);
            WidgetManager.AddWidget(ammoDisplayWidget);



            GunChange(gun);
        }

        private void GunChange(Gun gun)
        {
            AmmoInfo currentAmmo = gun.currentClip.GetAmmoInfo();
            // ammoDisplay.SetAmmoCount(currentAmmo);

            WidgetManager.RemoveWidget(currentGunWiget);
            currentGunWiget = gunIcons[currentAmmo.type];
            WidgetManager.AddWidget(currentGunWiget);

            string ammoString = currentAmmo.loaded.ToString() + "/" + currentAmmo.reservesLeft.ToString();
            ammoDisplayWidget.DisplayString = ammoString;

            //ammoDisplay.SetText("" + currentAmmo.loaded + "/" + currentAmmo.reservesLeft + "\n" +
            //    gun.currentClip.ammoType.Name);
            // TODO: change this to picture
        }

        private void HealthChanged(Health damaged, DamageInfo damageInfo)
        {
            healthBarWidget.SetProgress(damaged.GetPercentage());
        }

        public override void Destroy()
        {
            gun.OnWeaponChange -= GunChange;
            gun.OnAmmoChange -= GunChange;

            // ammoDisplay.Destroy();

            WidgetManager.RemoveWidget(healthBarWidget);

            base.Destroy();
        }
    }
}
