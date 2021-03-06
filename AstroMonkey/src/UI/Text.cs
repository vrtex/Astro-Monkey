﻿using AstroMonkey.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.UI
{
    class Text: UIElement
    {
        public string			fontName	= "text";
		public Color            color		= Util.Statics.Colors.WHITE_1;
		public string           text        = "";

		public Text() : this(new Core.Transform())
		{
		}
		public Text(Core.Transform _transform) : base(_transform)
        {	
			
        }

        public Text(string text, string fontName, Vector2 anchorPosition, Vector2 anchorSize) : this(new Core.Transform())
		{
			SetText(text, fontName, anchorPosition, anchorSize);
			Load();
		}

        public void SetText(string text)
        {
            this.text = text;
        }

        public void SetText(string text, string fontName, Vector2 anchorPosition, Vector2 anchorSize)
		{
			this.anchorPosition = anchorPosition;
			this.anchorSize = anchorSize;
			this.fontName = fontName;
            SetText(text);
			color = Util.Statics.Colors.WHITE_1;
			AnchorToWorldspace(0.5f);
		}

		public void Load()
		{
			
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

		public override void OnClick() { }
		public override void OnEnter() { }
		public override void OnExit() { }
	}
}
