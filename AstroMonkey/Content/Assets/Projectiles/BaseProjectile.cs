using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BaseProjectile: Core.GameObject
    {
        public BaseProjectile(Core.Transform transform): base(transform)
        {
            Collider collider = new CircleCollider(this, CollisionChanell.Bullets, Vector2.Zero, 3);

            var reactions = collider.GetReaction();
            reactions[CollisionChanell.Enemy] = ReactType.Overlap;
            collider.SetReaction(reactions);

            collider.OnBeginOverlap += OnHit;
            AddComponent(collider);
            AddComponent(new Body(this));
            AddComponent(new Gameplay.SuicideComponent(this));
            AddComponent(new Navigation.ProjectileMovementComponent(this));
        }

        protected virtual void OnHit(Collider c1, Collider c2)
        {
        }
    }
}
