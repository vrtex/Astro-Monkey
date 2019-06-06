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
        Input.ActionBinding progressBinding = new Input.ActionBinding(Input.EMouseButton.Left);
        private readonly string bindName = "progress";

		public override void Load()
		{
			base.Load();

            Input.InputManager.Manager.AddActionBinding(bindName, progressBinding);
            progressBinding.OnTrigger += ProgressScenes;

			for(int i = 5; i >= 1; --i)
			{
				scenes.Add(new Graphics.Widget(new Vector2(0f, 0f), new Vector2(1f, 1f)));
				scenes.Last().Texture = Graphics.SpriteContainer.Instance.GetImage("scene0" + i);
			}

			Graphics.WidgetManager.AddWidget(scenes.Last());
		}

        private void ProgressScenes()
        {
            var scene = scenes.Last();
            Graphics.WidgetManager.RemoveWidget(scene);

            scenes.Remove(scene);

            if(scenes.Count == 0)
            {
                Core.GameManager.Instance.NextScene = "level1";
            }
            else
            {
                Graphics.WidgetManager.AddWidget(scenes.Last());
            }
        }

        public override void UnLoad()
        {
            scenes.Clear();
            Input.InputManager.Manager.RemoveBinding(bindName);

            base.UnLoad();
        }
    }
}
