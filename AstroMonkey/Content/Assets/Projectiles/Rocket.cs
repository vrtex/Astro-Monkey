using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;
using AstroMonkey.Core;

namespace AstroMonkey.Assets.Objects
{
    class Rocket: BaseProjectile
    {
        private readonly float areaRange = Scene.tileSize * 3f;

        public Rocket() : this(new Core.Transform())
        {
        }

        public Rocket(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public Rocket(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Rocket(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "rocket", new List<Rectangle>() { new Rectangle(0, 0, 3, 5) }));
			shootSound = Audio.SoundContainer.Instance.GetSoundEffect("LuncherShoot").CreateInstance();
            speed = 500f;
            baseDamage = 50;
		}

        protected override void OnBlockingHit(Collider thisCollider, Collider otherCollider)
        {
            DealAreaDamage(otherCollider.Parent);
            base.OnBlockingHit(thisCollider, otherCollider);
        }

        protected override void OnHit(Collider thisCollider, Collider otherCollider)
        {
            DealAreaDamage(otherCollider.Parent);
            base.OnHit(thisCollider, otherCollider);
        }

        private void DealAreaDamage(Core.GameObject toIgnore)
        {
            List<BaseAlien> aliens = SceneManager.Instance.currScene.GetObjectsByClass<Assets.Objects.BaseAlien>();
            foreach(BaseAlien alien in aliens)
            {
                if(toIgnore == alien)
                    continue;

                float distance = (alien.transform.position - transform.position).Length();
                if(distance > areaRange)
                    continue;

                Gameplay.Health health = alien.GetComponent<Gameplay.Health>();
                if(health == null)
                    continue;


                health.DealDamage(new Gameplay.DamageInfo()
                { damageDealer = Damage.damageDealer, value = (int)(Damage.value * 0.5)});
            }

            RocketExplosion explosion = new RocketExplosion(new Transform(transform));
            GameManager.SpawnObject(explosion);
        }
    }
}
