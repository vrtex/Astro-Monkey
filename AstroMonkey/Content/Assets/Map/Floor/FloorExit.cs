using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
	class FloorExit: Floor
	{
		public FloorExit() : this(new Core.Transform())
        {
		}
		public FloorExit(Core.Transform _transform): base(_transform)
        {
			Load(_transform);
		}
		public FloorExit(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
		}
		public FloorExit(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
		}

		private void Load(Core.Transform _transform)
		{
			
		}
	}
}

