using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Banana: Core.GameObject
    {
        public Banana()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Banana(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Banana(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Banana(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "item", new Rectangle(0, 0, 32, 32)));
        }
    }
}
