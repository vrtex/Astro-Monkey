using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.UI
{
    class Text: UIElement
    {
        public string			fontName;
		public Color            color		= Color.White;
		public string           text        = "";

		public Text(Core.Transform _transform) : base(_transform)
        {
			
		}

		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{

		}

		public override void OnClick()
		{

		}
	}
}
