using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformDirt02: Floor
    {
        public FloorPlatformDirt02(): this(new Core.Transform())
        {
        }
        public FloorPlatformDirt02(Core.Transform _transform)
        {
            Load(_transform);
        }
        public FloorPlatformDirt02(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformDirt02(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(32, 32, 32, 32) }));
        }
    }
}
