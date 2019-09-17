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
        private static readonly WidgetComparator comparator = new WidgetComparator();

        private static readonly WidgetManager manager = new WidgetManager();

        private readonly List<Widget> widgets = new List<Widget>();

        private readonly List<Widget> toAdd = new List<Widget>();
        private readonly List<Widget> toRemove = new List<Widget>();

        public static void Update()
        {
            if(manager.toAdd.Count != 0)
            {
                lock(manager.toAdd)
                {
                    foreach(var widget in manager.toAdd)
                        manager.widgets.Add(widget);
                    manager.widgets.Sort(comparator);
                    manager.toAdd.Clear();
                }
            }
            if(manager.toRemove.Count != 0)
            {
                foreach(var widget in manager.toRemove)
                    manager.widgets.Remove(widget);
                manager.widgets.Sort(comparator);
                manager.toRemove.Clear();
            }
        }

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
            lock(manager.toAdd)
                manager.toAdd.Add(toAdd);
            //manager.widgets.Add(toAdd);
            //manager.widgets.Sort(comparator);
        }

        public static void RemoveWidget(Widget toRemove)
        {
            lock(manager.toRemove)
                manager.toRemove.Add(toRemove);
            //manager.widgets.Remove(toRemove);
            //manager.widgets.Sort(comparator);
        }
    }
}
