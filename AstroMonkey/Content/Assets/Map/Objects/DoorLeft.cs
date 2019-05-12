using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;

namespace AstroMonkey.Assets.Objects
{
    class DoorLeft: Door
    {
        public DoorLeft() : this(new Core.Transform())
        {
        }

        public DoorLeft(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public DoorLeft(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public DoorLeft(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

		protected override void Load(Core.Transform _transform)
        {
			base.Load(_transform);

            AddComponent(new Graphics.Sprite(this, "doorLeft", idle01));

			//kolizje na framugach
			openCollider = AddComponent(new BoxCollider(this, CollisionChanell.Object, new Vector2(-12, 10), 5, 12)); //lewa
			openCollider.isActive = false;

		}
    }

}
