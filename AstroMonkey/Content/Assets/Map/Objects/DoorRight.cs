using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;
using System.Diagnostics;

namespace AstroMonkey.Assets.Objects
{
    class DoorRight: Door
	{
        public DoorRight() : this(new Core.Transform())
        {
        }

        public DoorRight(Core.Transform _transform) : base(_transform)
        {
            Load(_transform);
        }
        public DoorRight(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }

        public DoorRight(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

		protected override void Load(Core.Transform _transform)
		{
			base.Load(_transform);
			
			AddComponent(new Graphics.Sprite(this, "doorRight", idle01));
		}
	}

}
