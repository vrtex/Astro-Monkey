using AstroMonkey.Core;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace AstroMonkey.Assets.Objects
{
	class BaseAlien: Core.GameObject
	{
		protected Vector2					colliderOffset = Vector2.Zero;
		protected float						colliderRadius;

		protected Audio.AudioSource			walkSFX;
		protected Audio.AudioSource			hitSFX;
		protected Audio.AudioSource			idleSFX;
		protected Audio.AudioSource			lookSFX;
		public Audio.AudioSource			attackSFX;
		public Audio.AudioSource			nearSFX;

		protected UI.HealthBar				healthBar;
		protected Gameplay.Health			healthComponent;
		protected int						maxHealth = 100;

		protected Type						corp        = null;

		protected int						healthBarOffset;

		public Gameplay.AIAttack			aiAttack;
		public Navigation.NavigationAgent   navigation;

		public BaseAlien(Core.Transform transform) : base(transform)
		{
		}

		public override void Destroy()
		{
			healthComponent.OnDamageTaken -= healthBar.Refresh;
			healthComponent.OnDamageTaken -= OnDamage;
			healthComponent.OnDepleted -= Die;
			base.Destroy();
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
			healthComponent.OnDepleted += Die;

			// AI
			aiAttack = AddComponent(new Gameplay.AIAttack(this));
			navigation = AddComponent(new Navigation.NavigationAgent(this));
		}


		private void OnDamage(Gameplay.Health damaged, Gameplay.DamageInfo damageInfo)
		{
			hitSFX.Stop();
			hitSFX.Play();
		}

		private void Die(Gameplay.Health damaged, Gameplay.DamageInfo damageInfo)
		{
			SpawnCorpse();
			Destroy();
		}

		private void SpawnCorpse()
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

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if(aiAttack != null)
			{
				aiAttack.Update(gameTime);
			}
		}
	}
}
