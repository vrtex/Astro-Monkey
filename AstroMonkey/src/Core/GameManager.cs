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
        private bool bongo = false;
        private String nextScene = null;

        static GameManager()
        {
            Input.ActionBinding bind = new Input.ActionBinding(Microsoft.Xna.Framework.Input.Keys.O);
            bind.OnTrigger += swap;
            Input.InputManager.Manager.AddActionBinding("ee", bind);
        }

        public void InitializeGame(Game game, GraphicsDeviceManager graphics)
        {
            CurrentGame = game;
            //załadowanie grafik
            Graphics.SpriteContainer.Instance.LoadTextures(game);

			//przekazanie ViewManagerowi możliwość sterowania grafiką
			Graphics.ViewManager.Instance.graphics = graphics;

			//ustawienie kursora
			Mouse.SetCursor(MouseCursor.FromTexture2D(Graphics.SpriteContainer.Instance.GetImage("mark"), 4, 4));

            //załadowanie sceny
            SceneManager.Instance.LoadScene("colliderroom");

            //przeszukiwanie obiektów i podpinanie referenzji do komponenetów
            //pod odpowiednie zarządzające klasy (animator, sprite, stack animator, stack sprite,...)
            //foreach(GameObject go in SceneManager.Instance.currScene.objects)
            //    SpawnObject(go);

        }

        public static void SpawnObject(GameObject gameObject)
        {
            lock(Instance.toSpawn)
            {
                Instance.toSpawn.Add(gameObject);
            }
        }

        public static void DestroyObject(GameObject gameObject)
        {
            gameObject.Destroy();
        }

        private static void QueueDestroy(GameObject gameObject)
        {
            lock(Instance.toDestroy)
            {
                Instance.toDestroy.Add(gameObject);
            }
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

                    var colliders = gameObject.GetComponents<Physics.Collider.Collider>();
                    if(colliders.Count != 0)
                        foreach(var c in colliders)
                            Physics.PhysicsManager.RemoveCollider(c);
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

        private static void swap()
        {
            Instance.nextScene = "";
            lock(Instance.nextScene)
            {
                Instance.nextScene = Instance.bongo ? "devroom" : "basement";
                //if(!Instance.bongo)
                //    SceneManager.Instance.LoadScene("basement");
                //else
                //    SceneManager.Instance.LoadScene("devroom");
            }
            Instance.bongo = !Instance.bongo;
        }
    }
}
