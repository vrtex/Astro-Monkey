using AstroMonkey.Core;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BaseAlien : Core.GameObject
    {
        protected Vector2			colliderOffset = Vector2.Zero;
        protected float				colliderRadius;

		protected Audio.AudioSource walkSFX;
		protected Audio.AudioSource hitSFX;
		protected Audio.AudioSource idleSFX;
		protected Audio.AudioSource lookSFX;

		protected UI.HealthBar      healthBar;
		protected Gameplay.Health   healthComponent;
        protected int               maxHealth = 100;

		protected Type				corp		= null;

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
            healthComponent = AddComponent(new Gameplay.Health(this));
            healthComponent.MaxHealth = maxHealth;
            healthBar = AddComponent(new UI.HealthBar(this, healthBarOffset));
            healthComponent.OnDamageTaken += healthBar.Refresh;
			healthComponent.OnDamageTaken += OnDamage;

			OnDestroy += SpawnCorps;
		}

		private void OnDamage(Gameplay.Health damaged, Gameplay.DamageInfo damageInfo)
		{
			hitSFX.Stop();
			hitSFX.Play();
		}

		private void SpawnCorps(GameObject destroyed)
		{
            if(corp == null)
                throw new ApplicationException("give me corpse dummy");

			GameManager.SpawnObject(
				(GameObject)Activator.CreateInstance(corp, new object[] {
				new Vector2(transform.position.X, transform.position.Y),
				new Vector2(SceneManager.scale, SceneManager.scale),
				transform.rotation
				}));
		}
	}
}
