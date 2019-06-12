using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Assets.Objects;
using AstroMonkey.Core;

namespace AstroMonkey.Gameplay
{
    struct AmmoInfo
    {
        public Type type;
        public int loaded;
        public int clipSize;
        public int reservesLeft;
        public int max;
    }

    class AmmoClip
    {
        public delegate void ClipEvent(AmmoClip clip);
        public event ClipEvent OnReload;
        public bool IsReloading { get; private set; } = false;

        public Type ammoType { get; private set; }
        private int currentlyInClip;
        private int clipSize;
        // if ammoReserves is < 0 it's an infinite clip
        private int ammoReserves;
        private int maxAmmo;

        private float reloadTime;
        private float reloadLeft = 0f;

        public AmmoClip(Type bulletType, int clipSize, int maxAmmo, float reloadTime)
        {
            ammoType = bulletType;
            if(!ammoType.IsSubclassOf(typeof(BaseProjectile)))
                throw new ApplicationException("ammo type expected");
            this.clipSize = clipSize;
            this.maxAmmo = maxAmmo;
            this.reloadTime = reloadTime;

            ammoReserves = maxAmmo;
            currentlyInClip = clipSize;
        }

        public AmmoClip(AmmoClip other)
        {
            ammoType = other.ammoType;
            this.clipSize = other.clipSize;
            this.maxAmmo = other.maxAmmo;
            this.reloadTime = other.reloadTime;

            ammoReserves = other.ammoReserves;
            currentlyInClip = other.currentlyInClip;

        }

        public void Update(GameTime gameTime)
        {
            TryReload((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        private void TryReload(float elapsedTime)
        {
            if(reloadLeft <= 0)
            {
                IsReloading = false;
                return;
            }

            IsReloading = true;
            reloadLeft -= elapsedTime;
            if(reloadLeft > 0)
                return;
            int toMove;
            if(ammoReserves >= 0)
                toMove = Math.Min(clipSize - currentlyInClip, ammoReserves);
            else
                toMove = clipSize - currentlyInClip;

            if(ammoReserves >= 0)
                ammoReserves -= toMove;

            currentlyInClip += toMove;
            OnReload?.Invoke(this);
        }

        public AmmoInfo GetAmmoInfo()
        {
            return new AmmoInfo
            {
                type = ammoType,
                loaded = currentlyInClip,
                clipSize = this.clipSize,
                reservesLeft = ammoReserves,
                max = maxAmmo
            };
        }

        public bool IsFull()
        {
            return currentlyInClip + ammoReserves == clipSize + maxAmmo;
        }

        public void RestoreAmmo(int amount)
        {
            ammoReserves += amount;
            ammoReserves = MathHelper.Clamp(ammoReserves, 0, maxAmmo + clipSize);
        }

        public BaseProjectile GetProjectile(Transform parentTransorm)
        {
            if(currentlyInClip == 0)
                return null;

            reloadLeft = -1.0f;

            BaseProjectile toReturn = (BaseProjectile)Activator.CreateInstance(ammoType, new object[] {
                new Transform(parentTransorm)}
            );

            currentlyInClip--;
            if(currentlyInClip == 0)
                StartReload();

            return toReturn;
        }

        public void StartReload()
        {
            reloadLeft = reloadTime;
        }

        public float GetReloadLeft()
        {
            return reloadLeft / reloadTime;
        }

        public override string ToString()
        {
            return String.Format("Ammo: {0}, left: {1}/{2}", ammoType, currentlyInClip, ammoReserves);
        }
    }
}
