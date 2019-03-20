using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Monkey: Core.GameObject
    {
        public Monkey()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Monkey(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Monkey(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Monkey(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "monkey", new List<Rectangle> {
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
                new Rectangle(273, 0, 21, 21),
                new Rectangle(294, 0, 21, 21),
                new Rectangle(315, 0, 21, 21),
                new Rectangle(336, 0, 21, 21),
                new Rectangle(357, 0, 21, 21),
                new Rectangle(378, 0, 21, 21),
                new Rectangle(399, 0, 21, 21),
                new Rectangle(420, 0, 21, 21)}));

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
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
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
                            new Rectangle(273, 21, 21, 21),
                            new Rectangle(294, 21, 21, 21),
                            new Rectangle(315, 21, 21, 21),
                            new Rectangle(336, 21, 21, 21),
                            new Rectangle(357, 21, 21, 21),
                            new Rectangle(378, 21, 21, 21),
                            new Rectangle(399, 21, 21, 21),
                            new Rectangle(420, 21, 21, 21),
                        }},
                    266,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Walk",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
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
                            new Rectangle(273, 63, 21, 21),
                            new Rectangle(294, 63, 21, 21),
                            new Rectangle(315, 63, 21, 21),
                            new Rectangle(336, 63, 21, 21),
                            new Rectangle(357, 63, 21, 21),
                            new Rectangle(378, 63, 21, 21),
                            new Rectangle(399, 63, 21, 21),
                            new Rectangle(420, 63, 21, 21),
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
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
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
                            new Rectangle(273, 42, 21, 21),
                            new Rectangle(294, 42, 21, 21),
                            new Rectangle(315, 42, 21, 21),
                            new Rectangle(336, 42, 21, 21),
                            new Rectangle(357, 42, 21, 21),
                            new Rectangle(378, 42, 21, 21),
                            new Rectangle(399, 42, 21, 21),
                            new Rectangle(420, 42, 21, 21),
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
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
                        },},
                    216,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Hold",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
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
                            new Rectangle(273, 84, 21, 21),
                            new Rectangle(294, 84, 21, 21),
                            new Rectangle(315, 84, 21, 21),
                            new Rectangle(336, 84, 21, 21),
                            new Rectangle(357, 84, 21, 21),
                            new Rectangle(378, 84, 21, 21),
                            new Rectangle(399, 84, 21, 21),
                            new Rectangle(420, 84, 21, 21),
                        },
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
                            new Rectangle(273, 105, 21, 21),
                            new Rectangle(294, 105, 21, 21),
                            new Rectangle(315, 105, 21, 21),
                            new Rectangle(336, 105, 21, 21),
                            new Rectangle(357, 105, 21, 21),
                            new Rectangle(378, 105, 21, 21),
                            new Rectangle(399, 105, 21, 21),
                            new Rectangle(420, 105, 21, 21),
                        }},
                    266,
                    true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Hold");
        }
    }
}
