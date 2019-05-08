using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using AstroMonkey.Assets.Objects;

namespace AstroMonkey.Gameplay
{
    struct AmmoInfo
    {
        public AmmoClip clip;
        public float fireDelay;

        public static implicit operator AmmoClip(AmmoInfo ammoInfo)
        {
            return ammoInfo.clip;
        }
    }

    class Gun : Component
    {
        private Audio.AudioSource ShootSoundComponent;

        private List<AmmoInfo> ammoClips = new List<AmmoInfo>
        {
            new AmmoInfo { clip = new AmmoClip(typeof(AlienBullet), 10, 100, 0.5f), fireDelay = 0.1f},
            new AmmoInfo { clip = new AmmoClip(typeof(Rocket), 3, 20, 2f), fireDelay = 0.75f},
            new AmmoInfo { clip = new AmmoClip(typeof(PistolBullet), 5, 50, 0.5f), fireDelay = 0.2f},
        };
        private int currentClipIndex = 0;
        private AmmoClip currentClip;
        private float delayLeft = 0f;

		public Gun(GameObject parent) : base(parent)
		{
            currentClipIndex = 0;
            currentClip = ammoClips[currentClipIndex];

            ShootSoundComponent = Parent.AddComponent(new Audio.AudioSource(Parent, Audio.SoundContainer.Instance.GetSoundEffect("GunShoot")));
		}

		public void Shoot(Vector2 targetPosition)
		{
            if(delayLeft > 0)
                return;
            BaseProjectile projectile =
                currentClip.GetProjectile(parent.transform);

            if(projectile == null)
                return;

			ShootSoundComponent.SoundEffect = projectile.shootSound;
			ShootSoundComponent.Play();

			Vector2 parentPosition = parent.transform.position;
			Vector2 direction = targetPosition - parentPosition;
			direction.Normalize();

			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Direction = direction;
			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Velocity = projectile.speed;

			projectile.Damage = new DamageInfo(parent, projectile.baseDamage);

			GameManager.SpawnObject(projectile);
            Console.WriteLine(currentClip);

            delayLeft = ammoClips[currentClipIndex].fireDelay;
		}

        public void ChangeAmmo(bool moveUp)
        {
            if(delayLeft > 0)
                return;
            currentClipIndex += moveUp ? 1 : -1;
            currentClipIndex = currentClipIndex % ammoClips.Count;
            while(currentClipIndex < 0) currentClipIndex += ammoClips.Count;

            currentClip = ammoClips[currentClipIndex];
            Console.WriteLine(ammoClips[currentClipIndex].clip.ammoType);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentClip.Update(gameTime);

            delayLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
