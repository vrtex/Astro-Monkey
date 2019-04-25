using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.effects
{
	class NoEnergy: PostprocessingEffect
	{
		private RenderTarget2D buffer;
		private BlendState blendState;

		public NoEnergy(GraphicsDevice device, SpriteBatch spriteBatch) : base(device, spriteBatch)
		{
			SetParameters(Color.White, 0);
			buffer = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
		}

		public void SetParameters(Color boostColor, float rotation)
		{
			blendState = new BlendState();

		}

		public override Texture2D Apply(Texture2D input, GameTime gameTime)
		{
			graphicsDevice.SetRenderTarget(buffer);
			graphicsDevice.Clear(Color.White);
			spriteBatch.Begin(SpriteSortMode.Deferred, blendState);
			spriteBatch.Draw(input, Vector2.Zero, Color.White);
			spriteBatch.End();

			graphicsDevice.SetRenderTarget(null);
			return buffer;
		}
	}
}
