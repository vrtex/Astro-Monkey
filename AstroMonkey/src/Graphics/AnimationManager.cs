using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimationManager
    {
        public List<Animator> animators = new List<Animator>();
        public static AnimationManager  Instance { get; private set; } = new AnimationManager();

        static AnimationManager()
        {
            //powinien przejżeć wszystkie obiekty i popobierać z nich animatory
        }

        public void AddAnimator(Animator animatorController)
        {
            animators.Add(animatorController);
        }

        public void Update(double deltaTime)
        {
            foreach(Animator a in animators)
            {
                if(a.currentAnim != null)
                {
                    Sprite sprite = a.Parent.GetComponent<Sprite>();

                    a.currentAnim.currentTime += (int)(deltaTime * 1000);
                    if(a.currentAnim.currentTime >= a.currentAnim.speed)
                    {
                        
                        a.currentAnim.currentTime -= a.currentAnim.speed;
                        if(a.currentAnim.loop)
                        {
                            ++a.currentAnim.currentFrame;
                            if(a.currentAnim.currentFrame == a.currentAnim.frames.Count)
                            {
                                a.currentAnim.currentFrame = 0;
                            }
                        }
                        else
                        {
                            if(a.currentAnim.currentFrame < a.currentAnim.frames.Count -1)
                            {
                                ++a.currentAnim.currentFrame;
                            }
                        }
                            
                    }

                    sprite.rect = a.currentAnim.frames[a.currentAnim.currentFrame];
                }
            }
        }


    }
}
