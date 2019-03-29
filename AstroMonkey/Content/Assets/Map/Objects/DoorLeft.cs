using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class DoorLeft: Core.GameObject
    {
        public DoorLeft() : this(new Core.Transform())
        {
        }

        public DoorLeft(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public DoorLeft(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public DoorLeft(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private int height = 32;
        private int size = 32;

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));

            AddComponent(new Graphics.Sprite(this, "doorLeft", idle01));

            AddComponent(new Graphics.StackAnimator(this));

            //OTWIERANIE
            List<Rectangle> open01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) open01.Add(new Rectangle(i * size, size, size, size));
            List<Rectangle> open02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) open02.Add(new Rectangle(i * size, size * 2, size, size));
            List<Rectangle> open03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) open03.Add(new Rectangle(i * size, size * 3, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Open",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, open01, open02, open03 },
                166,
                false));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Close",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { open03, open02, open01, idle01 },
                166,
                false));

        }
    }

}
