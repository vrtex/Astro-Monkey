using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AstroMonkey.UI
{
    class Image: UIElement
    {
        public Graphics.Sprite image;

		public Image(Core.Transform _transform) : base(_transform)
        {

		}

        public Image(string image, Rectangle rect, Vector2 anchorPosition, Vector2 anchorSize) : this(new Core.Transform())
        {
            this.image = new Graphics.Sprite(this, image, new List<Rectangle>{ rect });
            this.anchorPosition = anchorPosition;
            this.anchorSize = anchorSize;
        }

		// public override Vector2 WorldspaceToScreenspace(Vector2 centerPos) { return Vector2.Zero; }
		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
        {
            spriteBatch.Draw(image.image, WorldspaceToScreenspace(centerPos));
        }
		public override void OnClick() { }
		public override void OnEnter() { }
		public override void OnExit() { }
	}
}
