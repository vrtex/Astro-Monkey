using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
	class MainMenu: Core.Scene
	{
		public override void Load()
		{
			base.Load();

			Objects.MenuCenter mc = new Objects.MenuCenter(Graphics.ViewManager.Instance.WinSize()/2, new Vector2(0f, 0f), 0f);
			objects.Add(mc);
			Graphics.ViewManager.Instance.PlayerTransform = mc.transform;

			objects.Add(new Objects.TextButton());
			(objects.Last() as Objects.TextButton).SetTextButton("New Game", "planetary", 
																new Vector2(1f, 0.2f), 
																new Vector2(0.25f, 0.05f));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			objects.Add(new Objects.TextButton());
			(objects.Last() as Objects.TextButton).SetTextButton("Load Game", "planetary",
																new Vector2(1f, 0.3f),
																new Vector2(0.26f, 0.05f));
			objects.Add(new Objects.TextButton());
			(objects.Last() as Objects.TextButton).SetTextButton("Settings", "planetary",
																new Vector2(0.99f, 0.4f),
																new Vector2(0.21f, 0.05f));
			objects.Add(new Objects.TextButton());
			(objects.Last() as Objects.TextButton).SetTextButton("Authors", "planetary",
																new Vector2(0.98f, 0.5f),
																new Vector2(0.2f, 0.05f));
			objects.Add(new Objects.TextButton());
			(objects.Last() as Objects.TextButton).SetTextButton("Exit", "planetary",
																new Vector2(0.97f, 0.6f),
																new Vector2(0.1f, 0.05f));

			objects.Add(new UI.Text());
			(objects.Last() as UI.Text).SetTextButton("AstroMonkey", "planetary",
																new Vector2(0.5f, 0.1f),
																new Vector2(0.25f, 0.1f));
		}

		void PlayGame(Objects.TextButton textButton)
		{
			GameManager.Instance.NextScene = "devroom";
		}
	}
}
