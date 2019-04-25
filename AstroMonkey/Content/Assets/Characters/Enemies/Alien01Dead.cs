using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
	class Alien01Dead: Core.GameObject
	{
		public Alien01Dead()
		{
			Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
		}
		public Alien01Dead(Core.Transform _transform): base(_transform)
        {
			Load(_transform);
		}
		public Alien01Dead(Vector2 position, Vector2 scale, float rotation = 0f)
		{
			Load(new Core.Transform(position, scale, rotation));
		}
		public Alien01Dead(Vector2 position)
		{
			Load(new Core.Transform(position, Vector2.One, 0f));
		}

		private int height = 13;
		private int size = 21;

		private Audio.AudioSource deadSFX;

		private void Load(Core.Transform _transform)
		{
			transform = _transform;

			List<Rectangle> dead01 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 5, size, size));
			AddComponent(new Graphics.Sprite(this, "alien01", dead01));

			AddComponent(new Graphics.StackAnimator(this));

			//UMIERANIE
			List<Rectangle> dead02 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 6, size, size));
			List<Rectangle> dead03 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead03.Add(new Rectangle(i * size, size * 7, size, size));
			List<Rectangle> dead04 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead04.Add(new Rectangle(i * size, size * 8, size, size));
			List<Rectangle> dead05 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) dead05.Add(new Rectangle(i * size, size * 9, size, size));
			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Dead",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { dead01, dead02, dead03, dead04, dead05 },
				352,
				false));

			GetComponent<Graphics.StackAnimator>().SetAnimation("Dead");

			deadSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien01Dead")));
			deadSFX.Play();
		}
	}
}
