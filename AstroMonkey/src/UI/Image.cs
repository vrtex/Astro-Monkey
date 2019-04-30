using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.UI
{
    class Image: UIElement
    {
        public Graphics.Sprite      image;

		public Image(Core.Transform _transform) : base(_transform)
        {

		}

		public override Vector2 WorldspaceToScreenspace(Vector2 centerPos) { return Vector2.Zero; }
		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos) { }
		public override void OnClick() { }
		public override void OnEnter() { }
		public override void OnExit() { }
	}
}
