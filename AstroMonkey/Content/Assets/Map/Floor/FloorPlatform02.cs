using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class FloorPlatform02: Core.GameObject
    {
        public FloorPlatform02() : this(new Core.Transform())
        {
        }
        public FloorPlatform02(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }
        public FloorPlatform02(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public FloorPlatform02(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "floorPlatform0", new List<Rectangle> { new Rectangle(32, 0, 32, 32) }));
        }
    }
}
