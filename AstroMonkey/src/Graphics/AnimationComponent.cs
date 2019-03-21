using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimationComponent
    {
        public  string              name;
        public  Sprite              sprite;
        public  int                 speed; //pręskość odtwarzania kolejnych klatek
        public  bool                loop;
        public  int                 currentFrame;
        public  int                 currentTime;

        public AnimationComponent(string _name, Sprite _sprite, int _speed, bool _loop = false)
        {
            name = _name;
            sprite = _sprite;
            currentFrame = 0;
            currentTime = 0;
            speed = _speed;
            loop = _loop;
        }
    }
}
