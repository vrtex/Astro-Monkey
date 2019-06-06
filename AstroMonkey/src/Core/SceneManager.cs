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
			scenes.Add("level2", new Assets.Scenes.Level2());
			scenes.Add("level3", new Assets.Scenes.Level3());
			scenes.Add("level4", new Assets.Scenes.Level4());
			scenes.Add("level5", new Assets.Scenes.Level5());
			scenes.Add("level6", new Assets.Scenes.Level6());
			scenes.Add("level7", new Assets.Scenes.Level7());
			scenes.Add("level8", new Assets.Scenes.Level8());
			scenes.Add("level9", new Assets.Scenes.Level9());
			scenes.Add("pause", new Assets.Scenes.Pause());
			scenes.Add("begin", new Assets.Scenes.TheBegining());
		}

        public void LoadScene(string name/*, bool hold = false*/)
        {
            currScene?.UnLoad();

            GameManager.FinalizeSpwaning();

            scenes.TryGetValue(name, out currScene);
            if(currScene != null)
                currScene.Load();
            else
                throw new ApplicationException("Unknown scene " + name);
        }

        public void PauseScene()
        {
            heldScene = currScene; //zapisanie curr sceny do heldScene
            currScene = null; //usunięcie referencji currSceny
            LoadScene("pause"); //wczytanie menu pauzy
        }

        public void Restore()
        {
            currScene.UnLoad();
            GameManager.FinalizeSpwaning();
            currScene = heldScene; // dodanie do curr gry
            var player = currScene.GetObjectsByClass<Assets.Objects.Player>();
            Graphics.ViewManager.Instance.PlayerTransform = player[0].transform;
            heldScene = null; //usunięcie tymczasowej referencji do gry
        }
    }
}
