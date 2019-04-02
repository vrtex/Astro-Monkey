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
		public int maxHealth;
		public int health;

		public Health(GameObject parent) : base(parent)
		{

		}

		public void DeadDamage(int value)
		{
			health = health - value;
			if(health < 0) health = 0;

			UI.HealthBar hb = parent.GetComponent<UI.HealthBar>();
			if(hb != null)
			{
				hb.SetValue(((float)health) / ((float)maxHealth));
			}
			
			if(health == 0)
			{
				//wywołaj śmierć
			}
		}
	}
}
