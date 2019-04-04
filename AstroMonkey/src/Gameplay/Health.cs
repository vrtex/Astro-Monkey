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

		public int maxHealth;
		public int health;

		public Health(GameObject parent) : base(parent)
		{

		}

		public void DeadDamage(DamageInfo damage)
		{
			health = health - damage.value;
			if(health < 0) health = 0;

            //UI.HealthBar hb = parent.GetComponent<UI.HealthBar>();
            //if(hb != null)
            //{
            //	hb.SetValue(GetPercentage());
            //}
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
