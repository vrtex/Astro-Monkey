using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien02: Core.GameObject
    {
        private int height = 21;
        private int size = 21;

        public Alien02()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Alien02(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public Alien02(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Alien02(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;

            // Physics
            AddComponent(new Body(this));
            AddComponent(new CircleCollider(this, CollisionChanell.Enemy, Vector2.Zero, size / 3));

            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "alien02", idle01));

            AddComponent(new Graphics.StackAnimator(this));

			AddComponent(new Gameplay.Health(this));
			AddComponent(new UI.HealthBar(this, height * 5 / 3));

			//STANIE
			List <Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size * 1, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02 },
                266,
                true));

            //CHODZENIE
            List<Rectangle> walk01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk01.Add(new Rectangle(i * size, size * 2, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, walk01 },
                266,
                true));

            //ATAK
            List<Rectangle> attack01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack01.Add(new Rectangle(i * size, size * 3, size, size));
            List<Rectangle> attack02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack02.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> attack03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack03.Add(new Rectangle(i * size, size * 5, size, size));
            List<Rectangle> attack04 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack04.Add(new Rectangle(i * size, size * 6, size, size));
            List<Rectangle> attack05 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack05.Add(new Rectangle(i * size, size * 7, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, attack01, attack02, attack03, attack04, attack05 },
                266,
                true));

            //UMIERANIE
            List<Rectangle> dead01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 3, size, size));
            List<Rectangle> dead02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> dead03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead03.Add(new Rectangle(i * size, size * 5, size, size));
            List<Rectangle> dead04 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead04.Add(new Rectangle(i * size, size * 6, size, size));
            List<Rectangle> dead05 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead05.Add(new Rectangle(i * size, size * 7, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { dead01, dead02, dead03, dead04, dead05 },
                352,
                false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}
