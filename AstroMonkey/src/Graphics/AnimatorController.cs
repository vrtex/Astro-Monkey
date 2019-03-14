using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimatorController: Core.Component
    {
        public  Dictionary<string, Animation>       animations = new Dictionary<string, Animation>();
        public  Animation                           currentAnim = null;

        public AnimatorController(Core.GameObject go) : base(go)
        {
            
        }

        public void SetAnimation(string name)
        {
            animations.TryGetValue(name, out currentAnim);
        }

        public void AddAnimation(Animation anim)
        {
            animations.Add(anim.name, anim);
        }
    }
}
