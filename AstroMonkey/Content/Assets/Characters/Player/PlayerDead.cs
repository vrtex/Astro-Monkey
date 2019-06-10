using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Objects
{
    class PlayerDead : GameObject
    {

        private int height = 21;
        private int size = 21;

        public PlayerDead(Transform transform) : base(transform)
        {
            Load();
        }

        public void Load()
        {
            Console.WriteLine("dead monkey");
            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "monkey", idle01));

            AddComponent(new Graphics.StackAnimator(this));

            //UMIERANIE
            List<Rectangle> dead01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 8, size, size));
            List<Rectangle> dead02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 9, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, dead01, dead02 },
                298,
                false));

            Audio.AudioManager.Instance.PlayerTransform = transform;

            GetComponent<Graphics.StackAnimator>().SetAnimation("Dead");

        }

    }
}
