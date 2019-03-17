using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Banana: Core.GameObject
    {
        public Banana(): this(new Core.Transform())
        {
        }

        public Banana(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }

        public Banana(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Banana(Vector2 position): this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "item", new Rectangle(0, 0, 32, 32)));
        }
    }
}
