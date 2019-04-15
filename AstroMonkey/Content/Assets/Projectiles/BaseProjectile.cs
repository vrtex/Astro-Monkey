using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BaseProjectile: Core.GameObject
    {
        public Gameplay.DamageInfo Damage { get; set; }

        public BaseProjectile(Core.Transform transform): base(transform)
        {
            Collider collider = new CircleCollider(this, CollisionChanell.Bullets, Vector2.Zero, 3);

            var reactions = collider.GetReaction();
            reactions[CollisionChanell.Enemy] = ReactType.Overlap;
            collider.SetReaction(reactions);

            collider.OnBeginOverlap += OnHit;
            collider.OnBlockingCollision += OnBlockingHit;
            AddComponent(collider);
            AddComponent(new Body(this));
            AddComponent(new Gameplay.SuicideComponent(this));
            AddComponent(new Navigation.ProjectileMovementComponent(this));
            // Damage = new Gameplay.DamageInfo(null, 10);
        }

        private void OnBlockingHit(Collider thisCollider, Collider otherCollider)
        {
            Destroy();
        }

        public void Report()
        {
            Console.WriteLine(Damage.damageDealer == null);
        }

        protected virtual void OnHit(Collider thisCollider, Collider otherCollider)
        {
            Console.WriteLine(Damage.damageDealer == null);
            Gameplay.Health enemyHealth = otherCollider.Parent.GetComponent<Gameplay.Health>();
            if(enemyHealth != null)
                enemyHealth.DeadDamage(Damage);
            Destroy();
        }
    }
}
