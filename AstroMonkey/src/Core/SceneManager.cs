﻿using System;
using System.Collections.Generic;

namespace AstroMonkey.Core
{
    class SceneManager
    {
        public static SceneManager Instance { get; private set; } = new SceneManager();
        public static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public Scene    currScene = null;

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
		}

        public void LoadScene(string name)
        {
            currScene?.UnLoad();

            GameManager.FinalizeSpwaning();

            scenes.TryGetValue(name, out currScene);
            if(currScene != null)
                currScene.Load();
            else
                throw new ApplicationException("Unknown scene " + name);

            //foreach(GameObject go in currScene.objects)
            //    GameManager.SpawnObject(go);

        }
    }
}
