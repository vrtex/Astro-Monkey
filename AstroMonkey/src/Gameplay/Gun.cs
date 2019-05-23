using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using AstroMonkey.Assets.Objects;

namespace AstroMonkey.Gameplay
{
    struct ClipInfo
    {
        public AmmoClip clip;
        public float fireDelay;

        public static implicit operator AmmoClip(ClipInfo ammoInfo)
        {
            return ammoInfo.clip;
        }
    }

    class Gun : Component
    {
        public delegate void GunEvent(Gun gun);
        public event GunEvent OnWeaponChange;
        public event GunEvent OnAmmoChange;

        private Audio.AudioSource ShootSoundComponent;

        private List<ClipInfo> ammoClips = new List<ClipInfo>();
        //{
        //    new ClipInfo { clip = new AmmoClip(typeof(AlienBullet), 10, 100, 0.5f), fireDelay = 0.1f},
        //    new ClipInfo { clip = new AmmoClip(typeof(Rocket), 3, 20, 2f), fireDelay = 0.75f},
        //    new ClipInfo { clip = new AmmoClip(typeof(PistolBullet), 5, 50, 0.5f), fireDelay = 0.2f},
        //};
        private int currentClipIndex;
        public AmmoClip currentClip { get; private set; }
        private float delayLeft = 0f;

		public Gun(GameObject parent) : base(parent)
		{
            currentClipIndex = 1;

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
            OnAmmoChange?.Invoke(this);

            delayLeft = ammoClips[currentClipIndex].fireDelay;
		}

        public void ChangeAmmo(bool moveUp)
        {
            if(ammoClips.Count == 0)
                return;
            if(delayLeft > 0)
                return;
            currentClipIndex += moveUp ? 1 : -1;
            currentClipIndex = currentClipIndex % ammoClips.Count;
            while(currentClipIndex < 0) currentClipIndex += ammoClips.Count;


            // TODO: add clip loading/unloading

            if(currentClip != null)
                currentClip.onReload -= ReloadHandler;

            currentClip = ammoClips[currentClipIndex];
            OnWeaponChange?.Invoke(this);
            currentClip.onReload += ReloadHandler;
            Console.WriteLine(ammoClips[currentClipIndex].clip.ammoType);
        }

        private void ReloadHandler(AmmoClip clip)
        {
            OnAmmoChange?.Invoke(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentClip.Update(gameTime);

            delayLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Reload()
        {
            currentClip.StartReload();
        }

        public bool RestoreAmmo(Type ammoType, int amount)
        {
            AmmoClip clip = ammoClips.Find(x => x.clip.ammoType == ammoType);

            if(clip == null)
                throw new ApplicationException("restoring unexisting ammo");

            if(clip.IsFull())
                return false;

            clip.RestoreAmmo(amount);
            OnAmmoChange?.Invoke(this);

            return true;
        }

        public bool RestoreAmmo(BaseAmmo ammoPack)
        {
            return RestoreAmmo(ammoPack.ProjectileType, ammoPack.Count);
        }

        public override string ToString()
        {
            String toReturn = "Gun on: " + parent;
            foreach(AmmoClip clip in ammoClips)
                toReturn += "\n" + clip;
            return toReturn;
        }

        public void AddAmmoClip(ClipInfo clip)
        {
            ammoClips.Add(clip);
            ChangeAmmo(true);
        }
    }
}
