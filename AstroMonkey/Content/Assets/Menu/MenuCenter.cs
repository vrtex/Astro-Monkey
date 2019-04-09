using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Objects
{
	class MenuCenter: Core.GameObject
	{
		public MenuCenter() : this(new Core.Transform())
		{
		}
		public MenuCenter(Core.Transform _transform)
		{
			Load(_transform);
		}
		public MenuCenter(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
		{
		}
		public MenuCenter(Vector2 position) : this(new Core.Transform(position, Vector2.One))
		{
		}

		private void Load(Core.Transform _transform)
		{
			transform = _transform;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}
