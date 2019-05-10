using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
    class Level1 : Core.Scene
    {
        public override void Load()
        {
            base.Load();
            LoadFromFile("Content/Map/Level1.tmx");

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
			}

			MediaPlayer.Play(Audio.SoundContainer.Instance.GetSong("01"));
		}
    }
}
