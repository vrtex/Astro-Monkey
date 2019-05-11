using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using AstroMonkey.UI;
using Microsoft.Xna.Framework.Media;

namespace AstroMonkey.Assets.Scenes
{
	class MainMenu: Core.Scene
	{
		List<UI.UIElement> mainMenu = new List<UI.UIElement>();
		List<UI.UIElement> loadGame = new List<UI.UIElement>();
		List<UI.UIElement> authors = new List<UI.UIElement>();
		List<UI.UIElement> settings = new List<UI.UIElement>();

		int currResolution = 0;

		public override void Load()
		{
			base.Load();

            //MediaPlayer.Volume = Util.Statics.musicVolume;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = Util.Statics.musicVolume;
            MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("menu"));

            objects.Add(new UI.Text("Astro Monkey", "planetary", new Vector2(0.5f, 0.05f), new Vector2(0.25f, 0.1f)));
			mainMenu.Add(objects.Last() as UI.UIElement);

			Objects.MenuCenter mc = new Objects.MenuCenter(Graphics.ViewManager.Instance.WinSize()/2, new Vector2(0f, 0f), 0f);
			objects.Add(mc);
			Graphics.ViewManager.Instance.PlayerTransform = mc.transform;
			
			objects.Add(new Objects.TextButton("New Game", "planetary", new Vector2(0.75f, 0.2f), new Vector2(0.25f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			mainMenu.Add(objects.Last() as UI.UIElement);
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("Load Game", "planetary", new Vector2(0.75f, 0.3f), new Vector2(0.26f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += LoadGame;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Settings", "planetary", new Vector2(0.75f, 0.4f), new Vector2(0.21f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += Settings;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Authors", "planetary", new Vector2(0.75f, 0.5f), new Vector2(0.2f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += Authors;
			mainMenu.Add(objects.Last() as UI.UIElement);

			objects.Add(new Objects.TextButton("Exit", "planetary", new Vector2(0.75f, 0.6f), new Vector2(0.1f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += QuitGame;
			mainMenu.Add(objects.Last() as UI.UIElement);

            //objects.Add(new UI.Slider(new Vector2(0.75f, 0.7f), new Vector2(0.32f, 0.05f), 0.5f));
            //mainMenu.Add(objects.Last() as UI.UIElement);

            //++++++++++++++++++++++++++++++++++++++ŁADOWANIE GRY++++++++++++++++++++++++++++++++++++++++++
            objects.Add(new Objects.TextButton("Level 1", "planetary", new Vector2(0.1f, 0.15f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("Level 2", "planetary", new Vector2(0.1f, 0.2f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 1;

			objects.Add(new Objects.TextButton("Level 3", "planetary", new Vector2(0.1f, 0.25f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 2;

			objects.Add(new Objects.TextButton("Level 4", "planetary", new Vector2(0.1f, 0.3f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 3;

			objects.Add(new Objects.TextButton("Level 5", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 4;

			objects.Add(new Objects.TextButton("Level 6", "planetary", new Vector2(0.1f, 0.4f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 5;

			objects.Add(new Objects.TextButton("Level 7", "planetary", new Vector2(0.1f, 0.45f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 6;

			objects.Add(new Objects.TextButton("Level 8", "planetary", new Vector2(0.1f, 0.5f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 7;

			objects.Add(new Objects.TextButton("Level 9", "planetary", new Vector2(0.1f, 0.55f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 8;

			objects.Add(new Objects.TextButton("Dev Room", "planetary", new Vector2(0.1f, 0.6f), new Vector2(0.34f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 9;

			objects.Add(new Objects.TextButton("Collider Room", "planetary", new Vector2(0.1f, 0.65f), new Vector2(0.35f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += PlayGame;
			loadGame.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 10;

			//++++++++++++++++++++++++++++++++++++++++++OPCJE++++++++++++++++++++++++++++++++++++++++++++++

			//(objects.Last() as Objects.TextButton).onClick += SetFullscreen;

			//(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new Objects.TextButton("[ ] Fullscreen", "planetary", new Vector2(0.1f, 0.2f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetFullscreen;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new Objects.TextButton("[ ] 1024x768", "planetary", new Vector2(0.1f, 0.3f), new Vector2(0.32f, 0.05f)));
			(objects.Last() as Objects.TextButton).onClick += SetResolution;
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;
			(objects.Last() as Objects.TextButton).value = 0;

			objects.Add(new Objects.TextButton("[ ] 1280x720", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.34f, 0.05f)));
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

			objects.Add(new UI.Text(" ", "planetary", new Vector2(0.1f, 0.1f), new Vector2(0.25f, 0.05f)));
			settings.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

            objects.Add(new UI.Slider(new Vector2(0.1f, 0.60f), new Vector2(0.32f, 0.05f), Util.Statics.musicVolume, "Music"));
            (objects.Last() as UI.Slider).onChange += SetMusicVolume;
            settings.Add(objects.Last() as UI.UIElement);
            (objects.Last() as UI.UIElement).enable = false;

            objects.Add(new UI.Slider(new Vector2(0.1f, 0.65f), new Vector2(0.32f, 0.05f), Util.Statics.soundVolume, "Sound"));
            (objects.Last() as UI.Slider).onChange += SetSoundVolume;
            settings.Add(objects.Last() as UI.UIElement);
            (objects.Last() as UI.UIElement).enable = false;

            objects.Add(new Objects.TextButton("Save settings", "planetary", new Vector2(0.1f, 0.8f), new Vector2(0.35f, 0.05f)));
            (objects.Last() as Objects.TextButton).onClick += ForceSettingsSave;
            settings.Add(objects.Last() as UI.UIElement);
            (objects.Last() as UI.UIElement).enable = false;

            //+++++++++++++++++++++++++++++++++++++++++AUTORZY+++++++++++++++++++++++++++++++++++++++++++++
            objects.Add(new UI.Text("Jakub Czaja", "planetary", new Vector2(0.1f, 0.15f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Artur Mokrosinski", "planetary", new Vector2(0.1f, 0.2f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Maciej Nabialczyk", "planetary", new Vector2(0.1f, 0.25f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Assets source:", "planetary", new Vector2(0.1f, 0.35f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("www.dafont.com/planetary-contact.font", "planetary", new Vector2(0.1f, 0.38f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			objects.Add(new UI.Text("Sound by Soundsnap", "planetary", new Vector2(0.1f, 0.41f), new Vector2(0.25f, 0.1f)));
			authors.Add(objects.Last() as UI.UIElement);
			(objects.Last() as UI.UIElement).enable = false;

			RepairSpawns();

			currResolution = Graphics.ViewManager.Instance.ScreenSize;
			OffAllSetting();
		}

        void PlayGame(Objects.TextButton textButton)
		{
			MediaPlayer.Stop();

			if(textButton.value == 0)
			{
				GameManager.Instance.NextScene = "level1";
			}
			else if(textButton.value == 1)
			{
				GameManager.Instance.NextScene = "level2";
			}
			else if(textButton.value == 2)
			{
				GameManager.Instance.NextScene = "level3";
			}
			else if(textButton.value == 3)
			{
				GameManager.Instance.NextScene = "level4";
			}
			else if(textButton.value == 4)
			{
				GameManager.Instance.NextScene = "level5";
			}
			else if(textButton.value == 5)
			{
				GameManager.Instance.NextScene = "level6";
			}
			else if(textButton.value == 6)
			{
				GameManager.Instance.NextScene = "level7";
			}
			else if(textButton.value == 7)
			{
				GameManager.Instance.NextScene = "level8";
			}
			else if(textButton.value == 8)
			{
				GameManager.Instance.NextScene = "level9";
			}
			else if(textButton.value == 9)
			{
				GameManager.Instance.NextScene = "devroom";
			}
			else if(textButton.value == 10)
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
            SaveSettings();
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
			currResolution = textButton.value;
			OffAllSetting();

			(settings[7] as UI.Text).text = "Restart game to apply changes";

            SaveSettings();
		}

        void SetSoundVolume(UI.Slider slider)
        {
            Util.Statics.soundVolume = slider.value;
        }

        void SetMusicVolume(UI.Slider slider)
        {
            Util.Statics.musicVolume = slider.value;
            MediaPlayer.Volume = Util.Statics.musicVolume;
        }

        private void ForceSettingsSave(Objects.TextButton textButton)
        {
            SaveSettings();
            CloseAllSection();
        }

        void SaveSettings()
        {
            string[] lines = { "fullscreen=" + (Graphics.ViewManager.Instance.graphics.IsFullScreen ? "1" : "0"),
                                "resolution=" + currResolution.ToString(),
                                "sound=" + (int)Util.Statics.Map(Util.Statics.soundVolume, 0f, 1f, 0f, 100f),
                                "music=" + (int)Util.Statics.Map(Util.Statics.musicVolume, 0f, 1f, 0f, 100f)};
            File.WriteAllLines("Content/settings/settings.ini", lines);
        }

        void OffAllSetting()
		{
			if(Graphics.ViewManager.Instance.graphics.IsFullScreen)
				(settings[0] as Objects.TextButton).text = "[X] Fullscreen";
			else (settings[0] as Objects.TextButton).text = "[ ] Fullscreen";

			
			Vector2 res = Vector2.Zero;
			for(int i = 1; i < 7; ++i)
			{
				res = Util.Statics.GetResolition(i - 1);
				if((settings[i] as Objects.TextButton).value == currResolution)
				{
					(settings[i] as Objects.TextButton).text = "[X] " + res.X.ToString() + "x" + res.Y.ToString();
				}
				else (settings[i] as Objects.TextButton).text = "[ ] " + res.X.ToString() + "x" + res.Y.ToString();
			}
			
		}

		void SetFullscreen(Objects.TextButton textButton)
		{
			if(Graphics.ViewManager.Instance.graphics.IsFullScreen)
			{
				textButton.text = "[ ] Fullscreen";
				Graphics.ViewManager.Instance.graphics.IsFullScreen = false;
			}
			else
			{
				textButton.text = "[X] Fullscreen";
				Graphics.ViewManager.Instance.graphics.IsFullScreen = true;
			}
			(settings[7] as UI.Text).text = "Restart game to apply changes";
            SaveSettings();
		}

        public override void UnLoad()
        {
            foreach(GameObject obj in objects)
            {
                Objects.TextButton button = obj as Objects.TextButton;
                if(button == null)
                    continue;
                button.onClick -= LoadGame;
                button.onClick -= PlayGame;
                button.onClick -= SetFullscreen;
                button.onClick -= SetResolution;
                button.onClick -= Settings;
            }
            foreach(GameObject obj in objects)
            {
                Slider slider = obj as Slider;
                if(slider == null)
                    continue;
                slider.onChange -= SetSoundVolume;
                slider.onChange -= SetMusicVolume;
            }
            foreach(UIElement obj in settings)
            {
                Objects.TextButton button = obj as Objects.TextButton;
                if(button == null)
                    continue;
                button.onClick -= LoadGame;
                button.onClick -= PlayGame;
                button.onClick -= SetFullscreen;
                button.onClick -= SetResolution;
                button.onClick -= Settings;
            }
            foreach(UIElement obj in loadGame)
            {
                Objects.TextButton button = obj as Objects.TextButton;
                if(button == null)
                    continue;
                button.onClick -= LoadGame;
                button.onClick -= PlayGame;
                button.onClick -= SetFullscreen;
                button.onClick -= SetResolution;
                button.onClick -= Settings;
            }
            base.UnLoad();
        }
    }
}
