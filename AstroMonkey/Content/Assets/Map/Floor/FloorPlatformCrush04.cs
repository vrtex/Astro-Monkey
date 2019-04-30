using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformCrush04: Floor
    {
        public FloorPlatformCrush04(): this(new Core.Transform())
        {
        }
        public FloorPlatformCrush04(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatformCrush04(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformCrush04(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(96, 64, 32, 32) }));
        }
    }
}
