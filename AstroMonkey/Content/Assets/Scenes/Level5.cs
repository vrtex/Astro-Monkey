using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
	class Level5: Core.Scene
	{
		public override void Load()
		{
			base.Load();
			LoadFromFile("Content/Map/Level5.tmx");

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
					(o as Objects.FloorExit).GetComponent<Gameplay.ChangeLevel>().nextLevel = "level6";
				}
			}

			Gameplay.DoorTerminal dt = interactives[0].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[0]);
			dt.doors.Add(doors[1]);

			dt = interactives[1].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[3]);
			dt.doors.Add(doors[5]);

			dt = interactives[2].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[2]);
			dt.doors.Add(doors[4]);
			dt.doors.Add(doors[6]);
			dt.doors.Add(doors[7]);

			dt = interactives[3].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[8]);
			dt.doors.Add(doors[9]);

			MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("02_03"));
		}
	}
}
