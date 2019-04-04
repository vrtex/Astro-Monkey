using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatform01: Floor
    {
        public FloorPlatform01(): this(new Core.Transform())
        {
        }
        public FloorPlatform01(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatform01(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatform01(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(0, 0, 32, 32) }));
        }
    }
}
