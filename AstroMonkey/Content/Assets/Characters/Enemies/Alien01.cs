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
        public Alien01(Core.Transform _transform)
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
            AddComponent(new Graphics.Sprite(this, "alien01", new List<Rectangle> {
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

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }
    }
}
