using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimatorController: Core.Component
    {
        public  Dictionary<AnimationState, Animation>   animations = new Dictionary<AnimationState, Animation>();
        public  AnimationState                          currentAnim;

        public AnimatorController(Core.GameObject go) : base(go)
        {

        }
    }
}
