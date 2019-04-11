using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Assets.Scenes
{
	class MainMenu: Core.Scene
	{
		List<UI.UIElement> mainMenu = new List<UI.UIElement>();
		List<UI.UIElement> loadGame = new List<UI.UIElement>();
		List<UI.UIElement> authors = new List<UI.UIElement>();
		List<UI.UIElement> settings = new List<UI.UIElement>();

		public override void Load()
		{
			base.Load();

			objects.Add(new UI.Text("Astro Monkey", "planetary", new Vector2(0.5f, 0.05f), new Vector2(0.25f, 0.1f)));
			mainMenu.Add(objects.Last() as UI.UIElement);

			Objects.MenuCenter mc = new Objects.MenuCenter(Graphics.ViewManager.Instance.WinSize()/2, new Vector2(0f, 0f), 0f);
			objects.Add(mc);
			Graphics.ViewManager.Instance.PlayerTransform = mc.transform;
			
			objects.Add(new Objects.TextButton("New Game", "planetary", new Vector2(1f, 0.2f), new Vector2(0.25f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			mainMenu.Add(objects.Last() as UI.UIElement);
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("Load Game", "planetary", new Vector2(1f, 0.3f), new Vector2(0.26f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += LoadGame;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Settings", "planetary", new Vector2(0.99f, 0.4f), new Vector2(0.21f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += Settings;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Authors", "planetary", new Vector2(0.98f, 0.5f), new Vector2(0.2f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += Authors;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Exit", "planetary", new Vector2(0.97f, 0.6f), new Vector2(0.1f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += QuitGame;
			mainMenu.Add(objects.Last() as UI.UIElement);

			//++++++++++++++++++++++++++++++++++++++ŁADOWANIE GRY++++++++++++++++++++++++++++++++++++++++++
			objects.Add(new Objects.TextButton("Level 1", "planetary", new Vector2(0.1f, 0.3f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("Level 2", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 1;

			objects.Add(new Objects.TextButton("Level 3", "planetary", new Vector2(0.1f, 0.4f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 2;

			objects.Add(new Objects.TextButton("Level 4", "planetary", new Vector2(0.1f, 0.45f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 3;

			objects.Add(new Objects.TextButton("Dev Room", "planetary", new Vector2(0.1f, 0.50f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 4;

			objects.Add(new Objects.TextButton("Collider Room", "planetary", new Vector2(0.1f, 0.55f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 5;

			//++++++++++++++++++++++++++++++++++++++++++OPCJE++++++++++++++++++++++++++++++++++++++++++++++
			objects.Add(new Objects.TextButton("[ ] Fullscreen", "planetary", new Vector2(0.1f, 0.2f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetFullscreen;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new Objects.TextButton("[ ] 1024x768", "planetary", new Vector2(0.1f, 0.3f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("[X] 1280x720", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 1;

			objects.Add(new Objects.TextButton("[ ] 1400x1050", "planetary", new Vector2(0.1f, 0.4f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 2;

			objects.Add(new Objects.TextButton("[ ] 1680x1050", "planetary", new Vector2(0.1f, 0.45f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 3;

			objects.Add(new Objects.TextButton("[ ] 1920x1080", "planetary", new Vector2(0.1f, 0.50f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 4;

			objects.Add(new Objects.TextButton("[ ] 1920x1200", "planetary", new Vector2(0.1f, 0.55f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 5;

			//+++++++++++++++++++++++++++++++++++++++++AUTORZY+++++++++++++++++++++++++++++++++++++++++++++
			objects.Add(new UI.Text("Jakub Czaja", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Artur Mokrosinski", "planetary", new Vector2(0.1f, 0.4f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Maciej Nabialczyk", "planetary", new Vector2(0.1f, 0.45f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Assets source:", "planetary", new Vector2(0.1f, 0.65f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("www.dafont.com/planetary-contact.font", "planetary", new Vector2(0.1f, 0.7f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

            RepairSpawns();
		}

		void PlayGame(Objects.TextButton textButton)
		{
			if(textButton.value == 0)
			{
				GameManager.Instance.NextScene = "devroom";
			}
			else if(textButton.value == 1)
			{
				GameManager.Instance.NextScene = "level1";
			}
			else if(textButton.value == 2)
			{
				GameManager.Instance.NextScene = "devroom";
			}
			else if(textButton.value == 3)
			{
				GameManager.Instance.NextScene = "devroom";
			}
			else if(textButton.value == 4)
			{
				GameManager.Instance.NextScene = "devroom";
			}
			else if(textButton.value == 5)
			{
				GameManager.Instance.NextScene = "colliderroom";
			}
		}

		void LoadGame(Objects.TextButton textButton)
		{
			CloseAllSection();
			foreach(var l in loadGame)
			{
				l.enable = true;
			}
		}

		void Settings(Objects.TextButton textButton)
		{
			CloseAllSection();
			foreach(var s in settings)
			{
				s.enable = true;
			}
		}

		void Authors(Objects.TextButton textButton)
		{
			CloseAllSection();
			foreach(var a in authors)
			{
				a.enable = true;
			}
		}

		void QuitGame(Objects.TextButton textButton)
		{
			GameManager.Instance.GetGame().Exit();
		}

		void CloseAllSection()
		{
			foreach(var l in loadGame)
			{
				l.enable = false;
			}
			foreach(var s in settings)
			{
				s.enable = false;
			}
			foreach(var a in authors)
			{
				a.enable = false;
			}
		}

		void SetResolution(Objects.TextButton textButton)
		{
			if(textButton.value == 0)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1024;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 768;
				textButton.text = "[X] 1024x768";
			}
			else if(textButton.value == 1)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1280;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 720;
				textButton.text = "[X] 1280x720";
			}
			else if(textButton.value == 2)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1400;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 1050;
				textButton.text = "[X] 1400x1050";
			}
			else if(textButton.value == 3)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1680;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 1050;
				textButton.text = "[X] 1680x1050";
			}
			else if(textButton.value == 4)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1920;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 1080;
				textButton.text = "[X] 1920x1080";
			}
			else if(textButton.value == 5)
			{
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth = 1920;
				Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight = 1200;
				textButton.text = "[X] 1920x1200";
			}
			RescaleUIElements();
			//Graphics.ViewManager.Instance.graphics.ApplyChanges();
			Graphics.ViewManager.Instance.ScreenSize = new Vector2(Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth, Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight);
		}

		void SetFullscreen(Objects.TextButton textButton)
		{
			Graphics.ViewManager.Instance.graphics.ToggleFullScreen();

			return;
			if(Graphics.ViewManager.Instance.graphics.IsFullScreen)
			{
				Graphics.ViewManager.Instance.graphics.IsFullScreen = false;
				textButton.text = "[ ] Fullscreen";
			}
			else
			{
				Graphics.ViewManager.Instance.graphics.IsFullScreen = true;
				textButton.text = "[X] Fullscreen";
			}
			Graphics.ViewManager.Instance.graphics.ApplyChanges();
			Graphics.ViewManager.Instance.ScreenSize = new Vector2(Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth, Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight);
		}

		void RescaleUIElements()
		{
			foreach(var l in loadGame)
			{
				(l as UI.Text).Load();
			}
			foreach(var s in settings)
			{
				(s as UI.Text).Load();
			}
			foreach(var a in authors)
			{
				(a as UI.Text).Load();
			}
			foreach(var m in mainMenu)
			{
				(m as UI.Text).Load();
			}
		}
	}
}
