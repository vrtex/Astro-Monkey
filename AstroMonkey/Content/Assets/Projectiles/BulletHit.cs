using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BulletHit: Core.GameObject
    {
        public BulletHit() : this(new Core.Transform())
        {
        }

        public BulletHit(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public BulletHit(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public BulletHit(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "BulletHit", new List<Rectangle>() { new Rectangle(0, 0, 3, 3) }));
        }
    }
}
