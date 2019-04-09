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
	class TextButton: UI.Text
	{
		public TextButton() : this(new Transform())
		{
		}
		public TextButton(Transform _transform) : base(_transform)
		{
		}
		public TextButton(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
		{
		}
		public TextButton(Vector2 position) : this(new Core.Transform(position, Vector2.One))
		{
		}

		public void SetTextButton(string text, string fontName, Vector2 anchorPosition, Vector2 anchorSize)
		{
			this.anchorPosition = anchorPosition;
			this.anchorSize = anchorSize;
			this.text = text;
			this.fontName = fontName;
			color = Util.Statics.AstroColor(28);

			Load();
		}

		private void Load()
		{
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
			spriteBatch.DrawString(SpriteContainer.Instance.GetFont(fontName), text, WorldspaceToScreenspace(centerPos), color);
		}

		public override void OnClick()
		{
			if(!enable) return;
			Debug.WriteLine("Jestem kliknięty");
		}

		public override void OnEnter()
		{
			if(!enable) return;
			color = Util.Statics.AstroColor(9);
		}
		public override void OnExit()
		{
			if(!enable) return;
			color = Util.Statics.AstroColor(28);
		}

	}
}
