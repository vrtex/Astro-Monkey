using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatform03: Core.GameObject
    {
        public FloorPlatform03() : this(new Core.Transform())
        {
        }
        public FloorPlatform03(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatform03(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatform03(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform", new List<Rectangle> { new Rectangle(64, 0, 32, 32) }));
        }
    }
}
