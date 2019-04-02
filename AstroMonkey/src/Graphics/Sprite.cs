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
        public  Vector2         origin;
        public  float           layer;
        public  List<Rectangle> rect;
        public  int             stackOffset;

        public Sprite(Core.GameObject go, string _image, List<Rectangle> _rect, float _layer = 0f) : base(go)
        {
            name = _image;
            image = SpriteContainer.Instance.GetImage(_image);
            rect = _rect;
            color = Color.White;
            anchor = Vector2.Zero;
            layer = _layer;
            stackOffset = 1;
            origin = new Vector2(rect[0].Width / 2, rect[0].Height / 2);
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
