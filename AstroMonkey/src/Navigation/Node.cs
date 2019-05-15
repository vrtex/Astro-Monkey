using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Navigation
{
	class Node
	{
		public Assets.Objects.NavPoint  nav     = null;
		public bool                     visited = false;

		public Node(Assets.Objects.NavPoint navPoint)
		{
			nav = navPoint;
		}
	}
}
