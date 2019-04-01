using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformDirt04: Floor
    {
        public FloorPlatformDirt04(): this(new Core.Transform())
        {
        }
        public FloorPlatformDirt04(Core.Transform _transform)
        {
            Load(_transform);
        }
        public FloorPlatformDirt04(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformDirt04(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(96, 32, 32, 32) }));
        }
    }
}
