using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

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

            //ustawienie kursora
            Mouse.SetCursor(MouseCursor.FromTexture2D(Graphics.SpriteContainer.Instance.GetImage("mark"), 4, 4));

            //załadowanie sceny
            SceneManager.Instance.LoadScene("devroom");

            //przeszukiwanie obiektów i podpinanie referenzji do komponenetów
            //pod odpowiednie zarządzające klasy (animator, sprite, stack animator, stack sprite,...)
            foreach(GameObject go in SceneManager.Instance.currScene.objects)
            {
                Graphics.Animator anim = go.GetComponent<Graphics.Animator>();
                if(anim != null) Graphics.AnimationManager.Instance.AddAnimator(anim);
                Graphics.StackAnimator stackAnim = go.GetComponent<Graphics.StackAnimator>();
                if(stackAnim != null) Graphics.AnimationManager.Instance.AddAnimator(stackAnim);

                if(go.GetComponent<Graphics.Sprite>() != null) Graphics.ViewManager.Instance.AddSprite(go);
            }
            
        }
    }
}
