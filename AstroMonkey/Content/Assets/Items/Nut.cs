﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class Nut: Core.GameObject
    {
        public Nut() : this(new Core.Transform())
        {
        }

        public Nut(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public Nut(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Nut(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private int height = 16;
        private int size = 16;

        private void Load(Core.Transform _transform)
        {
            // Physics
            AddComponent(new CircleCollider(this, CollisionChanell.Item, Vector2.Zero, size / 2));

            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "nut", idle01));

            AddComponent(new Graphics.StackAnimator(this));

            List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size, size, size));
            List<Rectangle> idle03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle03.Add(new Rectangle(i * size, size * 2, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02, idle03, idle02 },
                266,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}
