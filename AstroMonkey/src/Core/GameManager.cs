using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace AstroMonkey.Core
{
    class GameManager
    {
        public static GameManager Instance { get; private set; } = new GameManager();
        private Game CurrentGame;
        private List<GameObject> toSpawn = new List<GameObject>();
        private List<GameObject> toDestroy = new List<GameObject>();
        private String nextScene = null;
		public String NextScene
		{
			get => nextScene;
			set
			{
				lock(Instance)
				{
					nextScene = value;
				}
			}
		}

        static GameManager()
        {
            Input.ActionBinding pauseBinding = new Input.ActionBinding(Keys.P);
            pauseBinding.OnTrigger += TogglePause;
            Input.InputManager.Manager.AddActionBinding("pause", pauseBinding);
        }

        private static void TogglePause()
        {
            Scene currScene = SceneManager.Instance.currScene;
            bool paused = currScene.GetType() == typeof(Assets.Scenes.Pause);
            if (paused)
            {
                SceneManager.Instance.Restore();
            }
            else
            {
                SceneManager.Instance.PauseScene();

            }
        }

        public void InitializeGame(Game game, GraphicsDeviceManager graphics)
        {
            CurrentGame = game;
            //załadowanie grafik i dźwięków
            Graphics.SpriteContainer.Instance.LoadTextures(game);
			Graphics.EffectContainer.Instance.LoadEffects(game);
			Audio.SoundContainer.Instance.LoadSounds(game);
			Audio.SoundContainer.Instance.LoadMusic(game);

			//przekazanie ViewManagerowi możliwość sterowania grafiką
			Graphics.ViewManager.Instance.graphics = graphics;

			//ustawienie kursora
			Mouse.SetCursor(MouseCursor.FromTexture2D(Graphics.SpriteContainer.Instance.GetImage("mark"), 4, 4));

            //załadowanie sceny
            SceneManager.Instance.LoadScene("menu");

            //przeszukiwanie obiektów i podpinanie referenzji do komponenetów
            //pod odpowiednie zarządzające klasy (animator, sprite, stack animator, stack sprite,...)
            //foreach(GameObject go in SceneManager.Instance.currScene.objects)
            //    SpawnObject(go);

        }

        public static T SpawnObject<T>(T gameObject) where T : GameObject
        {
            lock(Instance.toSpawn)
            {
                Instance.toSpawn.Add(gameObject);
            }
            return gameObject;
        }

        public static void DestroyObject(GameObject gameObject)
        {
            gameObject.Destroy();
        }

        public static void QueueDestroy(GameObject gameObject)
        {
            lock(Instance.toDestroy)
            {
                Instance.toDestroy.Add(gameObject);
            }
        }

        public static void QueueSpawn(GameObject gameObject)
        {
            lock (Instance.toSpawn)
            {
                Instance.toSpawn.Add(gameObject);
            }
        }

        public Game GetGame()
		{
			return CurrentGame;
		}

        public static void FinalizeSpwaning()
        {

            lock(Instance.toSpawn)
            {
                foreach(GameObject gameObject in Instance.toSpawn)
                {
                    if(!SceneManager.Instance.currScene.objects.Contains(gameObject))
                        SceneManager.Instance.currScene.objects.Add(gameObject);

                    Graphics.Animator anim = gameObject.GetComponent<Graphics.Animator>();
                    if(anim != null) Graphics.AnimationManager.Instance.AddAnimator(anim);

                    Graphics.StackAnimator stackAnim = gameObject.GetComponent<Graphics.StackAnimator>();
                    if(stackAnim != null) Graphics.AnimationManager.Instance.AddAnimator(stackAnim);

                    if(gameObject.GetComponent<Graphics.Sprite>() != null)
                        Graphics.ViewManager.Instance.AddSprite(gameObject);

					if(gameObject is UI.UIElement) Graphics.ViewManager.Instance.AddSprite(gameObject as UI.UIElement);

					gameObject.OnDestroy += QueueDestroy;
                }
                Instance.toSpawn.Clear();
            }

            lock(Instance.toDestroy)
            {
                foreach(GameObject gameObject in Instance.toDestroy)
                {
                    if(!SceneManager.Instance.currScene.objects.Contains(gameObject))
                        continue;
                    SceneManager.Instance.currScene.objects.RemoveAll( x=> x.Equals(gameObject));

                    Graphics.Animator anim = gameObject.GetComponent<Graphics.Animator>();
                    if(anim != null) Graphics.AnimationManager.Instance.RemoveAnimator(anim);

                    Graphics.StackAnimator stackAnim = gameObject.GetComponent<Graphics.StackAnimator>();
                    if(stackAnim != null) Graphics.AnimationManager.Instance.RemoveAnimator(stackAnim);

                    if(gameObject.GetComponent<Graphics.Sprite>() != null)
                        Graphics.ViewManager.Instance.RemoveSprite(gameObject);

					if(gameObject is UI.UIElement)
					{
						Graphics.ViewManager.Instance.RemoveSprite(gameObject as UI.UIElement);
					}
                }
                Instance.toDestroy.Clear();
            }
        }

        public static void UpdateScene()
        {
            if(Instance.nextScene != null)
                lock(Instance.nextScene)
                {
                    SceneManager.Instance.LoadScene(Instance.nextScene);
                    Instance.nextScene = null;
                }
        }
    }
}
