using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Gameplay
{
	class Health: Component
	{
        public delegate void DamageEvent(Health damaged, DamageInfo damageInfo);
        public event DamageEvent OnDamageTaken;
        public event DamageEvent OnDepleted;

		private int maxHealth = 100;
		private int health = 100;

        public int MaxHealth{
            get => maxHealth;
            set{
                float percentage = GetPercentage();
                maxHealth = value;
                health = (int)(percentage * maxHealth);
            }
        }

		public Health(GameObject parent) : base(parent)
		{

		}

		public void DealDamage(DamageInfo damage)
		{
			health = health - damage.value;
			if(health < 0) health = 0;

            OnDamageTaken?.Invoke(this, damage);

			if(health == 0)
			{
                OnDepleted?.Invoke(this, damage);
                //Parent.Destroy();
			}
		}

        public void Restore(int toRestore)
        {
            health += toRestore;
            health = MathHelper.Clamp(health, 0, maxHealth);
            OnDamageTaken?.Invoke(this, new DamageInfo(null, -toRestore));
        }

        public float GetPercentage()
        {
            return MaxHealth == 0 ? 0f : (float)health / (float)MaxHealth;
        }
	}
}
