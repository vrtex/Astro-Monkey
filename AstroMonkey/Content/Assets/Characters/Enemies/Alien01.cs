﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien01: Core.GameObject
    {
        private int height = 13;
        private int size = 21;

        public Alien01()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Alien01(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }
        public Alien01(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Alien01(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;

            // Physics
            AddComponent(new Body(this));
            AddComponent(new CircleCollider(this, CollisionChanell.Enemy, Vector2.Zero, size / 3));
            //AddComponent(new CircleCollider(this, CollisionChanell.Hitbox, Vector2.Zero, size / 2));
            

            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "alien01", idle01));

            AddComponent(new Graphics.StackAnimator(this));

			Gameplay.Health healthComponent = (Gameplay.Health) AddComponent(new Gameplay.Health(this));
			UI.HealthBar healthBar = (UI.HealthBar)AddComponent(new UI.HealthBar(this, height * 2));
            healthComponent.OnDamageTaken += healthBar.Refresh;


            //STANIE
            List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02 },
                266,
                true));

            //CHODZENIE
            List<Rectangle> walk01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk01.Add(new Rectangle(i * size, size * 2, size, size));
            List<Rectangle> walk02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk02.Add(new Rectangle(i * size, size * 3, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, walk01, idle01, walk02 },
                134,
                true));

            //ATAK
            List<Rectangle> attack01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack01.Add(new Rectangle(i * size, size * 4, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, attack01 },
                266,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}
