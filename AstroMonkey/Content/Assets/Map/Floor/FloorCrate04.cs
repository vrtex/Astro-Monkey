using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorCrate04: Floor
    {
        public FloorCrate04() : this(new Core.Transform())
        {
        }
        public FloorCrate04(Core.Transform _transform)
        {
            Load(_transform);
        }
        public FloorCrate04(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorCrate04(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floorCrate", new List<Rectangle> { new Rectangle(96, 0, 32, 32) }));
        }
    }
}
