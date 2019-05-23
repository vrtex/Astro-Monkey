using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace AstroMonkey.Audio
{
	class SoundContainer
	{

		public static SoundContainer Instance = new SoundContainer();

		private Dictionary<String, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
		private Dictionary<String, Song> songs = new Dictionary<string, Song>();

		private SoundContainer() { }


		public void AddSound(String name, String path, ContentManager contentManager)
		{
			sounds.Add(name, contentManager.Load<SoundEffect>(path));
		}

		public SoundEffect GetSoundEffect(String id)
		{
			SoundEffect toReturn;
			sounds.TryGetValue(id, out toReturn);
			if(toReturn == null)
			{
				Console.WriteLine("Unexisting sound: " + id);
				Console.WriteLine(new System.Diagnostics.StackTrace());
			}
			return toReturn;
		}

		public Song GetSong(String id)
		{
			Song toReturn;
			songs.TryGetValue(id, out toReturn);
			if(toReturn == null)
			{
				Console.WriteLine("Unexisting sound: " + id);
				Console.WriteLine(new System.Diagnostics.StackTrace());
			}
			return toReturn;
		}

		public void LoadSounds(Game game)
		{
			//kosmita 1
			sounds.Add("Alien01Attack", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Attack"));
			sounds.Add("Alien01Dead", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Dead"));
			sounds.Add("Alien01Hit", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Hit"));
			sounds.Add("Alien01Idle", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Idle"));
			sounds.Add("Alien01Look", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Look"));
			sounds.Add("Alien01Near", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Near"));
			sounds.Add("Alien01Near02", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Near02"));
			sounds.Add("Alien01Walk", game.Content.Load<SoundEffect>(@"sfx/alien01/Alien01Walk"));

			//kosmita 2
			sounds.Add("Alien02Attack", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Attack"));
			sounds.Add("Alien02Dead", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Dead"));
			sounds.Add("Alien02Hit", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Hit"));
			sounds.Add("Alien02Idle", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Idle"));
			sounds.Add("Alien02Look", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Look"));
			sounds.Add("Alien02Near", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Near"));
			sounds.Add("Alien02Walk", game.Content.Load<SoundEffect>(@"sfx/alien02/Alien02Walk"));

			//kosmita 3
			sounds.Add("Alien03Attack", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Attack"));
			sounds.Add("Alien03Dead", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Dead"));
			sounds.Add("Alien03Hit", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Hit"));
			sounds.Add("Alien03Idle", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Idle"));
			sounds.Add("Alien03Look", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Look"));
			sounds.Add("Alien03Walk", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Walk"));
            sounds.Add("Alien03Near", game.Content.Load<SoundEffect>(@"sfx/alien03/Alien03Look"));

            //broń
            sounds.Add("GunReload", game.Content.Load<SoundEffect>(@"sfx/guns/GunReload"));
			sounds.Add("GunShoot", game.Content.Load<SoundEffect>(@"sfx/guns/GunShoot"));
			sounds.Add("LuncherHit", game.Content.Load<SoundEffect>(@"sfx/guns/LuncherHit"));
			sounds.Add("LuncherReload", game.Content.Load<SoundEffect>(@"sfx/guns/LuncherReload"));
			sounds.Add("LuncherShoot", game.Content.Load<SoundEffect>(@"sfx/guns/LuncherShoot"));
			sounds.Add("PistolReload", game.Content.Load<SoundEffect>(@"sfx/guns/PistolReload"));
			sounds.Add("PistolShoot", game.Content.Load<SoundEffect>(@"sfx/guns/PistolShoot"));
			sounds.Add("PopHit", game.Content.Load<SoundEffect>(@"sfx/guns/PopHit"));
			sounds.Add("PopReload", game.Content.Load<SoundEffect>(@"sfx/guns/PopReload"));
			sounds.Add("RifleReload", game.Content.Load<SoundEffect>(@"sfx/guns/RifleReload"));
			sounds.Add("RifleShoot", game.Content.Load<SoundEffect>(@"sfx/guns/RifleShoot"));

			//menu
			sounds.Add("MenuClick", game.Content.Load<SoundEffect>(@"sfx/menu/MenuClick"));
			sounds.Add("MenuHover", game.Content.Load<SoundEffect>(@"sfx/menu/MenuHover"));

			//broń
			sounds.Add("MonkeyWalk", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyWalk"));
			sounds.Add("MonkeyWalk02", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyWalk02"));
			sounds.Add("MonkeyLook", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyLook"));
			sounds.Add("MonkeyIdle02", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyIdle02"));
			sounds.Add("MonkeyIdle", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyIdle"));
			sounds.Add("MonkeyHit", game.Content.Load<SoundEffect>(@"sfx/player/MonkeyHit"));
			sounds.Add("GameOver", game.Content.Load<SoundEffect>(@"sfx/player/GameOver"));

			//inne
			sounds.Add("Computer", game.Content.Load<SoundEffect>(@"sfx/Computer"));
		}

		public void LoadMusic(Game game)
		{
			songs.Add("01", game.Content.Load<Song>(@"sfx/background/01 - Sound design sweeper bed filter swells ambient 01_SFXBible_ss00411"));
			songs.Add("02_01", game.Content.Load<Song>(@"sfx/background/02 - Dark_SciFi_Drone_Mixed_080"));
			songs.Add("02_02", game.Content.Load<Song>(@"sfx/background/02 - Dark_SciFi_Drone_Mixed_083_V2"));
			songs.Add("02_03", game.Content.Load<Song>(@"sfx/background/02 - Spaceship Passageway"));
			songs.Add("03_01", game.Content.Load<Song>(@"sfx/background/03 - SCIENCE FICTION DRONE ADVANCED TECHNOLOGY HUM 01"));
			songs.Add("03_02", game.Content.Load<Song>(@"sfx/background/03 - SCIENCE FICTION DRONE DARK BLIPS 01"));
			songs.Add("04", game.Content.Load<Song>(@"sfx/background/04 - HORROR DRONE DARK AIR 01"));
			songs.Add("05_01", game.Content.Load<Song>(@"sfx/background/05 - Crab Nebula"));
			songs.Add("05_02", game.Content.Load<Song>(@"sfx/background/05 - Interstellar_Spacedrone"));
			songs.Add("06", game.Content.Load<Song>(@"sfx/background/06 - amb_doomdrones_amorph_stahlwand"));
			songs.Add("menu", game.Content.Load<Song>(@"sfx/background/menu - Sound design synth bed pad sweeper ambient 01_SFXBible_ss00421"));
		}
	}
}
