using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class WallCorner: Core.GameObject
    {
        private float size = 12;
        public WallCorner(): this(new Core.Transform())
        {
        }

        public WallCorner(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }

        public WallCorner(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public WallCorner(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            //Phisics
            AddComponent(new BoxCollider(this, CollisionChanell.Object, new Vector2(0, 10), 32, size));
            AddComponent(new BoxCollider(this, CollisionChanell.Object, new Vector2(10, 0), size, 32));

            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 32; ++i)
            {
                temp.Add(new Rectangle(i * 32, 0, 32, 32));
            }

            AddComponent(new Graphics.Sprite(this, "corner", temp));
        }
    }
}
