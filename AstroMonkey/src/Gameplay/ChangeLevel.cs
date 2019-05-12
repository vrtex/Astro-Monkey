using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using System.Diagnostics;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Gameplay
{
	class ChangeLevel: Component
	{
		public string               nextLevel = "";

		public ChangeLevel(GameObject parent) : base(parent)
		{
			parent.GetComponent<Collider>().OnBeginOverlap += OnEnter;
		}

		public void OnEnter(Collider c1, Collider c2)
		{
			Debug.WriteLine("enter!");
			GameManager.Instance.NextScene = nextLevel;
		}


	}
}
