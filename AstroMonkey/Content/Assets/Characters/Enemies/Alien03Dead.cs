﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
	class Alien03Dead: BaseAlienDead
	{
		public Alien03Dead() : this(new Core.Transform())
		{
		}
		public Alien03Dead(Core.Transform _transform) : base(_transform)
		{
			Load(_transform);
		}
		public Alien03Dead(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
		{
		}
		public Alien03Dead(Vector2 position) : this(new Core.Transform(position, Vector2.One))
		{
		}

		private int height = 32;
		private int size = 32;

		private Audio.AudioSource deadSFX;

		protected void Load(Core.Transform _transform)
		{

			List<Rectangle> dead01 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 6, size, size));
			AddComponent(new Graphics.Sprite(this, "alien03", dead01));

			AddComponent(new Graphics.StackAnimator(this));

			//UMIERANIE
			List<Rectangle> dead02 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 7, size, size));
			List<Rectangle> dead03 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead03.Add(new Rectangle(i * size, size * 8, size, size));
			List<Rectangle> dead04 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead04.Add(new Rectangle(i * size, size * 9, size, size));
			List<Rectangle> dead05 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead05.Add(new Rectangle(i * size, size * 10, size, size));
			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Dead",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { dead01, dead02, dead03, dead04, dead05 },
				352,
				false));

			GetComponent<Graphics.StackAnimator>().SetAnimation("Dead");

			deadSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Dead")));
			deadSFX.Play();
		}
	}
}
