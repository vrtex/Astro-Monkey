using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class Animation: AnimationComponent
    {
        public  List<Rectangle>     frames; //klatki jakie po kolei są odtwarzane w animacji   

        public Animation(string _name, Sprite _sprite, List<Rectangle> _frames, int _speed, bool _loop = false) : base(_name, _sprite, _speed, _loop)
        {
            frames = _frames;
        }

        public void SetFrames(List<Rectangle> rectangle)
        {
            frames = rectangle;
        }

        public void AddFrame(Rectangle rectangle)
        {
            frames.Add(rectangle);
        }
    }
}
