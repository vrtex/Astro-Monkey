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

        private ProgressBarWidget healthBarWidget = new ProgressBarWidget(new Vector2(0.02f, 0.95f), new Vector2(0.2f, 0.025f))
        {
            Texture = SpriteContainer.Instance.GetImage("bananabar"),
            SourceRectangle = new Rectangle(0, 0, 80, 4)
        };

        private Widget healthBarBackground = new Widget(new Vector2(0.02f, 0.95f), new Vector2(0.2f, 0.025f))
        {
            Texture = SpriteContainer.Instance.GetImage("bananabar"),
            SourceRectangle = new Rectangle(0, 4, 80, 4),
            ZOrder = -1
        };

        private TextWidget ammoDisplayWidget; // set this after gun icon is set
        private ProgressBarWidget reloadBarWidget; // same here

        private Dictionary<Type, Widget> gunIcons = new Dictionary<Type, Widget>
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

        private Widget currentGunWidget;

        public PlayerHUD(GameObject parent)
        {
            health = parent.GetComponent<Health>();
            gun = parent.GetComponent<Gun>();

            health.OnDamageTaken += HealthChanged;
            gun.OnAmmoChange += GunChange;
            gun.OnWeaponChange += GunChange;
            gun.OnReloadProgress += UpdateReloadBar;

            healthBarWidget.SetProgress(health.GetPercentage());
            WidgetManager.AddWidget(healthBarWidget);
            WidgetManager.AddWidget(healthBarBackground);

            currentGunWidget = gunIcons[typeof(PistolBullet)];
            var iconEnd = currentGunWidget.GetScreenEndPoint();

            ammoDisplayWidget = new TextWidget(new Vector2(iconEnd.X + 0.01f, currentGunWidget.position.Y));
            WidgetManager.AddWidget(ammoDisplayWidget);

            float barSize = iconEnd.X - currentGunWidget.position.X;
            reloadBarWidget = new ProgressBarWidget(new Vector2(currentGunWidget.position.X, iconEnd.Y + 0.01f), new Vector2(barSize, 0))
            { Texture = SpriteContainer.Instance.GetImage("reloadTime"), SourceRectangle = new Rectangle(0, 0, 80, 4) };
            reloadBarWidget.SetProgress(0);
            WidgetManager.AddWidget(reloadBarWidget);

            GunChange(gun);

        }

        private void UpdateReloadBar(Gun gun)
        {
            reloadBarWidget.SetProgress(gun.GetReloadLeft());
        }

        private void GunChange(Gun gun)
        {
            AmmoInfo currentAmmo = gun.currentClip.GetAmmoInfo();

            WidgetManager.RemoveWidget(currentGunWidget);
            currentGunWidget = gunIcons[currentAmmo.type];
            WidgetManager.AddWidget(currentGunWidget);

            string ammoString = currentAmmo.loaded.ToString() + "/" + currentAmmo.reservesLeft.ToString();
            ammoDisplayWidget.DisplayString = ammoString;

        }

        private void HealthChanged(Health damaged, DamageInfo damageInfo)
        {
            healthBarWidget.SetProgress(damaged.GetPercentage());
        }

        public override void Destroy()
        {
            gun.OnWeaponChange -= GunChange;
            gun.OnAmmoChange -= GunChange;
            gun.OnReloadProgress -= UpdateReloadBar;

            WidgetManager.RemoveWidget(healthBarWidget);
            WidgetManager.RemoveWidget(currentGunWidget);
            WidgetManager.RemoveWidget(ammoDisplayWidget);
            WidgetManager.RemoveWidget(reloadBarWidget);

            base.Destroy();
        }
    }
}
