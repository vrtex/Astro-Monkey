﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class Terminal: Core.GameObject
    {
        private float size = 12;

        public Terminal() : this(new Core.Transform())
        {
        }

        public Terminal(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public Terminal(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Terminal(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            // Physics
            AddComponent(new CircleCollider(this, CollisionChanell.InteractPlayer, new Vector2(-4, 0), size));

            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 32; ++i)
            {
                temp.Add(new Rectangle(i * 32, 0, 32, 32));
            }

            AddComponent(new Graphics.Sprite(this, "terminal", temp));
        }
    }

}
