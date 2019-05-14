using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Navigation
{
	class NavigationAgent: Core.Component
	{
		public  GameObject                          target				= null;
		public	List<Assets.Objects.NavPoint>       path				= new List<Assets.Objects.NavPoint>();
		public  Assets.Objects.NavPoint             currNavPoint		= null;

		public	float                               distanceToStop		= 1f * 32f * SceneManager.scale;
		public  float                               distanceToReact		= 12f * 32f * SceneManager.scale;
		public  float                               distanceToNextStep  = 0.4f * 32f * SceneManager.scale;

		public  Navigation.MovementComponent        movement		= null;

		public NavigationAgent(GameObject parent) : base(parent)
		{
			
		}

		public void LoadNavigation()
		{
			foreach(Assets.Objects.NavPoint nav in SceneManager.Instance.currScene.navigationPoints)
			{
				if(Vector2.Distance(parent.transform.position, nav.transform.position) < distanceToStop)
				{
					currNavPoint = nav;
					break;
				}
			}
			if(currNavPoint == null)
			{
				Console.Error.Write("navigation point can not be found");
			}
			movement = (parent as Assets.Objects.BaseAlien).movement;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if(target == null) return;

			if(path.Count == 0)
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
				float distance = Vector2.Distance(target.transform.position, parent.transform.position);
				if(distance < distanceToReact && distance > distanceToStop)
				{
					FindPath();
				}
			}
			else
			{
				Console.WriteLine(path.Count);

				Vector2 temp = new Vector2(path[0].transform.position.X - parent.transform.position.X,
											path[0].transform.position.Y - parent.transform.position.Y);
				temp.Normalize();
				movement.AddMovementInput(temp);
				parent.transform.rotation = (float)Math.PI * 0.5f + movement.CurrentDirection;
				if(Vector2.Distance(path[0].transform.position, parent.transform.position) < distanceToNextStep)
				{
					path.RemoveAt(0);
				}
			}
		}

		private void FindPath()
		{
			path.Add(currNavPoint);
			for(int i = 0; i < 40; ++i)
			{
				path.Add(path.Last().neighbors[Util.RNG.random.Next(0, path.Last().neighbors.Count)]);
			}
			parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Walk");
		}
	}
}
