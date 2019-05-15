using System;
using System.Collections.Generic;

namespace AstroMonkey.Core
{
    class SceneManager
    {
        public static SceneManager Instance { get; private set; } = new SceneManager();
        public static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public Scene    currScene = null;
        private Scene heldScene;

        public static float scale = 3f;

        static SceneManager()
        {
            scenes.Add("devroom", new Assets.Scenes.DevRoom());
            scenes.Add("basement", new Assets.Scenes.Basement());
            scenes.Add("colliderroom", new Assets.Scenes.ColliderRoom());
			scenes.Add("menu", new Assets.Scenes.MainMenu());
            scenes.Add("level1", new Assets.Scenes.Level1());
		}

        public void LoadScene(string name, bool hold = false)
        {
            if(!hold)
                currScene?.UnLoad();
            else
                heldScene = currScene;

            GameManager.FinalizeSpwaning();

            scenes.TryGetValue(name, out currScene);
            if(currScene != null)
                currScene.Load();
            else
                throw new ApplicationException("Unknown scene " + name);

            //foreach(GameObject go in currScene.objects)
            //    GameManager.SpawnObject(go);

        }

        public void Restore()
        {
            currScene.UnLoad();
            currScene = heldScene;
            heldScene = null;
        }
    }
}
