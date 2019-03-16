using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AstroMonkey.Core
{
    class GameManager
    {
        public static GameManager Instance { get; private set; } = new GameManager();

        static GameManager()
        {
        }

        public void InitializeGame(Game game)
        {
            //załadowanie grafik
            Graphics.SpriteContainer.Instance.LoadTextures(game);

            //załadowanie sceny
            SceneManager.Instance.LoadScene("devroom");

            //przeszukiwanie obiektów i podpinanie referenzji do komponenetów
            //pod odpowiednie zarządzające klasy (animator, sprites, ...)

            Debug.WriteLine("test " + SceneManager.Instance.currScene + " " + SceneManager.Instance.currScene.objects.Count);
            foreach(GameObject go in SceneManager.Instance.currScene.objects)
            {
                Graphics.Animator anim = go.GetComponent<Graphics.Animator>();
                if(anim != null) Graphics.AnimationManager.Instance.AddAnimator(anim);

                if(go.GetComponent<Graphics.Sprite>() != null) Graphics.ViewManager.Instance.AddSprite(go);
            }
            
        }
    }
}
