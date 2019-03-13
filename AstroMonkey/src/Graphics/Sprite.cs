using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class Sprite: Core.Component
    {
        public  string          name; //nazwa grafiki z bazy SpriteContainer
        public  Texture2D       image;
        public  Rectangle       rect;
        public  Color           color;
        public  Vector2         anchor;

        public Sprite(Core.GameObject go, string _image, Rectangle _rect): base(go)
        {
            name    = _image;
            image   = SpriteContainer.Instance.GetImage(_image);
            rect    = _rect;
            color   = Color.Wheat;
            anchor  = Vector2.Zero;
        }

        public bool SetImage(string _image)
        {
            Texture2D temp = SpriteContainer.Instance.GetImage(_image);
            if(temp != null)
            {
                image   = temp;
                name    = _image;
                return true;
            }
            return false;
        }
    }
}
