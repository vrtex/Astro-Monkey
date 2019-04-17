using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class BaseAlien : Core.GameObject
    {
        protected Vector2 colliderOffset = Vector2.Zero;
        protected float colliderRadius;

        // Nabiał: czy to jest poprawana nazwa?
        protected int healthBarOffset;

        public BaseAlien(Core.Transform transform) : base(transform)
        {
        }

        protected virtual void Load(Core.Transform transform)
        {
            // Physics
            AddComponent(new Body(this));
            AddComponent(new CircleCollider(this, CollisionChanell.Enemy, colliderOffset, colliderRadius));

            // HealthBar
            Gameplay.Health healthComponent = AddComponent(new Gameplay.Health(this));
            UI.HealthBar healthBar = AddComponent(new UI.HealthBar(this, healthBarOffset));
            healthComponent.OnDamageTaken += healthBar.Refresh;
        }
    }
}
