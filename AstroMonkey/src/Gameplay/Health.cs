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
        private int currentValue = 100;
		public int CurrentValue {
            get => currentValue;
            set
            {
                currentValue = MathHelper.Clamp(value, 0, MaxHealth);
            }
        }

        public int MaxHealth{
            get => maxHealth;
            set{
                float percentage = GetPercentage();
                maxHealth = value;
                CurrentValue = (int)(percentage * maxHealth);
            }
        }

		public Health(GameObject parent) : base(parent)
		{

		}

		public void DealDamage(DamageInfo damage)
		{
			CurrentValue = CurrentValue - damage.value;
			if(CurrentValue < 0) CurrentValue = 0;

            OnDamageTaken?.Invoke(this, damage);

			if(CurrentValue == 0)
			{
                OnDepleted?.Invoke(this, damage);
                //Parent.Destroy();
			}
		}

        public void Restore(int toRestore)
        {
            CurrentValue += toRestore;
            CurrentValue = MathHelper.Clamp(CurrentValue, 0, maxHealth);
            OnDamageTaken?.Invoke(this, new DamageInfo(null, -toRestore));
        }

        public float GetPercentage()
        {
            return MaxHealth == 0 ? 0f : (float)CurrentValue / (float)MaxHealth;
        }
	}
}
