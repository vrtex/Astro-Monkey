using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class StackAnimation
    {
        public  string                  name;
        public  Sprite                  sprite;
        public  List<List<Rectangle>>   frames; //klatki jakie po kolei są odtwarzane w animacji
        public  int                     speed; //pręskość odtwarzania kolejnych klatek
        public  bool                    loop;
        public  int                     currentFrame;
        public  int                     currentTime;

        public StackAnimation(string _name, Sprite _sprite, int _speed, bool _loop = false)
        {
            name = _name;
            sprite = _sprite;
            currentFrame = 0;
            currentTime = 0;
            speed = _speed;
            loop = _loop;
        }

        public StackAnimation(string _name, Sprite _sprite, List<List<Rectangle>> _frames, int _speed, bool _loop = false)
        {
            name = _name;
            sprite = _sprite;
            frames = _frames;
            currentFrame = 0;
            currentTime = 0;
            speed = _speed;
            loop = _loop;
        }

        public void SetFrames(List<List<Rectangle>> rectangle)
        {
            frames = rectangle;
        }

        public void AddFrame(List<Rectangle> rectangle)
        {
            frames.Add(rectangle);
        }
    }
}
