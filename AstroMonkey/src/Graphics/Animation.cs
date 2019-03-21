using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    public enum AnimationState
    {
        Idle    = 0,
        Walk    = 1,
        Run     = 2,
        Attack  = 3,
        Dead    = 4
    }

    class Animation: Core.Component
    {
        public  Sprite              sprite;
        public  List<Rectangle>     frames; //klatki jakie po kolei są odtwarzane w animacji
        public  int                 speed; //pręskość odtwarzania kolejnych klatek
        public  bool                loop;

        public Animation(Core.GameObject go, Sprite _sprite) : base(go)
        {
            sprite = _sprite;

        }
    }
}
