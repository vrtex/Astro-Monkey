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
		public  Util.MinHeap<Assets.Objects.NavPoint>	tempPath        = new Util.MinHeap<Assets.Objects.NavPoint>();
		public  List<Assets.Objects.NavPoint>       pathToClear         = new List<Assets.Objects.NavPoint>();
		public  Assets.Objects.NavPoint             currNavPoint		= null;

		public	float                               distanceToStop		= 0.8f * 32f * SceneManager.scale;
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
				if(Vector2.Distance(parent.transform.position, nav.transform.position) < distanceToStop / 2)
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

			float distance = Vector2.Distance(target.transform.position, parent.transform.position);
			if(path.Count == 0)
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
				if(distance < distanceToReact && distance > distanceToStop)
				{
					FindPath();
				}
			}
			else
			{
				if(distance > distanceToStop)
				{
					Vector2 temp = path[0].transform.position - parent.transform.position;
					temp.Normalize();
					movement.AddMovementInput(temp);
					parent.transform.rotation = (float)Math.PI * 0.5f + movement.CurrentDirection;
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
					parent.transform.rotation = (float)(Math.PI * 0.5 + Math.Atan2(temp.Y, temp.X));
					currNavPoint = path.ElementAt(0);
					path.Clear();
				}
			}
		}

		private void FindPath()
		{
			Search();

			parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Walk");
		}

		private void Search()
		{
			var openList = new List<Assets.Objects.NavPoint>();
			var closedList = new List<Assets.Objects.NavPoint>();
			float g = 0f; //odległość od początku

			openList.Add(currNavPoint);
			currNavPoint.parent = null;

			Assets.Objects.NavPoint current = null;

			while(openList.Count > 0)
			{
				var lowest = openList.Min(l => l.F);
				current = openList.First(l => l.F == lowest);

				closedList.Add(current);
				openList.Remove(current);

				if(closedList.FirstOrDefault(l => Vector2.Distance(l.transform.position, target.transform.position) < distanceToStop) != null)
					break;

				g += 32f * SceneManager.scale;

				foreach(var neighbor in current.neighbors)
				{
					if(closedList.FirstOrDefault(l => l.transform == neighbor.transform) != null)
						continue;

					if(openList.FirstOrDefault(l => l.transform == neighbor.transform) == null)
					{
						neighbor.G = g;
						neighbor.H = heuristic(neighbor.transform.position, target.transform.position);
						neighbor.F = neighbor.G + neighbor.H;
						neighbor.parent = current;

						openList.Insert(0, neighbor);
					}
					else
					{
						if(g + neighbor.H < neighbor.F)
						{
							neighbor.G = g;
							neighbor.F = neighbor.G + neighbor.H;
							neighbor.parent = current;
						}
					}
				}
			}

			path.Clear();
			while(current.parent != null)
			{
				path.Add(current);
				current = current.parent;
			}
		}

		private float heuristic(Vector2 a, Vector2 b)
		{
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}
		
	}
}
