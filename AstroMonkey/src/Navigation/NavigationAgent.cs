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
		public  Queue<Assets.Objects.NavPoint>      tempPath            = new Queue<Assets.Objects.NavPoint>();
		public  List<Assets.Objects.NavPoint>       pathToClear         = new List<Assets.Objects.NavPoint>();
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
						path.RemoveAt(0);
					}
				}
				else
				{
					Vector2 temp = target.transform.position - parent.transform.position;
					movement.AddMovementInput(Vector2.Zero);
					parent.transform.rotation = (float)(Math.PI * 0.5 + Math.Atan2(temp.Y, temp.X));
				}
			}
		}

		private void FindPath()
		{
			Search();
			/*path.Add(currNavPoint);

			for(int i = 0; i < 40; ++i)
			{
				path.Add(path.Last().neighbors[Util.RNG.random.Next(0, path.Last().neighbors.Count)]);
			}*/
			parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Walk");
		}

		private void Search()
		{
			tempPath.Enqueue(currNavPoint);
			tempPath.Last().visited = true;
			pathToClear.Add(tempPath.Last());

			while(tempPath.Count != 0)
			{
				Assets.Objects.NavPoint front = tempPath.Peek();
				foreach(Assets.Objects.NavPoint next in front.neighbors)
				{
					if(!next.visited)
					{
						tempPath.Enqueue(next);
						next.visited = true;
						next.parent = front;
						pathToClear.Add(next);

						if(Vector2.Distance(target.transform.position, next.transform.position) < distanceToStop)
						{
							while(tempPath.Count != 0)
							{
								path.Add(tempPath.Dequeue());
							}
							break;
						}
					}
				}
			}

			ClearVisited();
		}

		private void ClearVisited()
		{
			foreach(Assets.Objects.NavPoint nav in pathToClear)
			{
				nav.visited = false;
				nav.parent = null;
			}
			pathToClear.Clear();
		}

		private float heuristic(Vector2 a, Vector2 b)
		{
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}
		
	}
}
