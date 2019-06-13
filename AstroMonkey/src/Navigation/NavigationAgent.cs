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

		public	float                               distanceToStop		= 0.7f * 32f * SceneManager.scale;
		public  float                               distanceToReact		= 9f * 32f * SceneManager.scale;
		public  float                               distanceToNextStep  = 0.6f * 32f * SceneManager.scale;
		public  float                               distanceToRush      = 2f * 32f * SceneManager.scale;

		public  float                               pathTimer			= 1.8f;
		public  float                               pathReactionTime	= 1.8f;

		public  MovementComponent					movement			= null;
		public  Gameplay.Health                     health              = null;

		private bool                                roar                = true;
		public  bool                                rush                = true;

		public NavigationAgent(GameObject parent) : base(parent)
		{
			
		}

		public void LoadNavigation()
		{
			foreach(Assets.Objects.NavPoint nav in SceneManager.Instance.currScene.navigationPoints)
			{
				if(Vector2.Distance(parent.transform.position, nav.transform.position) < distanceToStop / 1.5)
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
			health = (parent as Assets.Objects.BaseAlien).healthComponent;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if(target == null) return;

			float distance = Vector2.Distance(target.transform.position, parent.transform.position);
			if((distance <= distanceToRush && distanceToRush != -1) || (health.CurrentValue < health.MaxHealth && rush))
			{
				if(distance > distanceToStop)
				{
					Vector2 temp = target.transform.position - parent.transform.position;
					temp.Normalize();
					movement.AddMovementInput(temp);
				}
				else
				{
					movement.AddMovementInput(Vector2.Zero);
				}
			}
			else if(path.Count == 0)
			{
				pathTimer -= gameTime.ElapsedGameTime.Milliseconds / 1000f;
				if(pathTimer <= 0)
				{
					if(distance < distanceToReact && distance > distanceToStop)
					{
						Search();
						pathTimer = pathReactionTime;
					}
				}
			}
			else
			{
				if(distance > distanceToStop)
				{
					pathTimer -= gameTime.ElapsedGameTime.Milliseconds / 1000f;
					if(pathTimer <= 0)
					{
						pathTimer = pathReactionTime;
						Search();
					}
					if(path.Count == 0) return;

					Vector2 temp = path[0].transform.position - parent.transform.position;
					temp.Normalize();
					movement.AddMovementInput(temp);
					if(Vector2.Distance(path[0].transform.position, parent.transform.position) < distanceToNextStep)
					{
						currNavPoint = path.ElementAt(0);
						path.RemoveAt(0);
						if(path.Count == 0) movement.AddMovementInput(Vector2.Zero);
					}
				}
				else
				{
					Vector2 temp = target.transform.position - parent.transform.position;
					movement.AddMovementInput(Vector2.Zero);
					currNavPoint = path.ElementAt(0);
					path.Clear();
				}
			}
		}

		private void Search()
		{
			Vector2 targetPosition = target.transform.position;
			var openList = new List<Assets.Objects.NavPoint>();
			var closedList = new List<Assets.Objects.NavPoint>();
			float g = 0f; //odległość od początku
			bool goodDistance = false;

			openList.Add(currNavPoint);
			currNavPoint.parent = null;
			currNavPoint.steps = 0;

			Assets.Objects.NavPoint current = null;

			while(openList.Count > 0)
			{
				var lowest = openList.Min(l => l.F);
				current = openList.First(l => l.F == lowest);

				closedList.Add(current);
				openList.Remove(current);

				if(closedList.FirstOrDefault(l => Vector2.Distance(l.transform.position, targetPosition) < distanceToStop) != null)
				{
					goodDistance = true;
					break;
				}

				g += 32f * SceneManager.scale;
				if(g > (distanceToReact + 2f) * 32f * SceneManager.scale) //przekroczenie maksymalnej odległości między graczem, kosmitą
				{
					goodDistance = false;
					break;
				}

				foreach(var neighbor in current.neighbors)
				{
					if(!neighbor.isActive) continue;
					if(current.steps > 10) continue;

					if(closedList.FirstOrDefault(l => l.transform == neighbor.transform) != null)
						continue;

					if(openList.FirstOrDefault(l => l.transform == neighbor.transform) == null)
					{
						neighbor.G = g;
						neighbor.H = heuristic(neighbor.transform.position, targetPosition);
						neighbor.F = neighbor.G + neighbor.H;
						neighbor.parent = current;
						neighbor.steps = current.steps + 1;

						openList.Insert(0, neighbor);
					}
					else
					{
						if(g + neighbor.H < neighbor.F)
						{
							neighbor.G = g;
							neighbor.F = neighbor.G + neighbor.H;
							neighbor.parent = current;
							neighbor.steps = current.steps + 1;
						}
					}
				}
			}

			path.Clear();
			if(goodDistance)
			{
				//currNavPoint = current;
				while(current.parent != null)
				{
					path.Add(current);
					current = current.parent;
				}
			}

			if(roar && path.Count() > 0)
			{
				roar = false;
				(parent as Assets.Objects.BaseAlien).lookSFX.Play();
			}
		}

		private float heuristic(Vector2 a, Vector2 b)
		{
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}
		
	}
}
