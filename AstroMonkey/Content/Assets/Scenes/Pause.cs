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
    class Pause : Core.Scene
    {

        public override void Load()
        {
            base.Load();

            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = Util.Statics.musicVolume;
            //MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("menu"));

            objects.Add(new UI.Text("Astro Monkey", "planetary", new Vector2(0.5f, 0.05f), new Vector2(0.25f, 0.1f)));

            //Objects.MenuCenter mc =
            //    new Objects.MenuCenter(Graphics.ViewManager.Instance.WinSize() / 2, new Vector2(0f, 0f), 0f);
            //objects.Add(mc);
            //Graphics.ViewManager.Instance.PlayerTransform = mc.transform;

            objects.Add(new Objects.TextButton("Resume", "planetary", new Vector2(0.75f, 0.2f),
                new Vector2(0.25f, 0.05f)));
            (objects.Last() as Objects.TextButton).onClick += Resume;

            objects.Add(new Objects.TextButton("Main Menu", "planetary", new Vector2(0.75f, 0.3f),
                new Vector2(0.26f, 0.05f)));
            (objects.Last() as Objects.TextButton).onClick += Menu;

            objects.Add(new Objects.TextButton("Exit", "planetary", new Vector2(0.75f, 0.4f),
                new Vector2(0.21f, 0.05f)));
            (objects.Last() as Objects.TextButton).onClick += Exit;

            RepairSpawns();

        }

        void Resume(Objects.TextButton textButton)
        {
            SceneManager.Instance.Restore();
        }

        void Menu(Objects.TextButton textButton)
        {
            SceneManager.Instance.LoadScene("menu");
        }

        void Exit(Objects.TextButton textButton)
        {
            Game1.self.Quit();
        }

        public override void UnLoad()
        {
            foreach (GameObject obj in objects)
            {
                Objects.TextButton button = obj as Objects.TextButton;
                if (button == null)
                    continue;
                button.onClick -= Resume;
                button.onClick -= Menu;
                button.onClick -= Exit;
            }
            base.UnLoad();
        }
    }
}
