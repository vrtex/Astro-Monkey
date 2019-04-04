using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformDirt01: Floor
    {
        public FloorPlatformDirt01(): this(new Core.Transform())
        {
        }
        public FloorPlatformDirt01(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatformDirt01(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformDirt01(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(0, 32, 32, 32) }));
        }
    }
}
