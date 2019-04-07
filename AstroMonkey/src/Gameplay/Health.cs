using AstroMonkey.Core;
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

		public int maxHealth = 100;
		public int health = 100;

		public Health(GameObject parent) : base(parent)
		{

		}

		public void DeadDamage(DamageInfo damage)
		{
            Console.WriteLine(damage.value);
			health = health - damage.value;
			if(health < 0) health = 0;

            OnDamageTaken?.Invoke(this, damage);
			
			if(health == 0)
			{
				//wywołaj śmierć
			}
		}

        public float GetPercentage()
        {
            return maxHealth == 0 ? 0f : (float)health / (float)maxHealth;
        }
	}
}
