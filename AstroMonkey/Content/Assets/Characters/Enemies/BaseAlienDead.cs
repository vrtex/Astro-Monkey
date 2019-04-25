using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class BaseAlienDead : Core.GameObject
    {
        protected float timeLimit = 3f;
        private float timeElapsed = 0f;

        public BaseAlienDead(Core.Transform transform) : base(transform)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed >= timeLimit)
                Destroy();
        }
    }
}
