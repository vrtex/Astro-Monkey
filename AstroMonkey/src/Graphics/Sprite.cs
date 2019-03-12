using Microsoft.Xna.Framework;

namespace AstroMonkey.Graphics
{
    class Sprite: Core.Component
    {
        public  string          image;
        public  Util.Rect       rect;
        public  Color           color;
        public  Vector2         anchor;

        public Sprite(Core.GameObject go, string _image, Util.Rect _rect): base(go)
        {
            image   = _image;
            rect    = _rect;
            color   = Color.Wheat;
            anchor  = Vector2.Zero;
        }
    }
}
