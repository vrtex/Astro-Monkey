using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AstroMonkey.Gameplay
{
    struct AmmoInfo
    {
        public float fireDelay;
        public int currentAmount;
    }

    class Gun : Component
    {
        List<Type> ammoTypes = new List<Type>
        {
            typeof(Assets.Objects.AlienBullet),
            typeof(Assets.Objects.Rocket),
            typeof(Assets.Objects.PistolBullet)
        };
        int currentAmmoType = 0;
        private Audio.AudioSource boomComp;

        private Dictionary<Type, AmmoInfo> currentAmmoInfo = new Dictionary<Type, AmmoInfo>
        {
            [typeof(Assets.Objects.AlienBullet)] = new AmmoInfo { fireDelay = 0.1f, currentAmount = 10 },
            [typeof(Assets.Objects.Rocket)] = new AmmoInfo { fireDelay = 0.75f, currentAmount = 3},
            [typeof(Assets.Objects.PistolBullet)] = new AmmoInfo { fireDelay = 0.2f, currentAmount = 20}
        };
        private float cooldownLeft = 0f;

		public Gun(GameObject parent) : base(parent)
		{
            currentAmmoType = 0;

            boomComp = Parent.AddComponent(new Audio.AudioSource(Parent, Audio.SoundContainer.Instance.GetSoundEffect("GunShoot")));
		}

		public void Shoot(Vector2 targetPosition)
		{
            if(cooldownLeft > 0)
                return;
			Assets.Objects.BaseProjectile projectile = (Assets.Objects.BaseProjectile)Activator.CreateInstance(ammoTypes[currentAmmoType], new object[] {
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

            cooldownLeft = currentAmmoInfo[ammoTypes[currentAmmoType]].fireDelay;
		}

        public void ChangeAmmo(bool moveUp)
        {
            currentAmmoType += moveUp ? 1 : -1;
            currentAmmoType = currentAmmoType % ammoTypes.Count;
            while(currentAmmoType < 0) currentAmmoType += ammoTypes.Count;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            cooldownLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
