using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using AstroMonkey.Graphics;

namespace AstroMonkey.UI
{
    class UIElement: Core.GameObject, IComparable<UIElement>
    {
		public bool         enable				= true;
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

        public virtual Vector2 WorldspaceToScreenspace(Vector2 centerPos)
        {
            Vector2 tempPos = Vector2.Zero;
            tempPos = centerPos - ViewManager.Instance.WinSize() / 2;
            tempPos.X += position.X;
            tempPos.Y += position.Y;

            return tempPos;
        }
		public virtual void Draw(SpriteBatch spriteBatch, Vector2 centerPos) {}
		public virtual void OnClick() {}
		public virtual void OnEnter() {}
		public virtual void OnExit() {}
	}
}
