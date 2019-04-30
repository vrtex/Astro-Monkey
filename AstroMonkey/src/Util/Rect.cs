using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Util
{
    class Rect
    {
        public Vector2 position;
        public Vector2 size;

        public Rect()
        {
            position = Vector2.Zero;
            size = Vector2.Zero;
        }

        public Rect(Vector2 _position, Vector2 _size)
        {
            position = new Vector2(_position.X, _position.Y);
            size = new Vector2(_size.X, _size.Y);
        }

        public Rect(float x, float y, float w, float h)
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
        }

        public Rect(int x, int y, int w, int h)
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
        }
    }
}
