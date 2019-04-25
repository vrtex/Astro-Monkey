using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AstroMonkey.Gameplay
{
    class Gun : Component
	{
		List<Type> ammoTypes = new List<Type>
		{
			typeof(Assets.Objects.AlienBullet),
			typeof(Assets.Objects.Rocket),
			typeof(Assets.Objects.PistolBullet)
		};
		List<Type>.Enumerator currentAmmo;
		private Audio.AudioSource boomComp;

		public Gun(GameObject parent) : base(parent)
		{
			currentAmmo = ammoTypes.GetEnumerator();
			currentAmmo.MoveNext();
            currentAmmo.MoveNext();
            //currentAmmo.MoveNext();

            boomComp = Parent.AddComponent(new Audio.AudioSource(Parent, Audio.SoundContainer.Instance.GetSoundEffect("GunShoot")));
		}

		public void Shoot(Vector2 targetPosition)
		{

			Assets.Objects.BaseProjectile projectile = (Assets.Objects.BaseProjectile)Activator.CreateInstance(currentAmmo.Current, new object[] {
				new Transform(Parent.transform)});
			boomComp.SoundEffect = projectile.shootSound;
			boomComp.Play();

			Vector2 parentPosition = parent.transform.position;
			Vector2 direction = targetPosition - parentPosition;
			direction.Normalize();

			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Direction = direction;
			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Velocity = projectile.speed;

			projectile.Damage = new DamageInfo(parent, projectile.baseDamage);

			GameManager.SpawnObject(projectile);
		}
	}
}
