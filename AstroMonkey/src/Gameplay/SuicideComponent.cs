using System;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AstroMonkey.Gameplay
{
    class SuicideComponent : Component
    {
        public delegate void e();
        public event e Elapsed;

        private int timeLeft;
        bool running = false;

        public SuicideComponent(GameObject parent) : base(parent)
        {
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public void Start(int millis)
        {
            timeLeft = millis;
            running = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            bool elapsed = Tick((int)gameTime.ElapsedGameTime.TotalMilliseconds);
            if(elapsed)
                Suicide();

        }

        private bool Tick(int millis)
        {
            if(!running)
                return false;

            timeLeft -= millis;
            return millis <= 0;
        }

        private void Suicide()
        {
            Elapsed?.Invoke();
            GameManager.DestroyObject(parent);
        }
    }
}
