using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
	class PistolBullet: BaseProjectile
	{
		public PistolBullet() : this(new Core.Transform())
		{
		}

		public PistolBullet(Core.Transform _transform) : base(_transform)
		{
			Load(_transform);
		}

		public PistolBullet(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
		{
		}

		public PistolBullet(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
		{
		}

		private void Load(Core.Transform _transform)
		{
			AddComponent(new Graphics.Sprite(this, "pistolBullet", new List<Rectangle>() { new Rectangle(0, 0, 2, 4) }));
			shootSound = Audio.SoundContainer.Instance.GetSoundEffect("PistolShoot").CreateInstance();
            speed = 800f;
		}
	}
}
