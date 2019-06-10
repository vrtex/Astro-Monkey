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

        public ClipInfo Copy()
        {
            ClipInfo toReturn = new ClipInfo
            { clip = new AmmoClip(clip), fireDelay = fireDelay };
            return toReturn;
        }
    }


    class Gun : Component
    {
        public static readonly ClipInfo pistolClip = new ClipInfo() { clip = new AmmoClip(typeof(PistolBullet), 5, 50, 0.5f), fireDelay = 0.2f };
        public static readonly ClipInfo rifleClip = new ClipInfo { clip = new AmmoClip(typeof(RifleBullet), 25, 150, 0.5f), fireDelay = 0.15f };
        public static readonly ClipInfo alienClip = new ClipInfo() { clip = new AmmoClip(typeof(AlienBullet), 10, 100, 0.5f), fireDelay = 0.1f };
        public static readonly ClipInfo launcherClip = new ClipInfo { clip = new AmmoClip(typeof(Rocket), 3, 20, 2f), fireDelay = 0.75f };
        public static readonly ClipInfo shotgunClip = new ClipInfo { clip = new AmmoClip(typeof(ShotgunProjectile), 500, 2000, 1.5f), fireDelay = 0.45f };


        public delegate void GunEvent(Gun gun);
        public event GunEvent OnWeaponChange;
        public event GunEvent OnAmmoChange;
        public event GunEvent OnReloadProgress;

        private Audio.AudioSource ShootSoundComponent;
        private bool shooting = false;

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

			GameManager.SpawnObject(projectile);
            projectile.Start(targetPosition, parent);

            ShootSoundComponent.Play();

            OnAmmoChange?.Invoke(this);
            shooting = true;

            delayLeft = ammoClips[currentClipIndex].fireDelay;
		}

        public void StopShooting()
        {
            shooting = false;
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

            if(currentClip != null)
                currentClip.OnReload -= ReloadHandler;

            currentClip = ammoClips[currentClipIndex];
            OnWeaponChange?.Invoke(this);
            currentClip.OnReload += ReloadHandler;
        }

        private void ReloadHandler(AmmoClip clip)
        {
            OnAmmoChange?.Invoke(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentClip.Update(gameTime);
            if(currentClip.IsReloading)
                OnReloadProgress?.Invoke(this);

            if(shooting)
                Shoot(Input.InputManager.Manager.MouseCursorInWorldSpace);

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

        public bool IsReloading()
        {
            return currentClip.IsReloading;
        }

        public float GetReloadLeft()
        {
            return currentClip.GetReloadLeft();
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

        public List<ClipInfo> GetClips()
        {
            List<ClipInfo> toReturn = new List<ClipInfo>();
            foreach(ClipInfo clip in ammoClips)
                toReturn.Add(clip.Copy());
            return toReturn;
        }
    }
}
