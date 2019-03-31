using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Navigation
{
    class ProjectileMovementComponent : Core.Component
    {

        public Vector2 Direction { get; private set; }
        public float Velocity { get; private set; }

        public ProjectileMovementComponent(GameObject parent, Vector2 direction, float velocity = 1f) : base(parent)
        {
            Direction = direction;
            Velocity = velocity;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 displacement = Direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 previousPosition = parent.transform.position;
            parent.transform.position = previousPosition + displacement;
        }
    }
}
