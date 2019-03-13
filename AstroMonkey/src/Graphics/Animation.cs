using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public  string              image; //nazwa grafiki z bazy SpriteContainer
        public  List<Util.Rect>     frames; //klatki jakie po kolei są odtwarzane w animacji
        public  int                 speed; //pręskość odtwarzania kolejnych klatek
        public  bool                loop;

        public Animation(Core.GameObject go): base(go)
        {

        }
    }
}
