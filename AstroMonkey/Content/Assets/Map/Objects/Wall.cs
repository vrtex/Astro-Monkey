using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Wall: Core.GameObject
    {
        public Wall(): this(new Core.Transform())
        {
        }

        public Wall(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Wall(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Wall(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "wall", new Rectangle(32, 0, 32, 32)));
        }
    }

}
