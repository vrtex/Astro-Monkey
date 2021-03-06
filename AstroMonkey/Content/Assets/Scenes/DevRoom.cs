﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class DevRoom: Core.Scene
    {

        public override void Load()
        {
            base.Load();

            //DODAWANIE PODŁOGI
            for(int x = -1; x < 11; ++x)
            {
                for(int y = 0; y < 9; ++y)
                {
                    GameManager.SpawnObject(new Objects.FloorCrate01(new Vector2(x * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
                }
            }

            //DODAWANIE ŚCIAN
            for(int x = 0; x < 10; ++x)
            {
                if(x == 9) GameManager.SpawnObject(new Objects.WallDoor(new Vector2(x * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
                else GameManager.SpawnObject(new Objects.Wall(new Vector2(x * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            }
            for(int x = 0; x < 10; ++x)
            {
                if(x == 4) GameManager.SpawnObject(new Objects.DoorLeft(new Vector2(x * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
                else if(x == 5) GameManager.SpawnObject(new Objects.DoorRight(new Vector2(x * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
                else GameManager.SpawnObject(new Objects.Wall(new Vector2(x * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));
            }
            GameManager.SpawnObject(new Objects.WallCorner(new Vector2(-1 * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.WallCorner(new Vector2(10 * 32f * sceneScale, 0 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI * 0.5f)));
            for(int y = 1; y < 8; ++y)
            {
                GameManager.SpawnObject(new Objects.Wall(new Vector2(-1 * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            }
            for(int y = 1; y < 8; ++y)
            {
                GameManager.SpawnObject(new Objects.Wall(new Vector2(10 * 32f * sceneScale, y * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI * 0.5f)));
            }
            GameManager.SpawnObject(new Objects.WallCorner(new Vector2(-1 * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            GameManager.SpawnObject(new Objects.WallCorner(new Vector2(10 * 32f * sceneScale, 8 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0f));

            //INTERAKTYWNE ELEMENY
            /*GameManager.SpawnObject(new Objects.Computer(new Vector2(12 * 32f, 2 * 32f + 8f)));*/

            //DODAWANIE POSTACI
            Objects.Player player = new Objects.Player(new Vector2(20f, 650f), new Vector2(sceneScale, sceneScale), 0f);
            GameManager.SpawnObject(player);
            Graphics.ViewManager.Instance.PlayerTransform = player.transform;

            GameManager.SpawnObject(new Objects.Alien01(new Vector2(350f, 170f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Alien01(new Vector2(420f, 200f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            GameManager.SpawnObject(new Objects.Alien01(new Vector2(320f, 280f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.1f)));
            GameManager.SpawnObject(new Objects.Alien01(new Vector2(520f, 300f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.8f)));

            GameManager.SpawnObject(new Objects.Alien03(new Vector2(350f, 570f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Alien03(new Vector2(450f, 600f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            GameManager.SpawnObject(new Objects.Alien03(new Vector2(320f, 680f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.1f)));
            GameManager.SpawnObject(new Objects.Alien03(new Vector2(520f, 700f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.8f)));

            GameManager.SpawnObject(new Objects.Alien02(new Vector2(650f, 570f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Alien02(new Vector2(720f, 600f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.5f)));
            GameManager.SpawnObject(new Objects.Alien02(new Vector2(620f, 680f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.1f)));
            GameManager.SpawnObject(new Objects.Alien02(new Vector2(820f, 700f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 1.8f)));

            GameManager.SpawnObject(new Objects.Banana(new Vector2(450f, 470f), new Vector2(sceneScale, sceneScale), 0f));

            GameManager.SpawnObject(new Objects.Nut(new Vector2(490f, 490f), new Vector2(sceneScale, sceneScale), 0f));

            GameManager.SpawnObject(new Objects.AmmoRiffle(new Vector2(190f, 590f), new Vector2(sceneScale, sceneScale), 0f));
            GameManager.SpawnObject(new Objects.AmmoGun(new Vector2(290f, 590f), new Vector2(sceneScale, sceneScale), 0f));
            GameManager.SpawnObject(new Objects.AmmoLuncher(new Vector2(390f, 590f), new Vector2(sceneScale, sceneScale), 0f));

            GameManager.SpawnObject(new Objects.HalfWall(new Vector2(500f, 140f), new Vector2(sceneScale, sceneScale), 0f));
            GameManager.SpawnObject(new Objects.Column(new Vector2(590f, 140f), new Vector2(sceneScale, sceneScale), 0f));
            GameManager.SpawnObject(new Objects.Cockpit(new Vector2(690f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Fridge(new Vector2(754f, 32f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Armchair(new Vector2(680f, 64f), new Vector2(sceneScale, sceneScale), (float)(Math.PI * 0.15f)));

            GameManager.SpawnObject(new Objects.Case(new Vector2(442f, 16f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.CaseCaffe(new Vector2(250f, 16f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.CaseMicrowave(new Vector2(346f, 16f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.Table(new Vector2(346f, 110f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

            GameManager.SpawnObject(new Objects.NeonSign(new Vector2(442f, 1f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

            GameManager.SpawnObject(new Objects.Terminal(new Vector2(96f, 3f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            GameManager.SpawnObject(new Objects.ButtonWall(new Vector2(0f, 3f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

			// GameManager.SpawnObject(new Objects.AmmoAmount());
            //GameManager.SpawnObject(new Objects.SimpleButton());

        }

    }
}
