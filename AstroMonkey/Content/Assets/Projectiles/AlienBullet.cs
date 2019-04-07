using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class AlienBullet: BaseProjectile
    {
        public Gameplay.DamageInfo damage;

        public AlienBullet() : this(new Core.Transform())
        {
        }

        public AlienBullet(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public AlienBullet(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public AlienBullet(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "alienBullet", new List<Rectangle>() { new Rectangle(0, 0, 3, 6) }));
            
        }

    }
}
