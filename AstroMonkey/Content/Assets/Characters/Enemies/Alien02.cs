using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien02: BaseAlien
    {
        private int height = 21;
        private int size = 21;

        public Alien02() : this(new Core.Transform())
        {
        }
        public Alien02(Core.Transform _transform) : base(_transform)
        {
            colliderRadius = size / 3;
            healthBarOffset = height * 5 / 3;
            maxHealth = 100;
            Load(_transform);
        }
        public Alien02(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public Alien02(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        protected override void Load(Core.Transform _transform)
        {
            base.Load(_transform);

			healthComponent.MaxHealth = 120;
			movement.Speed = 150f;

			List <Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "alien02", idle01));

			//STANIE
			List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size * 1, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02 },
                266,
                true));

            //CHODZENIE
            List<Rectangle> walk01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk01.Add(new Rectangle(i * size, size * 2, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, walk01 },
                266,
                true));

            //ATAK
            List<Rectangle> attack01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack01.Add(new Rectangle(i * size, size * 3, size, size));
            List<Rectangle> attack02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack02.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> attack03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack03.Add(new Rectangle(i * size, size * 5, size, size));
            List<Rectangle> attack04 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack04.Add(new Rectangle(i * size, size * 6, size, size));
            List<Rectangle> attack05 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack05.Add(new Rectangle(i * size, size * 7, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, attack01, attack02, attack03, attack04, attack05 },
                266,
                true));

            //UMIERANIE
            List<Rectangle> dead01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 3, size, size));
            List<Rectangle> dead02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> dead03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead03.Add(new Rectangle(i * size, size * 5, size, size));
            List<Rectangle> dead04 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead04.Add(new Rectangle(i * size, size * 6, size, size));
            List<Rectangle> dead05 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead05.Add(new Rectangle(i * size, size * 7, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { dead01, dead02, dead03, dead04, dead05 },
                352,
                false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");

			//AudioSource
			walkSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Walk")));
			hitSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Hit")));
			idleSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Idle")));
			lookSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Look")));
			attackSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Attack")));
			nearSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien02Near")));
			walkSFX.Pitch = 0.2f;
			hitSFX.Pitch = 0.2f;
			idleSFX.Pitch = 0.2f;
			lookSFX.Pitch = 0.2f;
			attackSFX.Pitch = 0.2f;
			nearSFX.Pitch = 0.2f;

			//ustawianie zwłok kosmity
			corp = typeof(Alien02Dead);

			Gameplay.Gun gun = AddComponent(new Gameplay.Gun(this));
            gun.AddAmmoClip(Gameplay.Gun.alienClip);
            aiAttack.shoot = true;
            aiAttack.attackDistance = 6 * 32f * Core.SceneManager.scale;

            navigation.distanceToStop = 5 * 32f * Core.SceneManager.scale;
        }
    }
}
