using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Core
{
    class SceneManager
    {
        public static SceneManager Instance { get; private set; } = new SceneManager();
        public static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public Scene    currScene = null;

        static SceneManager()
        {
            scenes.Add("devroom", new Assets.Scenes.DevRoom());
        }

        public void LoadScene(string name)
        {
            scenes.TryGetValue(name, out currScene);
            currScene.Load();
        }
    }
}
