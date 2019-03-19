using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimatorContainer: Core.Component
    {
        public  Dictionary<string, AnimationComponent>  animations  = new Dictionary<string, AnimationComponent>();
        public  AnimationComponent                      currentAnim = null;

        public AnimatorContainer(Core.GameObject go) : base(go)
        {

        }

        public void SetAnimation(string name)
        {
            animations.TryGetValue(name, out currentAnim);
            if(currentAnim == null)
                Console.WriteLine("Lolz, bogus animation " + name + ". Animator::SetAnimation");
        }

        public void AddAnimation(AnimationComponent anim)
        {
            animations.Add(anim.name, anim);
        }
    }
}
