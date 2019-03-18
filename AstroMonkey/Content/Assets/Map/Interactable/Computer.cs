using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Computer: Core.GameObject
    {
        public Computer(): this(new Core.Transform())
        {
        }

        public Computer(Core.Transform _transform)
        {
            Load(_transform);
        }

        public Computer(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Computer(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "computer", new List<Rectangle> { new Rectangle(0, 0, 32, 32) }));
        }
    }
}
