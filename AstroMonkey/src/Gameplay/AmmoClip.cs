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
    class AmmoClip
    {
        public Type ammoType { get; private set; }
        private int currentlyInClip;
        private int clipSize;
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

        public void Update(GameTime gameTime)
        {
            TryReload((float)gameTime.ElapsedGameTime.TotalSeconds);

        }

        private void TryReload(float elapsedTime)
        {
            if(reloadLeft <= 0)
                return;

            reloadLeft -= elapsedTime;
            if(reloadLeft > 0)
                return;
            int toMove = Math.Min(clipSize - currentlyInClip, ammoReserves);
            ammoReserves -= toMove;
            currentlyInClip += toMove;
            Console.WriteLine("reloaded");
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
            Console.WriteLine("reload");
            reloadLeft = reloadTime;
        }

        public override string ToString()
        {
            return String.Format("Ammo: {0}, left: {1}/{2}", ammoType, currentlyInClip, ammoReserves);
        }
    }
}
