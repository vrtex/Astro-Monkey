using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using AstroMonkey.Navigation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AstroMonkey.Graphics;
using System.Diagnostics;

namespace AstroMonkey.Assets.Objects
{
	class AmmoAmount: UI.Text
	{
		public AmmoAmount() : this(new Transform())
        {
			Load();
		}
		public AmmoAmount(Transform _transform) : base(_transform)
        {
			Load();
		}
		public AmmoAmount(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
		}
		public AmmoAmount(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
		}
		
		private void Load()
		{
			anchorPosition = new Vector2(0.1f, 0.2f);
			anchorSize = new Vector2(0.1f, 0.1f);
			fontName = "text";

			AnchorToWorldspace(1f);

			AddComponent(new Input.InputUI(this));
		}

		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{
			Vector2 tempPos = Vector2.Zero;
			tempPos = centerPos - ViewManager.Instance.WinSize() / 2;
			tempPos.X += position.X;
			tempPos.Y += position.Y;
			spriteBatch.DrawString(SpriteContainer.Instance.GetFont(fontName), "jestem napis", tempPos, color);
		}

		public override void OnClick()
		{
			Debug.WriteLine("Jestem klikniety");
		}

	}
}
