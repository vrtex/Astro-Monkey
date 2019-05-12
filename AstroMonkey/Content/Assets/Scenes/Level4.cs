using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
	class Level4: Core.Scene
	{
		public override void Load()
		{
			base.Load();
			LoadFromFile("Content/Map/Level4.tmx");

			Objects.Player playerObject = GetObjectsByClass<Assets.Objects.Player>()[0];
			if(playerObject == null)
				throw new ApplicationException("something went wrong");
			Graphics.ViewManager.Instance.PlayerTransform = playerObject.transform;

			foreach(Core.GameObject o in objects)
			{
				if(o is Objects.BaseAlien)
				{
					(o as Objects.BaseAlien).aiAttack.target = playerObject;
				}
				else if(o is Objects.Door)
				{
					doors.Add(o);
				}
				else if(o is Objects.Terminal)
				{
					interactives.Add(o);
				}
				else if(o is Objects.FloorExit)
				{
					(o as Objects.FloorExit).GetComponent<Gameplay.ChangeLevel>().nextLevel = "level5";
				}
			}

			Gameplay.DoorTerminal dt = interactives[2].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[4]);
			dt.doors.Add(doors[5]);

			dt = interactives[1].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[2]);
			dt.doors.Add(doors[3]);

			dt = interactives[0].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[0]);
			dt.doors.Add(doors[1]);

			doors[6].GetComponent<Graphics.Sprite>().rect = (doors[2] as Objects.Door).open03;
			doors[6].GetComponent<Graphics.StackAnimator>().SetAnimation("Close");
			doors[7].GetComponent<Graphics.Sprite>().rect = (doors[3] as Objects.Door).open03;
			doors[7].GetComponent<Graphics.StackAnimator>().SetAnimation("Close");

			MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("02_03"));

			Physics.PhysicsManager.player = playerObject.GetComponent<Physics.Collider.Collider>();
		}
	}
}
