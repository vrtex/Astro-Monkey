using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class StackAnimation: AnimationComponent
    {
        public  List<List<Rectangle>>   frames; //klatki jakie po kolei są odtwarzane w animacji

        public StackAnimation(string _name, Sprite _sprite, List<List<Rectangle>> _frames, int _speed, bool _loop = false): base(_name, _sprite, _speed, _loop)
        {
            frames = _frames;
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
