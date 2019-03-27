﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class DevRoom: Core.Scene
    {
        private float sceneScale = 3f;

        public override void Load()
        {
            //DODAWANIE PODŁOGI
            for(int x = -1; x < 11; ++x)
            {
                for(int y = 0; y < 9; ++y)
                {
                    objects.Add(new Objects.Floor(new Vector2(x * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
                    (objects.Last() as Objects.Floor).RandFloor();
                }
            }

            //DODAWANIE ŚCIAN
            for(int x = 0; x < 10; ++x)
            {
                objects.Add(new Objects.Wall(new Vector2(x * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            }
            for(int x = 0; x < 10; ++x)
            {
                if(x == 4 || x == 5) continue;
                objects.Add(new Objects.Wall(new Vector2(x * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
            }
            objects.Add(new Objects.Corner(new Vector2(-1 * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Corner(new Vector2(10 * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI * 0.5f)));
            for(int y = 1; y < 8; ++y)
            {
                objects.Add(new Objects.Wall(new Vector2(-1 * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            }
            for(int y = 1; y < 8; ++y)
            {
                objects.Add(new Objects.Wall(new Vector2(10 * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI * 0.5f)));
            }
            objects.Add(new Objects.Corner(new Vector2(-1 * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            objects.Add(new Objects.Corner(new Vector2(10 * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));

            //INTERAKTYWNE ELEMENY
            /*objects.Add(new Objects.Computer(new Vector2(12 * 32f, 2 * 32f + 8f)));*/

            //DODAWANIE POSTACI
            Objects.Player player = new Objects.Player(new Vector2(20f, 50f), new Vector2(sceneScale, sceneScale), 0f);
            objects.Add(player);
            Graphics.ViewManager.Instance.playerTransform = player.transform;

            objects.Add(new Objects.Alien01(new Vector2(350f, 170f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Alien01(new Vector2(420f, 200f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            objects.Add(new Objects.Alien01(new Vector2(320f, 280f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.1f)));
            objects.Add(new Objects.Alien01(new Vector2(520f, 300f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.8f)));

            objects.Add(new Objects.Banana(new Vector2(450f, 470f), new Vector2(sceneScale, sceneScale), 0f));

            objects.Add(new Objects.Nut(new Vector2(490f, 490f), new Vector2(sceneScale, sceneScale), 0f));

            objects.Add(new Objects.AmmoRiffle(new Vector2(190f, 590f), new Vector2(sceneScale, sceneScale), 0f));
            objects.Add(new Objects.AmmoGun(new Vector2(290f, 590f), new Vector2(sceneScale, sceneScale), 0f));
            objects.Add(new Objects.AmmoLuncher(new Vector2(390f, 590f), new Vector2(sceneScale, sceneScale), 0f));

            objects.Add(new Objects.Column(new Vector2(590f, 140f), new Vector2(sceneScale, sceneScale), 0f));
            objects.Add(new Objects.Cockpit(new Vector2(690f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Fridge(new Vector2(754f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Armchair(new Vector2(680f, 64f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.15f)));

            objects.Add(new Objects.Case(new Vector2(442f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.CaseCaffe(new Vector2(250f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.CaseMicrowave(new Vector2(346f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Table(new Vector2(346f, 110f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

            objects.Add(new Objects.NeonSign(new Vector2(442f, 1f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
        }

        public override void UnLoad()
        {
            
        }
    }
}
