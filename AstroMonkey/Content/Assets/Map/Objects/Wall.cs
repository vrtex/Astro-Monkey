using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Wall: Core.GameObject
    {
        public Wall()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Wall(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Wall(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Wall(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "wall", new Rectangle(32, 0, 32, 32)));
        }
    }

}
