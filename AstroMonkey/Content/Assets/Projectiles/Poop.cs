using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Poop: Core.GameObject
    {
        public Poop() : this(new Core.Transform())
        {
        }

        public Poop(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public Poop(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Poop(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "poop", new List<Rectangle>() { new Rectangle(0, 0, 4, 4) }));
        }
    }
}
