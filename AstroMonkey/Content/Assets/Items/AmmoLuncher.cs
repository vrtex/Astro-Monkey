using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class AmmoLuncher: Core.GameObject
    {
        public AmmoLuncher() : this(new Core.Transform())
        {
        }

        public AmmoLuncher(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public AmmoLuncher(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public AmmoLuncher(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            List<Rectangle> temp = new List<Rectangle>();
            for(int i = 0; i < 16; ++i)
            {
                temp.Add(new Rectangle(i * 16, 0, 16, 16));
            }

            AddComponent(new Graphics.Sprite(this, "ammoLuncher", temp));

            AddComponent(new Graphics.StackAnimator(this));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    new List<Rectangle> {
                        new Rectangle(0, 0, 16, 16),
                        new Rectangle(16, 0, 16, 16),
                        new Rectangle(32, 0, 16, 16),
                        new Rectangle(48, 0, 16, 16),
                        new Rectangle(64, 0, 16, 16),
                        new Rectangle(80, 0, 16, 16),
                        new Rectangle(96, 0, 16, 16),
                        new Rectangle(112, 0, 16, 16),
                        new Rectangle(128, 0, 16, 16),
                        new Rectangle(144, 0, 16, 16),
                        new Rectangle(160, 0, 16, 16),
                        new Rectangle(176, 0, 16, 16),
                        new Rectangle(192, 0, 16, 16),
                        new Rectangle(208, 0, 16, 16),
                        new Rectangle(224, 0, 16, 16),
                        new Rectangle(240, 0, 16, 16)
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 16, 16, 16),
                        new Rectangle(16, 16, 16, 16),
                        new Rectangle(32, 16, 16, 16),
                        new Rectangle(48, 16, 16, 16),
                        new Rectangle(64, 16, 16, 16),
                        new Rectangle(80, 16, 16, 16),
                        new Rectangle(96, 16, 16, 16),
                        new Rectangle(112, 16, 16, 16),
                        new Rectangle(128, 16, 16, 16),
                        new Rectangle(144, 16, 16, 16),
                        new Rectangle(160, 16, 16, 16),
                        new Rectangle(176, 16, 16, 16),
                        new Rectangle(192, 16, 16, 16),
                        new Rectangle(208, 16, 16, 16),
                        new Rectangle(224, 16, 16, 16),
                        new Rectangle(240, 16, 16, 16)
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 32, 16, 16),
                        new Rectangle(16, 32, 16, 16),
                        new Rectangle(32, 32, 16, 16),
                        new Rectangle(48, 32, 16, 16),
                        new Rectangle(64, 32, 16, 16),
                        new Rectangle(80, 32, 16, 16),
                        new Rectangle(96, 32, 16, 16),
                        new Rectangle(112, 32, 16, 16),
                        new Rectangle(128, 32, 16, 16),
                        new Rectangle(144, 32, 16, 16),
                        new Rectangle(160, 32, 16, 16),
                        new Rectangle(176, 32, 16, 16),
                        new Rectangle(192, 32, 16, 16),
                        new Rectangle(208, 32, 16, 16),
                        new Rectangle(224, 32, 16, 16),
                        new Rectangle(240, 32, 16, 16)
                    },
                    new List<Rectangle> {
                        new Rectangle(0, 16, 16, 16),
                        new Rectangle(16, 16, 16, 16),
                        new Rectangle(32, 16, 16, 16),
                        new Rectangle(48, 16, 16, 16),
                        new Rectangle(64, 16, 16, 16),
                        new Rectangle(80, 16, 16, 16),
                        new Rectangle(96, 16, 16, 16),
                        new Rectangle(112, 16, 16, 16),
                        new Rectangle(128, 16, 16, 16),
                        new Rectangle(144, 16, 16, 16),
                        new Rectangle(160, 16, 16, 16),
                        new Rectangle(176, 16, 16, 16),
                        new Rectangle(192, 16, 16, 16),
                        new Rectangle(208, 16, 16, 16),
                        new Rectangle(224, 16, 16, 16),
                        new Rectangle(240, 16, 16, 16)
                    }},
                266,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}

