using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class ColliderRoom: Core.Scene
    {
        public float sceneScale = SceneManager.scale;

        public override void Load()
        {
            base.Load();

            int offsetX = 0;

            //DODAWANIE POSTACI
            Objects.Player player = new Objects.Player(new Vector2(0, -50), new Vector2(sceneScale, sceneScale), 0f);
            objects.Add(player);
            Graphics.ViewManager.Instance.PlayerTransform = player.transform;

            objects.Add(new Objects.Wall(new Vector2(32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Wall(new Vector2(32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Wall(new Vector2(32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Wall(new Vector2(32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.WallDoor(new Vector2(2 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.WallDoor(new Vector2(2 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.WallDoor(new Vector2(2 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.WallDoor(new Vector2(2 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Corner(new Vector2(3 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Corner(new Vector2(3 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Corner(new Vector2(3 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Corner(new Vector2(3 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.DoorLeft(new Vector2(4 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.DoorLeft(new Vector2(4 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.DoorLeft(new Vector2(4 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.DoorLeft(new Vector2(4 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.DoorRight(new Vector2(5 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.DoorRight(new Vector2(5 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.DoorRight(new Vector2(5 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.DoorRight(new Vector2(5 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Alien01(new Vector2(6 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Alien01(new Vector2(6 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Alien01(new Vector2(6 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Alien01(new Vector2(6 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Alien02(new Vector2(7 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Alien02(new Vector2(7 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Alien02(new Vector2(7 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Alien02(new Vector2(7 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Alien03(new Vector2(8 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Alien03(new Vector2(8 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Alien03(new Vector2(8 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Alien03(new Vector2(8 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Banana(new Vector2(9 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Banana(new Vector2(9 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Banana(new Vector2(9 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Banana(new Vector2(9 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Nut(new Vector2(10 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Nut(new Vector2(10 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Nut(new Vector2(10 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Nut(new Vector2(10 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.AmmoRiffle(new Vector2(11 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.AmmoRiffle(new Vector2(11 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.AmmoRiffle(new Vector2(11 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.AmmoRiffle(new Vector2(11 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.AmmoGun(new Vector2(12 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.AmmoGun(new Vector2(12 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.AmmoGun(new Vector2(12 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.AmmoGun(new Vector2(12 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.AmmoLuncher(new Vector2(13 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.AmmoLuncher(new Vector2(13 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.AmmoLuncher(new Vector2(13 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.AmmoLuncher(new Vector2(13 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.HalfWall(new Vector2(14 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.HalfWall(new Vector2(14 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.HalfWall(new Vector2(14 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.HalfWall(new Vector2(14 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Column(new Vector2(15 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Column(new Vector2(15 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Column(new Vector2(15 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Column(new Vector2(15 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Cockpit(new Vector2(16 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Cockpit(new Vector2(16 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Cockpit(new Vector2(16 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Cockpit(new Vector2(16 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Fridge(new Vector2(17 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Fridge(new Vector2(17 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Fridge(new Vector2(17 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Fridge(new Vector2(17 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Armchair(new Vector2(18 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Armchair(new Vector2(18 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Armchair(new Vector2(18 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Armchair(new Vector2(18 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Case(new Vector2(19 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Case(new Vector2(19 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Case(new Vector2(19 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Case(new Vector2(19 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.CaseCaffe(new Vector2(20 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.CaseCaffe(new Vector2(20 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.CaseCaffe(new Vector2(20 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.CaseCaffe(new Vector2(20 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.CaseMicrowave(new Vector2(21 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.CaseMicrowave(new Vector2(21 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.CaseMicrowave(new Vector2(21 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.CaseMicrowave(new Vector2(21 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Table(new Vector2(22 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Table(new Vector2(22 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Table(new Vector2(22 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Table(new Vector2(22 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.NeonSign(new Vector2(23 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.NeonSign(new Vector2(23 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.NeonSign(new Vector2(23 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.NeonSign(new Vector2(23 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.Terminal(new Vector2(24 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.Terminal(new Vector2(24 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.Terminal(new Vector2(24 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.Terminal(new Vector2(24 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.TerminalOff(new Vector2(25 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.TerminalOff(new Vector2(25 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.TerminalOff(new Vector2(25 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.TerminalOff(new Vector2(25 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.ButtonWall(new Vector2(26 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.ButtonWall(new Vector2(26 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.ButtonWall(new Vector2(26 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.ButtonWall(new Vector2(26 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.ButtonClicked(new Vector2(27 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.ButtonClicked(new Vector2(27 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.ButtonClicked(new Vector2(27 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.ButtonClicked(new Vector2(27 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

            objects.Add(new Objects.CornerPhillar(new Vector2(28 * 32f * sceneScale * sceneScale + offsetX, 1 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), 0));
            objects.Add(new Objects.CornerPhillar(new Vector2(28 * 32f * sceneScale * sceneScale + offsetX, 3 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI / 2)));
            objects.Add(new Objects.CornerPhillar(new Vector2(28 * 32f * sceneScale * sceneScale + offsetX, 5 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));
            objects.Add(new Objects.CornerPhillar(new Vector2(28 * 32f * sceneScale * sceneScale + offsetX, 7 * 32f * sceneScale), new Vector2(sceneScale, sceneScale), -(float)(Math.PI / 2)));

        }
    }
}