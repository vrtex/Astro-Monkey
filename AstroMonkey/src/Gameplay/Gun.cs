using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AstroMonkey.Gameplay
{
    struct AmmoInfo
    {

        public Type bulletType;
        public float fireDelay;
        public int currentAmount;

        public static implicit operator Type(AmmoInfo ammoInfo)
        {
            return ammoInfo.bulletType;
        }
    }

    class Gun : Component
    {
        private Audio.AudioSource ShootSoundComponent;

        private List<AmmoInfo> ammoTypes = new List<AmmoInfo>
        {
            new AmmoInfo { bulletType = typeof(Assets.Objects.AlienBullet), fireDelay = 0.1f, currentAmount = 10 },
            new AmmoInfo { bulletType = typeof(Assets.Objects.Rocket), fireDelay = 0.75f, currentAmount = 3},
            new AmmoInfo { bulletType = typeof(Assets.Objects.PistolBullet), fireDelay = 0.2f, currentAmount = 20}
        };
        private int currentAmmoType = 0;
        private float cooldownLeft = 0f;

		public Gun(GameObject parent) : base(parent)
		{
            currentAmmoType = 0;

            ShootSoundComponent = Parent.AddComponent(new Audio.AudioSource(Parent, Audio.SoundContainer.Instance.GetSoundEffect("GunShoot")));
		}

		public void Shoot(Vector2 targetPosition)
		{
            if(cooldownLeft > 0)
                return;
			Assets.Objects.BaseProjectile projectile = (Assets.Objects.BaseProjectile)Activator.CreateInstance(ammoTypes[currentAmmoType], new object[] {
				new Transform(Parent.transform)});
			ShootSoundComponent.SoundEffect = projectile.shootSound;
			ShootSoundComponent.Play();

			Vector2 parentPosition = parent.transform.position;
			Vector2 direction = targetPosition - parentPosition;
			direction.Normalize();

			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Direction = direction;
			projectile.GetComponent<Navigation.ProjectileMovementComponent>().Velocity = projectile.speed;

			projectile.Damage = new DamageInfo(parent, projectile.baseDamage);

			GameManager.SpawnObject(projectile);

            cooldownLeft = ammoTypes[currentAmmoType].fireDelay;
		}

        public void ChangeAmmo(bool moveUp)
        {
            if(cooldownLeft > 0)
                return;
            currentAmmoType += moveUp ? 1 : -1;
            currentAmmoType = currentAmmoType % ammoTypes.Count;
            while(currentAmmoType < 0) currentAmmoType += ammoTypes.Count;
            Console.WriteLine(ammoTypes[currentAmmoType].bulletType);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            cooldownLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
