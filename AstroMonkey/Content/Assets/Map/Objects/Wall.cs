using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class Wall: Core.GameObject
    {
        public Wall(): this(new Core.Transform())
        {
        }

        public Wall(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }
        public Wall(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Wall(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 32; ++i)
            {
                temp.Add(new Rectangle(i * 32, 0, 32, 32));
            }

            AddComponent(new Graphics.Sprite(this, "wall", temp));
            AddComponent(new BoxCollider(this, CollisionChanell.Object, Vector2.Zero, 32, 32));
        }
    }

}
