using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class RocketExplosion : Core.GameObject
    {
        private float timeToLive;
        private float elapsed = 0;
        public RocketExplosion(Transform transform) : base(transform)
        {
            transform.scale = new Vector2(10, 10);

            int spriteHeight = 13;
            int spriteSize = 21;

            AddComponent(new Graphics.StackAnimator(this));


            List<List<Rectangle>> frames = new List<List<Rectangle>>();

            for(int i = 0; i < 6; ++i)
            {
                List<Rectangle> currentFrame = new List<Rectangle>();
                for(int h = 0; h < spriteHeight; ++h)
                    currentFrame.Add(new Rectangle(h * spriteSize, i * spriteSize, spriteSize, spriteSize));
                frames.Add(currentFrame);
            }
            AddComponent(new Graphics.Sprite(this, "explosion", frames[0]));


            int animSpeed = 46;
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                frames,
                animSpeed,
                false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Dead");

            AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("LuncherHit"))).Play();

            timeToLive = animSpeed * frames.Count;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapsed >= timeToLive)
                Destroy();
        }
    }
}
