using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class TextWidget : Widget
    {
        private string value;
        public Color Color = Color.White;
        public SpriteFont font = Graphics.SpriteContainer.Instance.GetFont("planetary");
        Vector2 textScale = new Vector2(1, 1);
        Vector2 textSize = new Vector2();

        public string Value {
            get => value;
            set
            {
                this.value = value;
                textSize = font.MeasureString(value);
                var graphics = ViewManager.Instance.graphics;
                Vector2 screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                Vector2 PixelSize = GetPixelSize();
                textScale.X = stretchX ? (PixelSize.X / textSize.X) : 1;
                textScale.Y = stretchY ? (PixelSize.Y / textSize.Y) : 1;
            }
        }

        public TextWidget(Vector2 position) : base(position)
        {
        }

        public TextWidget(Vector2 position, Vector2 size) : base(position, size)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            System.Console.WriteLine(GetPixelPosition());
            spriteBatch.DrawString(font, Value, GetPixelPosition(), Color, 0, new Vector2(), textScale, SpriteEffects.None, 0);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       