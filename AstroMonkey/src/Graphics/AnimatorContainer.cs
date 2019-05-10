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
		public  string									nextAnim    = "";

        public AnimatorContainer(Core.GameObject go) : base(go)
        {

        }

		public void SetNextAnimation(string name)
		{
			nextAnim = name;
		}

        public void SetAnimation(string name)
        {
            animations.TryGetValue(name, out currentAnim);
            if(currentAnim == null)
            {
                Console.WriteLine("Lolz, bogus animation " + name + ". Animator::SetAnimation");
            }
            else
            {
                if(currentAnim.loop == false && currentAnim.currentFrame != 0)
                {
                    currentAnim.currentTime = 0;
                    currentAnim.currentFrame = 0;
                }
            }
        }

        public void AddAnimation(AnimationComponent anim)
        {
            animations.Add(anim.name, anim);
        }
    }
}
