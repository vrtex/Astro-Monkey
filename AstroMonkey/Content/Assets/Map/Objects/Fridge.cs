using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Fridge: Core.GameObject
    {
        public Fridge() : this(new Core.Transform())
        {
        }

        public Fridge(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public Fridge(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Fridge(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 21; ++i)
            {
                temp.Add(new Rectangle(i * 21, 0, 21, 21));
            }

            AddComponent(new Graphics.Sprite(this, "fridge", temp));
        }
    }

}
