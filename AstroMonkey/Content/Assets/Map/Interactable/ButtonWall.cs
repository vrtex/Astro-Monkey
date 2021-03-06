﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Assets.Objects
{
    class ButtonWall: Core.GameObject
    {
        private float size = 12;
        
        public ButtonWall() : this(new Core.Transform())
        {
        }

        public ButtonWall(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public ButtonWall(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public ButtonWall(Vector2 position) : this(new Core.Transform(position, Vector2.One))
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

            AddComponent(new Graphics.Sprite(this, "buttonWall", temp));
        }
    }

}
