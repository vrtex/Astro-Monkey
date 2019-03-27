using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class NeonSign: Core.GameObject
    {
        public NeonSign() : this(new Core.Transform())
        {
        }

        public NeonSign(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public NeonSign(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public NeonSign(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 15; ++i)
            {
                temp.Add(new Rectangle(i * 21, 0, 21, 21));
            }

            AddComponent(new Graphics.Sprite(this, "neonSign", temp));
        }
    }

}
