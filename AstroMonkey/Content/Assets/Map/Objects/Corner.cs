using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Corner: Core.GameObject
    {
        public Corner(): this(new Core.Transform())
        {
        }

        public Corner(Core.Transform _transform)
        {
            Load(_transform);
        }

        public Corner(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Corner(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "wall", new Rectangle(0, 0, 32, 32)));
        }
    }
}
