using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class StackAnimator: Core.Component
    {
        public  Dictionary<string, StackAnimation>       animations = new Dictionary<string, StackAnimation>();
        public  StackAnimation                           currentAnim = null;

        public StackAnimator(Core.GameObject go) : base(go)
        {

        }

        public void SetAnimation(string name)
        {
            animations.TryGetValue(name, out currentAnim);
            if(currentAnim == null)
                Console.WriteLine("Lolz, bogus animation " + name + ". Animator::SetAnimation");
        }

        public void AddAnimation(StackAnimation anim)
        {
            animations.Add(anim.name, anim);
        }
    }
}
