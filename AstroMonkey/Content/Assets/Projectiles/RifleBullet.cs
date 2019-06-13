using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class RifleBullet : BaseProjectile
    {
        public RifleBullet(Transform transform) : base(transform)
        {
            Load(transform);
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "pistolBullet", new List<Rectangle>() { new Rectangle(0, 0, 2, 4) }));
            shootSound = Audio.SoundContainer.Instance.GetSoundEffect("RifleShoot").CreateInstance();
            speed = 950f;
            baseDamage = 20;
        }
    }
}
