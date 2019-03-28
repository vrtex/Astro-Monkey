using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien01: Core.GameObject
    {
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
            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 13; ++i)
            {
                temp.Add(new Rectangle(i * 21, 0, 21, 21));
            }
            AddComponent(new Graphics.Sprite(this, "alien01", temp));

            AddComponent(new Graphics.StackAnimator(this));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    new List<Rectangle> {
                        new Rectangle(0, 0, 21, 21),
                        new Rectangle(21, 0, 21, 21),
                        new Rectangle(42, 0, 21, 21),
                        new Rectangle(63, 0, 21, 21),
                        new Rectangle(84, 0, 21, 21),
                        new Rectangle(105, 0, 21, 21),
                        new Rectangle(126, 0, 21, 21),
                        new Rectangle(147, 0, 21, 21),
                        new Rectangle(168, 0, 21, 21),
                        new Rectangle(189, 0, 21, 21),
                        new Rectangle(210, 0, 21, 21),
                        new Rectangle(231, 0, 21, 21),
                        new Rectangle(252, 0, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 21, 21, 21),
                        new Rectangle(21, 21, 21, 21),
                        new Rectangle(42, 21, 21, 21),
                        new Rectangle(63, 21, 21, 21),
                        new Rectangle(84, 21, 21, 21),
                        new Rectangle(105, 21, 21, 21),
                        new Rectangle(126, 21, 21, 21),
                        new Rectangle(147, 21, 21, 21),
                        new Rectangle(168, 21, 21, 21),
                        new Rectangle(189, 21, 21, 21),
                        new Rectangle(210, 21, 21, 21),
                        new Rectangle(231, 21, 21, 21),
                        new Rectangle(252, 21, 21, 21),
                    }},
                266,
                true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    new List<Rectangle> {
                        new Rectangle(0, 0, 21, 21),
                        new Rectangle(21, 0, 21, 21),
                        new Rectangle(42, 0, 21, 21),
                        new Rectangle(63, 0, 21, 21),
                        new Rectangle(84, 0, 21, 21),
                        new Rectangle(105, 0, 21, 21),
                        new Rectangle(126, 0, 21, 21),
                        new Rectangle(147, 0, 21, 21),
                        new Rectangle(168, 0, 21, 21),
                        new Rectangle(189, 0, 21, 21),
                        new Rectangle(210, 0, 21, 21),
                        new Rectangle(231, 0, 21, 21),
                        new Rectangle(252, 0, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 42, 21, 21),
                        new Rectangle(21, 42, 21, 21),
                        new Rectangle(42, 42, 21, 21),
                        new Rectangle(63, 42, 21, 21),
                        new Rectangle(84, 42, 21, 21),
                        new Rectangle(105, 42, 21, 21),
                        new Rectangle(126, 42, 21, 21),
                        new Rectangle(147, 42, 21, 21),
                        new Rectangle(168, 42, 21, 21),
                        new Rectangle(189, 42, 21, 21),
                        new Rectangle(210, 42, 21, 21),
                        new Rectangle(231, 42, 21, 21),
                        new Rectangle(252, 42, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 0, 21, 21),
                        new Rectangle(21, 0, 21, 21),
                        new Rectangle(42, 0, 21, 21),
                        new Rectangle(63, 0, 21, 21),
                        new Rectangle(84, 0, 21, 21),
                        new Rectangle(105, 0, 21, 21),
                        new Rectangle(126, 0, 21, 21),
                        new Rectangle(147, 0, 21, 21),
                        new Rectangle(168, 0, 21, 21),
                        new Rectangle(189, 0, 21, 21),
                        new Rectangle(210, 0, 21, 21),
                        new Rectangle(231, 0, 21, 21),
                        new Rectangle(252, 0, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 63, 21, 21),
                        new Rectangle(21, 63, 21, 21),
                        new Rectangle(42, 63, 21, 21),
                        new Rectangle(63, 63, 21, 21),
                        new Rectangle(84, 63, 21, 21),
                        new Rectangle(105, 63, 21, 21),
                        new Rectangle(126, 63, 21, 21),
                        new Rectangle(147, 63, 21, 21),
                        new Rectangle(168, 63, 21, 21),
                        new Rectangle(189, 63, 21, 21),
                        new Rectangle(210, 63, 21, 21),
                        new Rectangle(231, 63, 21, 21),
                        new Rectangle(252, 63, 21, 21),
                    }},
                134,
                true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    new List<Rectangle> {
                        new Rectangle(0, 0, 21, 21),
                        new Rectangle(21, 0, 21, 21),
                        new Rectangle(42, 0, 21, 21),
                        new Rectangle(63, 0, 21, 21),
                        new Rectangle(84, 0, 21, 21),
                        new Rectangle(105, 0, 21, 21),
                        new Rectangle(126, 0, 21, 21),
                        new Rectangle(147, 0, 21, 21),
                        new Rectangle(168, 0, 21, 21),
                        new Rectangle(189, 0, 21, 21),
                        new Rectangle(210, 0, 21, 21),
                        new Rectangle(231, 0, 21, 21),
                        new Rectangle(252, 0, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 84, 21, 21),
                        new Rectangle(21, 84, 21, 21),
                        new Rectangle(42, 84, 21, 21),
                        new Rectangle(63, 84, 21, 21),
                        new Rectangle(84, 84, 21, 21),
                        new Rectangle(105, 84, 21, 21),
                        new Rectangle(126, 84, 21, 21),
                        new Rectangle(147, 84, 21, 21),
                        new Rectangle(168, 84, 21, 21),
                        new Rectangle(189, 84, 21, 21),
                        new Rectangle(210, 84, 21, 21),
                        new Rectangle(231, 84, 21, 21),
                        new Rectangle(252, 84, 21, 21),
                    }},
                266,
                true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    new List<Rectangle> {
                        new Rectangle(0, 105, 21, 21),
                        new Rectangle(21, 105, 21, 21),
                        new Rectangle(42, 105, 21, 21),
                        new Rectangle(63, 105, 21, 21),
                        new Rectangle(84, 105, 21, 21),
                        new Rectangle(105, 105, 21, 21),
                        new Rectangle(126, 105, 21, 21),
                        new Rectangle(147, 105, 21, 21),
                        new Rectangle(168, 105, 21, 21),
                        new Rectangle(189, 105, 21, 21),
                        new Rectangle(210, 105, 21, 21),
                        new Rectangle(231, 105, 21, 21),
                        new Rectangle(252, 105, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 126, 21, 21),
                        new Rectangle(21, 126, 21, 21),
                        new Rectangle(42, 126, 21, 21),
                        new Rectangle(63, 126, 21, 21),
                        new Rectangle(84, 126, 21, 21),
                        new Rectangle(105, 126, 21, 21),
                        new Rectangle(126, 126, 21, 21),
                        new Rectangle(147, 126, 21, 21),
                        new Rectangle(168, 126, 21, 21),
                        new Rectangle(189, 126, 21, 21),
                        new Rectangle(210, 126, 21, 21),
                        new Rectangle(231, 126, 21, 21),
                        new Rectangle(252, 126, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 147, 21, 21),
                        new Rectangle(21, 147, 21, 21),
                        new Rectangle(42, 147, 21, 21),
                        new Rectangle(63, 147, 21, 21),
                        new Rectangle(84, 147, 21, 21),
                        new Rectangle(105, 147, 21, 21),
                        new Rectangle(126, 147, 21, 21),
                        new Rectangle(147, 147, 21, 21),
                        new Rectangle(168, 147, 21, 21),
                        new Rectangle(189, 147, 21, 21),
                        new Rectangle(210, 147, 21, 21),
                        new Rectangle(231, 147, 21, 21),
                        new Rectangle(252, 147, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 168, 21, 21),
                        new Rectangle(21, 168, 21, 21),
                        new Rectangle(42, 168, 21, 21),
                        new Rectangle(63, 168, 21, 21),
                        new Rectangle(84, 168, 21, 21),
                        new Rectangle(105, 168, 21, 21),
                        new Rectangle(126, 168, 21, 21),
                        new Rectangle(147, 168, 21, 21),
                        new Rectangle(168, 168, 21, 21),
                        new Rectangle(189, 168, 21, 21),
                        new Rectangle(210, 168, 21, 21),
                        new Rectangle(231, 168, 21, 21),
                        new Rectangle(252, 168, 21, 21),
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 189, 21, 21),
                        new Rectangle(21, 189, 21, 21),
                        new Rectangle(42, 189, 21, 21),
                        new Rectangle(63, 189, 21, 21),
                        new Rectangle(84, 189, 21, 21),
                        new Rectangle(105, 189, 21, 21),
                        new Rectangle(126, 189, 21, 21),
                        new Rectangle(147, 189, 21, 21),
                        new Rectangle(168, 189, 21, 21),
                        new Rectangle(189, 189, 21, 21),
                        new Rectangle(210, 189, 21, 21),
                        new Rectangle(231, 189, 21, 21),
                        new Rectangle(252, 189, 21, 21),
                    }},
                352,
                false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}
