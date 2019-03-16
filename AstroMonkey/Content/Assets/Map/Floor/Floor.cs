using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Floor: Core.GameObject
    {
        public Floor()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Floor(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Floor(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Floor(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floor", new Rectangle(0, 0, 32, 32)));
        }

        public void RandFloor()
        {
            GetComponent<Graphics.Sprite>().rect = new Rectangle(Util.RNG.random.Next(0, 3) * 32, 0, 32, 32);
        }
    }
}
