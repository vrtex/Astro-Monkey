using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Navigation
{
    class ProjectileMovementComponent : Core.Component
    {

        private Vector2 direction;
        public Vector2 Direction {
            get => direction;
            set
            {
                direction = value;
                shouldMove = !Util.Statics.IsNearlyEqual(direction, Vector2.Zero);
            }
        }
        public float Velocity { get; set; }
        private bool shouldMove = false;

        public ProjectileMovementComponent(GameObject parent) : base(parent)
        {
            Direction = Vector2.Zero;
            Velocity = 1f;
        }

        public override void Update(GameTime gameTime)
        {
            if(!shouldMove)
                return;
            Vector2 displacement = Direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 previousPosition = parent.transform.position;
            parent.transform.position = previousPosition + displacement;
        }
    }
}
