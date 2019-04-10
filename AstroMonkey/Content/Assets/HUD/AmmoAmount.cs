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
			anchorSize = new Vector2(0.2f, 0.1f);
			fontName = "planetary";

			AnchorToWorldspace(1f);

			AddComponent(new Input.InputUI(this));
		}

		public override Vector2 WorldspaceToScreenspace(Vector2 centerPos)
		{
			Vector2 tempPos = Vector2.Zero;
			tempPos = centerPos - ViewManager.Instance.WinSize() / 2;
			tempPos.X += position.X;
			tempPos.Y += position.Y;

			return tempPos;
		}

		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{
			if(!enable) return;
			spriteBatch.DrawString(SpriteContainer.Instance.GetFont(fontName), "jestem napis", WorldspaceToScreenspace(centerPos), color);
		}

		public override void OnClick()
		{
			if(!enable) return;
			Debug.WriteLine("Jestem klikniety");
		}

		public override void OnEnter()
		{
			if(!enable) return;
			color = Color.Red;
		}
		public override void OnExit()
		{
			if(!enable) return;
			color = Color.White;
		}

	}
}
