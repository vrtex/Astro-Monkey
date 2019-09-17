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
		List<Graphics.Widget>		scenes				= new List<Graphics.Widget>();
		List<Graphics.TextWidget>	scenesText			= new List<Graphics.TextWidget>();
		Input.ActionBinding			progressBinding		= new Input.ActionBinding(Input.EMouseButton.Left);
        private readonly string bindName = "progress";

		public override void Load()
		{
			base.Load();

            Input.InputManager.Manager.AddActionBinding(bindName, progressBinding);
            progressBinding.OnTrigger += ProgressScenes;

			for(int i = 5; i >= 1; --i)
			{
				scenes.Add(new Graphics.Widget(new Vector2(0f, 0f), new Vector2(1f, 1f)));
				scenes.Last().Texture = Graphics.SpriteContainer.Instance.GetImage("scene" + i);
			}
			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "and it ran to get a gun";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "It switched control to autopilot";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "It was the only commander who could save the expedition. ";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "However, evil aliens attacked her along the way. ";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "The monkey was sent on a journey to Mars.";

			Graphics.WidgetManager.AddWidget(scenes.Last());
			Graphics.WidgetManager.AddWidget(scenesText.Last());
		}

        private void ProgressScenes()
        {
            var scene = scenes.Last();
            Graphics.WidgetManager.RemoveWidget(scene);
			var sceneText = scenesText.Last();
			Graphics.WidgetManager.RemoveWidget(sceneText);

			scenes.Remove(scene);
			scenesText.Remove(sceneText);


			if(scenes.Count == 0)
            {
                Core.GameManager.Instance.NextScene = "level1";
            }
            else
            {
                Graphics.WidgetManager.AddWidget(scenes.Last());
				Graphics.WidgetManager.AddWidget(scenesText.Last());
			}
        }

        public override void UnLoad()
        {
            scenes.Clear();
			scenesText.Clear();
			Input.InputManager.Manager.GetActionBinding(bindName).OnTrigger -= ProgressScenes;
            Input.InputManager.Manager.RemoveBinding(bindName);

            base.UnLoad();
        }
    }
}
