using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace AstroMonkey.Assets.Objects
{

    class Player: Core.GameObject
    {
        private int height = 21;
        private int size = 21;

		private Audio.AudioSource walkSFX;
		private Audio.AudioSource hitSFX;
		private Audio.AudioSource idleSFX;
		private Audio.AudioSource gameoverSFX;

		private Effect lightOff = null;

		public Player(): this(new Core.Transform())
        {
        }
        public Player(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }
        public Player(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public Player(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {

            // Physics
            AddComponent(new Body(this));
            AddComponent(new CircleCollider(this, CollisionChanell.Player, Vector2.Zero, size / 3));
			//AddComponent(new CircleCollider(this, CollisionChanell.Hitbox, Vector2.Zero, size / 2));

			walkSFX		= AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("MonkeyWalk")));
			walkSFX.Pitch = 0.5f;
			hitSFX		= AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("MonkeyHit")));
			idleSFX		= AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("MonkeyIdle")));
			gameoverSFX	= AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("GameOver")));

			// Movement
			Navigation.MovementComponent moveComp =  (Navigation.MovementComponent)AddComponent(new Navigation.MovementComponent(this));

			AddComponent(new Gameplay.Gun(this));
            AddComponent(new Input.InputComponent(this));


            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "monkey", idle01));

			AddComponent(new Gameplay.Health(this));

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
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size * 2, size, size));
            List<Rectangle> walk02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) walk02.Add(new Rectangle(i * size, size * 3, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Walk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { walk01, idle01, walk02, idle01},
                216,
                true));

            //TRZYMANIE
            List<Rectangle> hold01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) hold01.Add(new Rectangle(i * size, size * 4, size, size));
            List<Rectangle> hold02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) hold02.Add(new Rectangle(i * size, size * 5, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Hold",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { hold01, hold02 },
                266,
                true));

            //TRZYMANIE I CHODZENIE
            List<Rectangle> holdwalk01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) holdwalk01.Add(new Rectangle(i * size, size * 6, size, size));
            List<Rectangle> holdwalk02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) holdwalk02.Add(new Rectangle(i * size, size * 7, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("HoldWalk",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { holdwalk01, hold01, holdwalk02, hold01},
                150,
                true));

            //UMIERANIE
            List<Rectangle> dead01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead01.Add(new Rectangle(i * size, size * 8, size, size));
            List<Rectangle> dead02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) dead02.Add(new Rectangle(i * size, size * 9, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Dead",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, dead01, dead02 },
                298,
                false));

            //RZUCANIE
            List<Rectangle> throw01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) throw01.Add(new Rectangle(i * size, size * 10, size, size));
            List<Rectangle> throw02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) throw02.Add(new Rectangle(i * size, size * 11, size, size));
            List<Rectangle> throw03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) throw03.Add(new Rectangle(i * size, size * 12, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Throw",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { throw01, throw01, throw02, throw03, hold01 },
                298,
                false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Hold");

			lightOff = Graphics.EffectContainer.Instance.GetEffect("LightOff");
		}

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Vector2 currVel = GetComponent<Navigation.MovementComponent>().CurrentVelocity;
            if(Util.Statics.IsNearlyEqual(currVel.Length(), 0, 0.001))
            {
                GetComponent<Graphics.AnimatorContainer>().SetAnimation("Hold");
				walkSFX.IsLooped = false;

			}
            else
            {
                GetComponent<Graphics.AnimatorContainer>().SetAnimation("HoldWalk");
				if(walkSFX.IsLooped == false)
				{
					walkSFX.IsLooped = true;
					walkSFX.Play();
				}
			}
            transform.rotation = (float)Math.PI * 0.5f + GetComponent<Navigation.MovementComponent>().CurrentDirection;

			if(lightOff != null) lightOff.Parameters["angle"]?.SetValue(transform.rotation / ((float)Math.PI * 2));

		}
    }
}
