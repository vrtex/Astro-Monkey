using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class DevRoom: Core.Scene
    {
        public override void Load()
        {
            //DODAWANIE PODŁOGI
            for(int x = 10; x < 15; ++x)
            {
                for(int y = 3; y < 10; ++y)
                {
                    objects.Add(new Objects.Floor(new Vector2(x * 32f, y * 32f)));
                    (objects.Last() as Objects.Floor).RandFloor();
                }
            }

            //DODAWANIE ŚCIAN
            for(int x = 10; x < 15; ++x)
            {
                for(int y = 2; y < 3; ++y)
                {
                    objects.Add(new Objects.Wall(new Vector2(x * 32f, y * 32f)));
                }
            }
            objects.Add(new Objects.Corner(new Vector2(9 * 32f, 2 * 32f)));
            for(int x = 9; x < 10; ++x)
            {
                for(int y = 3; y < 8; ++y)
                {
                    objects.Add(new Objects.Wall(new Vector2(x * 32f, y * 32f), Vector2.One, -(float)(Math.PI) * 0.5f));
                }
            }

            //INTERAKTYWNE ELEMENY
            objects.Add(new Objects.Computer(new Vector2(12 * 32f, 2 * 32f + 8f)));

            //DODAWANIE POSTACI
            objects.Add(new Objects.Player(new Vector2(20f, 50f)));

            objects.Add(new Objects.Klucha(new Vector2(90f, 70f)));
            objects.Last().GetComponent<Graphics.Animator>().SetAnimation("WalkRight");

            objects.Add(new Objects.Klucha(new Vector2(140f, 100f)));
            objects.Last().GetComponent<Graphics.Animator>().SetAnimation("WalkUp");

            objects.Add(new Objects.Banana(new Vector2(240f, 210f)));
        }

        public override void UnLoad()
        {
            
        }
    }
}
