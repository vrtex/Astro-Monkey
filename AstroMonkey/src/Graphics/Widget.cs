using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{

    class Widget
    {
        public bool stretchX = false;
        public bool stretchY = false;

        public Vector2 position { get; protected set; }
        protected Vector2 size;
        protected Vector2 scale = Vector2.One;

        private Texture2D texture;

        public int ZOrder = 0;

        public Texture2D Texture {
            get => texture;
            set
            {
                texture = value;
                SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }

        public Vector2 Scale
        {
            get => scale;
            set
            {
                scale = value;
                size = new Vector2();
                stretchX = false;
                stretchY = false;
            }
        }

        public Rectangle SourceRectangle;

        public Widget(Vector2 position) : this(position, new Vector2())
        {

        }

        public Widget(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
            stretchX = !Util.Statics.IsNearlyEqual(size.X, 0);
            stretchY = !Util.Statics.IsNearlyEqual(size.Y, 0);
        }

        public virtual Rectangle GetDestinationRectangle()
        {
            Rectangle toReturn = new Rectangle();
            toReturn.X = (int)(ViewManager.Instance.graphics.PreferredBackBufferWidth * position.X);
            toReturn.Y = (int)(ViewManager.Instance.graphics.PreferredBackBufferHeight * position.Y);
            toReturn.Width = stretchX ? (int)(ViewManager.Instance.graphics.PreferredBackBufferWidth * size.X) : SourceRectangle.Width;
            toReturn.Height = stretchY ? (int)(ViewManager.Instance.graphics.PreferredBackBufferHeight * size.Y) : SourceRectangle.Height;
            toReturn.Width = (int)(toReturn.Width * scale.X);
            toReturn.Height = (int)(toReturn.Height * scale.Y);
            return toReturn;
        }

        public Vector2 GetPixelPosition()
        {
            var rect = GetDestinationRectangle();
            return new Vector2(rect.Left, rect.Top);
        }

        public Vector2 GetPixelSize()
        {
            return new Vector2(ViewManager.Instance.graphics.PreferredBackBufferWidth * size.X,
                              ViewManager.Instance.graphics.PreferredBackBufferHeight * size.Y);
        }

        public virtual Vector2 GetScreenEndPoint()
        {
            Vector2 toReturn = new Vector2();

            Rectangle rect = GetDestinationRectangle();

            toReturn.X = (float)(rect.X + rect.Width) / (float)ViewManager.Instance.graphics.PreferredBackBufferWidth;
            toReturn.Y = (float)(rect.Y + rect.Height) / (float)ViewManager.Instance.graphics.PreferredBackBufferHeight;

            return toReturn;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Texture, destinationRectangle: GetDestinationRectangle(), sourceRectangle: SourceRectangle);
        }
    }


    class WidgetComparator : IComparer<Widget>
    {
        int IComparer<Widget>.Compare(Widget x, Widget y)
        {
            return x.ZOrder - y.ZOrder;
        }
    }
}
