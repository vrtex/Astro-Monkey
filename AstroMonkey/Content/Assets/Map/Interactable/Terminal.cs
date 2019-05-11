using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class Terminal: Core.GameObject
    {
        private float size = 12;

        public Terminal() : this(new Core.Transform())
        {
        }

        public Terminal(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public Terminal(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public Terminal(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            // Physics
            AddComponent(new CircleCollider(this, CollisionChanell.InteractPlayer, new Vector2(-4, 0), size));

			//Ustawienie animacji włączonego i wyłączonego terminala
            List<Rectangle> onTerminal = new List<Rectangle>();
			for(int i = 0; i < 32; ++i) onTerminal.Add(new Rectangle(i * 32, 0, 32, 32));
			List<Rectangle> offTerminal = new List<Rectangle>();
			for(int i = 0; i < 32; ++i) offTerminal.Add(new Rectangle(i * 32, 32, 32, 32));

			AddComponent(new Graphics.StackAnimator(this));

			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("On",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { onTerminal },
				266,
				false));

			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Off",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { offTerminal },
				266,
				false));

			AddComponent(new Graphics.Sprite(this, "terminal", onTerminal));
			GetComponent<Graphics.StackAnimator>().SetAnimation("On");

			//Interakcja
			AddComponent(new Gameplay.DoorTerminal(this));
		}
    }

}
