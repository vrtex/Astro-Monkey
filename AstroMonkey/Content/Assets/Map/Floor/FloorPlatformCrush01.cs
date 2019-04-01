using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformCrush01: Floor
    {
        public FloorPlatformCrush01(): this(new Core.Transform())
        {
        }
        public FloorPlatformCrush01(Core.Transform _transform)
        {
            Load(_transform);
        }
        public FloorPlatformCrush01(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformCrush01(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(0, 64, 32, 32) }));
        }
    }
}
