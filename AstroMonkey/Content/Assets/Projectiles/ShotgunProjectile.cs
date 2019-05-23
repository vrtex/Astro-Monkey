using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class ShotgunProjectile : BaseProjectile
    {
        public ShotgunProjectile(Transform transform) : base(transform)
        {
            Load(transform);
        }

        public override void Start(Vector2 target, GameObject parent)
        {
            Vector2 difference = target - parent.transform.position;
            float mainAngle = (float)Math.Atan2(difference.Y, difference.X);

            for(int i = 0; i < 7; ++i)
            {
                float angle = mainAngle + ((i - 3) * (float)Math.PI / 32);
                Vector2 offset = new Vector2(
                    (float)(Math.Cos(angle)),
                    (float)(Math.Sin(angle))
                    );

                Console.WriteLine(offset);

                offset *= 5 * 32f * SceneManager.scale;

                var pellet = GameManager.SpawnObject(new ShotgunPellet(new Transform(transform)));
                pellet.Start(parent.transform.position + offset, parent);
            }
            Destroy();
        }

        private void Load(Transform transform)
        {
            shootSound = Audio.SoundContainer.Instance.GetSoundEffect("GunShoot").CreateInstance();

        }

    }
}
