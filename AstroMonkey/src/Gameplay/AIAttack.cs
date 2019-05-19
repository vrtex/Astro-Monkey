using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AstroMonkey.Gameplay
{
	class AIAttack : Core.Component
	{
		public	Core.GameObject					target				= null;

		public	float							attackDistance		= 1.25f * 32f * Core.SceneManager.scale;
		public	float							cooldown			= 1.5f;
		public  float							currCooldown		= 0f;

		public  int								damage              = 10;

		public  bool							shoot               = false;

		public AIAttack(Core.GameObject parent) : base(parent)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if(target != null)
			{
				if(Vector2.Distance(target.transform.position, parent.transform.position) <= attackDistance)
				{
					if(currCooldown <= 0)
					{
						(parent as Assets.Objects.BaseAlien).state = Util.EnemyState.Attack;
						(parent as Assets.Objects.BaseAlien).anim.SetAnimation("Attack");
						(parent as Assets.Objects.BaseAlien).anim.SetNextAnimation("Idle");
						currCooldown = cooldown;

						if(shoot)
						{
							parent.GetComponent<Gun>().Shoot(target.transform.position);
						}
						else
						{
							target.GetComponent<Health>().DealDamage(new DamageInfo(parent, damage));
							(parent as Assets.Objects.BaseAlien).attackSFX.Play();
							(target as Assets.Objects.Player).hitSFX.Play();
						}
					}
					else
					{
						currCooldown -= gameTime.ElapsedGameTime.Milliseconds / 1000f;
					}
				}
			}
		}
	}
}
