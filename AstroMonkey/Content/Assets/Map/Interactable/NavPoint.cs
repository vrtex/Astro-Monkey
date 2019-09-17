using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Objects
{
	class NavPoint: Core.GameObject
	{
		public List<NavPoint>       neighbors	= new List<NavPoint>();
		public NavPoint             parent      = null;
		public float				F			= 0; //suma G + H
		public float                G			= 0; //odległość od punktu startu
		public float                H			= 0; //przewidywane dystans do końca
		public bool                 isActive    = true;
		public int                  steps       = 0;

		public NavPoint() : this(new Core.Transform())
        {

		}

		public NavPoint(Core.Transform _transform) : base(_transform)
        {
			Load(_transform);
		}
		public NavPoint(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
		}

		public NavPoint(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
		}

		private void Load(Core.Transform _transform)
		{
			transform = _transform;

			//podgląd dla punktów nawigacyjnych
#if DRAW_NAVIGATION
			List<Rectangle> temp = new List<Rectangle>();
			temp.Add(new Rectangle(0, 0, 32, 32));

			AddComponent(new Graphics.Sprite(this, "navigationPoint", temp));

#endif

		}
	}
}
