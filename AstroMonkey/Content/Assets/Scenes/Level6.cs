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
					(o as Objects.FloorExit).GetComponent<Gameplay.ChangeLevel>().nextLevel = "level7";
				}
			}

			Gameplay.DoorTerminal dt = interactives[0].GetComponent<Gameplay.DoorTerminal>();
			dt.doors.Add(doors[0]);
			dt.doors.Add(doors[1]);

			MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("03_01"));
		}
	}
}
