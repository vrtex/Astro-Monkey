using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Alien01: BaseAlien
    {
        private int height = 13;
        private int size = 21;

		public Alien01() : this(new Core.Transform())
        {
        }
        public Alien01(Core.Transform _transform): base(_transform)
        {
            colliderRadius = size / 3;
            healthBarOffset = height * 2;
            maxHealth = 80;
            Load(_transform);
        }
        public Alien01(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public Alien01(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        protected override void Load(Core.Transform _transform)
        {
            base.Load(transform);

            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "alien01", idle01));

            AddComponent(new Graphics.StackAnimator(this));



            //STANIE
            List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02 },
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
                new List<List<Rectangle>> { idle01, walk01, idle01, walk02 },
                134,
                true));

            //ATAK
            List<Rectangle> attack01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) attack01.Add(new Rectangle(i * size, size * 4, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Attack",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, attack01 },
                166,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");

			//AudioSource
			walkSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien01Walk")));
			hitSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien01Hit")));
			idleSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien01Idle")));
			lookSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("Alien01Look")));

			//ustawianie zwłok kosmity
			corp = typeof(Alien01Dead);
		}
    }
}
