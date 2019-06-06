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

        protected Vector2 position;
        protected Vector2 size;

        private Texture2D texture;

        public Texture2D Texture {
            get => texture;
            set
            {
                texture = value;
                SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
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
            toReturn.Width = stretchX ? (int)(ViewManager.Instance.graphics.PreferredBackBufferWidth * size.X) : Texture.Width;
            toReturn.Height = stretchY ? (int)(ViewManager.Instance.graphics.PreferredBackBufferHeight * size.Y) : Texture.Height;
            return toReturn;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Texture, destinationRectangle: GetDestinationRectangle(), sourceRectangle: SourceRectangle);
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
    }
}
