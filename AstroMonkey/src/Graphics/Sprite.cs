using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class Sprite: Core.Component
    {
        public  string          name; //nazwa grafiki z bazy SpriteContainer
        public  Texture2D       image;
        public  Color           color;
        public  Vector2         anchor;
        public  float           layer;
        public  List<Rectangle> rect;

        public Sprite(Core.GameObject go, string _image, List<Rectangle> _rect, float _layer = 0f) : base(go)
        {
            name = _image;
            image = SpriteContainer.Instance.GetImage(_image);
            rect = _rect;
            color = Color.Wheat;
            anchor = Vector2.Zero;
            layer = _layer;
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
