using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorCrate06: Floor
    {
        public FloorCrate06() : this(new Core.Transform())
        {
        }
        public FloorCrate06(Core.Transform _transform)
        {
            Load(_transform);
        }
        public FloorCrate06(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorCrate06(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floorCrate", new List<Rectangle> { new Rectangle(160, 0, 32, 32) }));
        }
    }
}
