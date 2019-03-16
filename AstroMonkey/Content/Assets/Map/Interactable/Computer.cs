using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Computer: Core.GameObject
    {
        public Computer()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Computer(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Computer(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Computer(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "computer", new Rectangle(0, 0, 32, 32)));
        }
    }
}
