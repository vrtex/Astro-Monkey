﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace AstroMonkey.UI
{
    class UIElement: Core.GameObject, IComparable<UIElement>
    {
        public int			zOrder				= 0;
        public Vector2      anchorPosition		= Vector2.Zero;
		public Vector2		anchorSize			= Vector2.Zero;
		public Util.Anchor  center				= Util.Anchor.LeftTop;
		public Rectangle    position            = new Rectangle();

		public UIElement(Core.Transform _transform) : base(_transform)
        {

		}

		public int CompareTo(UIElement other)
        {
            int sort = zOrder - other.zOrder;
            if(sort == 0) sort = (int)((anchorPosition.Y - other.anchorPosition.Y) * 100f);
            return sort;
        }

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{

		}

		//scaleWidthFactor - względem której długości krawędzi ma się skalować interfejs
		//0 względem wysokości | 1 względem szerokości | wszystko pomiędzy jest procentowo
		protected void AnchorToWorldspace(float scaleWidthFactor)
		{
			float windowSize = 0f;
			windowSize = Graphics.ViewManager.Instance.graphics.PreferredBackBufferWidth * scaleWidthFactor
						+ Graphics.ViewManager.Instance.graphics.PreferredBackBufferHeight * (1f - scaleWidthFactor);

			position.X = (int)Math.Floor(anchorPosition.X * windowSize);
			position.Y = (int)Math.Floor(anchorPosition.Y * windowSize);

			position.Width = (int)Math.Floor(anchorSize.X * windowSize);
			position.Height = (int)Math.Floor(anchorSize.Y * windowSize);
		}

		public virtual void OnClick()
		{
			
		}
	}
}
