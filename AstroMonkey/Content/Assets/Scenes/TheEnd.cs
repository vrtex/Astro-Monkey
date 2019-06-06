using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
	class TheEnd: Core.Scene
	{
		List<Graphics.Widget>       scenes              = new List<Graphics.Widget>();
		List<Graphics.TextWidget>   scenesText          = new List<Graphics.TextWidget>();
		Input.ActionBinding         progressBinding     = new Input.ActionBinding(Input.EMouseButton.Left);
		private readonly string bindName = "progress";

		public override void Load()
		{
			base.Load();

			Input.InputManager.Manager.AddActionBinding(bindName, progressBinding);
			progressBinding.OnTrigger += ProgressScenes;

			for(int i = 10; i >= 6; --i)
			{
				scenes.Add(new Graphics.Widget(new Vector2(0f, 0f), new Vector2(1f, 1f)));
				scenes.Last().Texture = Graphics.SpriteContainer.Instance.GetImage("scene" + i);
			}
			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "5";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "4";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "3";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "2";

			scenesText.Add(new Graphics.TextWidget(new Vector2(0.01f, 0.01f)));
			scenesText.Last().ZOrder = 1;
			scenesText.Last().DisplayString = "Monkey go into space";

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
				Core.GameManager.Instance.NextScene = "menu";
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
			Input.InputManager.Manager.GetActionBinding(bindName).OnTrigger -= ProgressScenes;
			Input.InputManager.Manager.RemoveBinding(bindName);

			base.UnLoad();
		}
	}
}
