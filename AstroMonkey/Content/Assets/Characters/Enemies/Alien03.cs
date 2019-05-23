using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien03: BaseAlien
    {
        private int height = 32;
        private int size = 32;

        public Alien03() : this(new Core.Transform())
        {
        }
        public Alien03(Core.Transform _transform) : base(_transform)
        {
            colliderRadius = size / 3;
            healthBarOffset = height * 5 / 3;
            maxHealth = 150;
            Load(_transform);
        }
        public Alien03(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public Alien03(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        protected override void Load(Core.Transform _transform)
        {
            base.Load(_transform);

			healthComponent.MaxHealth = 220;
			movement.Speed = 180f;
			navigation.distanceToStop = 0.8f * 32f * Core.SceneManager.scale;
			aiAttack.attackDistance = 1.4f * 32f * Core.SceneManager.scale;

			List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "alien03", idle01));

            //STANIE
            List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    idle01, idle02
                },
                266,
                true));

            //CHODZENIE
            List<Rectangle> walk01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk01.Add(new Rectangle(i * size, size * 2, size, size));
            List<Rectangle> walk02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk02.Add(new Rectangle(i * size, size * 3, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    idle01, walk01, idle01, walk02
                },
                182,
                true));

            //ATAK
            List<Rectangle> attack01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack01.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> attack02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack02.Add(new Rectangle(i * size, size * 5, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> {
                    idle01, attack01, attack02
                },
                166,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");

			//AudioSource
			walkSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Walk")));
			hitSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Hit")));
			idleSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Idle")));
			lookSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Look")));
			attackSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Attack")));
			nearSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien03Near")));
			walkSFX.Pitch = 0.2f;
			hitSFX.Pitch = 0.2f;
			idleSFX.Pitch = 0.2f;
			lookSFX.Pitch = 0.2f;
			attackSFX.Pitch = 0.2f;
			nearSFX.Pitch = 0.2f;

			//ustawianie zwłok kosmity
			corp = typeof(Alien03Dead);
		}
    }
}
