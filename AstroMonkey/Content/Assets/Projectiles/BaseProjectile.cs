﻿using AstroMonkey.Core;
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
        protected Collider collider;
		public SoundEffectInstance shootSound;
        public float speed = 800f;
        public int baseDamage = 10;

        public BaseProjectile(Core.Transform transform): base(transform)
        {
            collider = new CircleCollider(this, CollisionChanell.Bullets, Vector2.Zero, 3);

            collider.OnBeginOverlap += OnHit;
            collider.OnBlockingCollision += OnBlockingHit;

            AddComponent(collider);
            AddComponent(new Body(this));
            var suicideComponent = AddComponent(new Gameplay.SuicideComponent(this));
            suicideComponent.Start(3000);
            AddComponent(new Navigation.ProjectileMovementComponent(this));
            // Damage = new Gameplay.DamageInfo(null, 10);
        }

        public virtual void Start(Vector2 target, GameObject parent)
        {
            Vector2 direction = target - parent.transform.position;
            direction.Normalize();

            GetComponent<Navigation.ProjectileMovementComponent>().Direction = direction;
            GetComponent<Navigation.ProjectileMovementComponent>().Velocity = speed;

            Damage = new Gameplay.DamageInfo(parent, baseDamage);
        }

        protected virtual void OnBlockingHit(Collider thisCollider, Collider otherCollider)
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
