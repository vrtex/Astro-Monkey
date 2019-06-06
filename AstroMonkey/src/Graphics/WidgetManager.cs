using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class WidgetManager
    {
        private static readonly WidgetManager manager = new WidgetManager();

        private readonly List<Widget> widgets = new List<Widget>();

        public static void Render(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {

            spriteBatch.Begin();
            foreach(Widget widget in manager.widgets)
            {
                widget.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public static void AddWidget(Widget toAdd)
        {
            manager.widgets.Add(toAdd);
        }
    }
}
