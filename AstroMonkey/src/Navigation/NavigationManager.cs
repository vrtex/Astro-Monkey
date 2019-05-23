using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Navigation
{
	class NavigationManager
	{
		public static NavigationManager Instance { get; private set; } = new NavigationManager();

		private NavigationManager()
		{

		}
	}
}
