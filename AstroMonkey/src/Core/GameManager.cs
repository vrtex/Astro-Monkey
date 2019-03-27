using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AstroMonkey.Core
{
    class GameManager
    {
        public static GameManager Instance { get; private set; } = new GameManager();
        private Game CurrentGame;
        private List<GameObject> toSpawn = new List<GameObject>();
        private List<GameObject> toDestroy = new List<GameObject>();

        static GameManager()
        {
        }

        public void InitializeGame(Game game)
        {
            CurrentGame = game;
            //załadowanie grafik
            Graphics.SpriteContainer.Instance.LoadTextures(game);

            //ustawienie kursora
            Mouse.SetCursor(MouseCursor.FromTexture2D(Graphics.SpriteContainer.Instance.GetImage("mark"), 4, 4));

            //załadowanie sceny
            SceneManager.Instance.LoadScene("devroom");

            //przeszukiwanie obiektów i podpinanie referenzji do komponenetów
            //pod odpowiednie zarządzające klasy (animator, sprite, stack animator, stack sprite,...)
            foreach(GameObject go in SceneManager.Instance.currScene.objects)
                SpawnObject(go);
            
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
            lock(Instance.toDestroy)
            {
                Instance.toDestroy.Remove(gameObject);
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

                    gameObject.OnDestroy += DestroyObject;
                }
                Instance.toSpawn.Clear();
            }

            lock(Instance.toDestroy)
            {
                foreach(GameObject gameObject in Instance.toDestroy)
                {
                    if(!SceneManager.Instance.currScene.objects.Contains(gameObject))
                        continue;

                    Graphics.Animator anim = gameObject.GetComponent<Graphics.Animator>();
                    if(anim != null) Graphics.AnimationManager.Instance.RemoveAnimator(anim);

                    Graphics.StackAnimator stackAnim = gameObject.GetComponent<Graphics.StackAnimator>();
                    if(stackAnim != null) Graphics.AnimationManager.Instance.RemoveAnimator(stackAnim);

                    if(gameObject.GetComponent<Graphics.Sprite>() != null)
                        Graphics.ViewManager.Instance.RemoveSprite(gameObject);
                }
                Instance.toDestroy.Clear();
            }
        }
    }
}
