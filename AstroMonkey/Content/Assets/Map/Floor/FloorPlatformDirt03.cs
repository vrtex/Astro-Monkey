using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatformDirt03: Floor
    {
        public FloorPlatformDirt03(): this(new Core.Transform())
        {
        }
        public FloorPlatformDirt03(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatformDirt03(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatformDirt03(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(64, 32, 32, 32) }));
        }
    }
}
