using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
	class Door: Core.GameObject
	{
		public Collider         closeCollider	= null;
		public Collider         openCollider	= null;

		public List<NavPoint>   navPoints		= new List<NavPoint>();

		public Door() : this(new Core.Transform())
        {
		}

		public Door(Core.Transform _transform) : base(_transform)
        {

		}
		public Door(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
		}

		public Door(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
		}

		protected int height = 32;
		protected int size = 32;
		protected List<Rectangle> idle01 = new List<Rectangle>();
		public List<Rectangle> open03 = new List<Rectangle>();
		public bool isOpen = false;

		protected virtual void Load(Core.Transform _transform)
		{
			transform = _transform;

			//kolizja na zamkniętych drzwiach
			closeCollider = AddComponent(new BoxCollider(this, CollisionChanell.Object, new Vector2(0, 10), 32, 12));
			

			for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));

			AddComponent(new Graphics.StackAnimator(this));

			//OTWIERANIE
			List<Rectangle> open01 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) open01.Add(new Rectangle(i * size, size, size, size));
			List<Rectangle> open02 = new List<Rectangle>();
			for(int i = 0; i < height; ++i) open02.Add(new Rectangle(i * size, size * 2, size, size));
			for(int i = 0; i < height; ++i) open03.Add(new Rectangle(i * size, size * 3, size, size));
			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Open",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { idle01, open01, open02, open03 },
				166,
				false));

			GetComponent<Graphics.StackAnimator>().AddAnimation(
				new Graphics.StackAnimation("Close",
				GetComponent<Graphics.Sprite>(),
				new List<List<Rectangle>> { open03, open02, open01, idle01 },
				166,
				false));
		}
	}
}
