using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
	class Level6: Core.Scene
	{
		public override void Load()
		{
			base.Load();
			LoadFromFile("Content/Map/Level6.tmx");

			Objects.Player playerObject = GetObjectsByClass<Assets.Objects.Player>()[0];
			if(playerObject == null)
				throw new ApplicationException("something went wrong");
			Graphics.ViewManager.Instance.PlayerTransform = playerObject.transform;

			foreach(Core.GameObject o in objects)
			{
				if(o is Objects.BaseAlien)
				{
					(o as Objects.BaseAlien).aiAttack.target = playerObject;
					(o as Objects.BaseAlien).navigation.LoadNavigation();
					(o as Objects.BaseAlien).navigation.target = playerObject;
				}
				else if(o is Objects.FloorExit)
				{
					(o as Objects.FloorExit).GetComponent<Gameplay.ChangeLevel>().nextLevel = "level7";
				}
			}

			Gameplay.DoorTerminal dt = interactibles[0].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[0]);
			dt.doors.Add(doors[1]);

			doors[2].GetComponent<Graphics.Sprite>().rect = (doors[2] as Objects.Door).open03;
			doors[2].GetComponent<Graphics.StackAnimator>().SetAnimation("Close");
			doors[3].GetComponent<Graphics.Sprite>().rect = (doors[3] as Objects.Door).open03;
			doors[3].GetComponent<Graphics.StackAnimator>().SetAnimation("Close");

			MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("03_01"));

			Physics.PhysicsManager.player = playerObject.GetComponent<Physics.Collider.Collider>();
		}
	}
}
