using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Objects
{
    class Floor: Core.GameObject
    {
		public List<NavPoint>       navPoints = new List<NavPoint>();

        public Floor(Core.Transform transform): base(transform)
        {
			navPoints.Add(new NavPoint(new Core.Transform(transform.position + new Vector2(-8, -8) * Core.SceneManager.scale, transform.scale)));
			navPoints.Add(new NavPoint(new Core.Transform(transform.position + new Vector2(8, -8) * Core.SceneManager.scale, transform.scale)));
			navPoints.Add(new NavPoint(new Core.Transform(transform.position + new Vector2(-8, 8) * Core.SceneManager.scale, transform.scale)));
			navPoints.Add(new NavPoint(new Core.Transform(transform.position + new Vector2(8, 8) * Core.SceneManager.scale, transform.scale)));

			foreach(Core.GameObject go in navPoints)
			{
				Core.SceneManager.Instance.currScene.objects.Add(go);
#if DRAW_NAVIGATION
				Graphics.ViewManager.Instance.AddSprite(go);
#endif
			}

		}
    }
}
