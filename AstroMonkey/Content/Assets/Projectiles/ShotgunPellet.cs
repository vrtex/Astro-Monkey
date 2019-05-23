using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AstroMonkey.Assets.Objects
{
    class ShotgunPellet : BaseProjectile
    {
        public ShotgunPellet(Transform transform) : base(transform)
        {
            AddComponent(new Graphics.Sprite(this, "pistolBullet", new List<Rectangle>() { new Rectangle(0, 0, 3, 5) }));

            speed = 500f;
            baseDamage = 10;
        }
    }
}
