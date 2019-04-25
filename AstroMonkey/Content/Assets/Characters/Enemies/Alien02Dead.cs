using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
	class Alien02Dead: Core.GameObject
	{
		public Alien02Dead()
		{
			Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
		}
		public Alien02Dead(Core.Transform _transform) : base(_transform)
		{
			Load(_transform);
		}
		public Alien02Dead(Vector2 position, Vector2 scale, float rotation = 0f)
		{
			Load(new Core.Transform(position, scale, rotation));
		}
		public Alien02Dead(Vector2 position)
		{
			Load(new Core.Transform(position, Vector2.One, 0f));
		}

		private int height = 21;
		private int size = 21;

		private Audio.AudioSource deadSFX;

		private void Load(Core.Transform _transform)
		{
			transform = _transform;

			List<Rectangle> dead01 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 3, size, size));
			AddComponent(new Graphics.Sprite(this, "alien02", dead01));

			AddComponent(new Graphics.StackAnimator(this));

			//UMIERANIE
			List<Rectangle> dead02 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 8, size, size));
			List<Rectangle> dead03 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead03.Add(new Rectangle(i * size, size * 9, size, size));
			List<Rectangle> dead04 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead04.Add(new Rectangle(i * size, size * 10, size, size));
			List<Rectangle> dead05 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead05.Add(new Rectangle(i * size, size * 11, size, size));
			List<Rectangle> dead06 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead06.Add(new Rectangle(i * size, size * 12, size, size));
			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Dead",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { dead01, dead02, dead03, dead04, dead05 },
				352,
				false));

			GetComponent<Graphics.StackAnimator>().SetAnimation("Dead");

			deadSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Dead")));
			deadSFX.Play();
		}
	}
}
