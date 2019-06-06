using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
	class TheBegining: Core.Scene
	{
		List<Graphics.Widget> scenes			= new List<Graphics.Widget>();

		public override void Load()
		{
			base.Load();

			for(int i = 5; i >= 1; --i)
			{
				scenes.Add(new Graphics.Widget(new Vector2(0f, 0f), new Vector2(1f, 1f)));
				scenes.Last().Texture = Graphics.SpriteContainer.Instance.GetImage("scene0" + i);
			}

			Graphics.WidgetManager.AddWidget(scenes.Last());
		}
	}
}
