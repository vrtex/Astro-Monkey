using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.effects
{
	class PostprocessingEffect
	{
		protected GraphicsDevice graphicsDevice;
		protected SpriteBatch spriteBatch;

		public PostprocessingEffect(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
		{
			this.graphicsDevice = graphicsDevice;
			this.spriteBatch = spriteBatch;
		}

		public virtual Texture2D Apply(Texture2D input, GameTime gameTime)
		{
			return input;
		}
	}
}
