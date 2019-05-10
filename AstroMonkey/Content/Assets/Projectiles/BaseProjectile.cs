using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BaseProjectile: Core.GameObject
    {
        public Gameplay.DamageInfo Damage { get; set; }
        Collider collider;
		public SoundEffectInstance shootSound;
        public float speed = 800f;
        public int baseDamage = 10;

        public BaseProjectile(Core.Transform transform): base(transform)
        {
            collider = new CircleCollider(this, CollisionChanell.Bullets, Vector2.Zero, 3);

            // loleh
            collider.SetReaction(CollisionChanell.Enemy, ReactType.Overlap);
            // collider.SetReaction(reactions);

            collider.OnBeginOverlap += OnHit;
            collider.OnBlockingCollision += OnBlockingHit;

            AddComponent(collider);
            AddComponent(new Body(this));
            var suicideComponent = AddComponent(new Gameplay.SuicideComponent(this));
            suicideComponent.Start(3000);
            AddComponent(new Navigation.ProjectileMovementComponent(this));
            // Damage = new Gameplay.DamageInfo(null, 10);
        }

        private void OnBlockingHit(Collider thisCollider, Collider otherCollider)
        {
			Destroy();
        }

        protected virtual void OnHit(Collider thisCollider, Collider otherCollider)
        {
            Gameplay.Health enemyHealth = otherCollider.Parent.GetComponent<Gameplay.Health>();
			if(enemyHealth != null)
				enemyHealth.DealDamage(Damage);
			else
				return;
            Destroy();
        }

        public override void Destroy()
        {
            collider.OnBlockingCollision -= OnBlockingHit;
            collider.OnBeginOverlap -= OnHit;
            base.Destroy();
        }
    }
}
