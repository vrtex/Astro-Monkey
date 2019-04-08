using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class CaseCaffe: Core.GameObject
    {
        public CaseCaffe() : this(new Core.Transform())
        {
        }

        public CaseCaffe(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public CaseCaffe(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public CaseCaffe(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;

            // Physics
            AddComponent(new BoxCollider(this, CollisionChanell.InteractPlayer, new Vector2(0, 0), 32, 24));

            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 16; ++i)
            {
                temp.Add(new Rectangle(i * 32, 0, 32, 16));
            }

            AddComponent(new Graphics.Sprite(this, "caseCaffe", temp));
        }
    }

}
