using System;
using Microsoft.Xna.Framework;

namespace AstroMonkey.UI
{
    class UIElement: Core.GameObject, IComparable<UIElement>
    {
        public int zOrder;
        public Rectangle anchor;

        public int CompareTo(UIElement other)
        {
            int sort = zOrder - other.zOrder;
            if(sort == 0) sort = anchor.Y - other.anchor.Y;
            return sort;
        }
    }
}
