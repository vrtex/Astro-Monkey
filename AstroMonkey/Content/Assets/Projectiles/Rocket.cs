using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Rocket: BaseProjectile
    {
        public Rocket() : this(new Core.Transform())
        {
        }

        public Rocket(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }

        public Rocket(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Rocket(Vector2 position) : this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Graphics.Sprite(this, "rocket", new List<Rectangle>() { new Rectangle(0, 0, 3, 5) }));
			shootSound = Audio.SoundContainer.Instance.GetSoundEffect("LuncherShoot").CreateInstance();
            speed = 500f;
            baseDamage = 50;
		}
    }
}
