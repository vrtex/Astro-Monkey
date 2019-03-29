using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
    class AnimationManager
    {
        public List<AnimatorContainer>  animators       = new List<AnimatorContainer>();
        public static AnimationManager  Instance { get; private set; } = new AnimationManager();

        private AnimationManager()
        {
        }

        public void AddAnimator(AnimatorContainer animator)
        {
            animators.Add(animator);
        }

        public void RemoveAnimator(AnimatorContainer animator)
        {
            animators.RemoveAll( x => x.Equals(animator));
        }

        public void Update(double deltaTime)
        {
            foreach(AnimatorContainer a in animators)
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
                            if(a is Animator)
                            {
                                if(a.currentAnim.currentFrame == (a.currentAnim as Animation).frames.Count)
                                {
                                    a.currentAnim.currentFrame = 0;
                                }
                                sprite.rect[0] = (a.currentAnim as Animation).frames[a.currentAnim.currentFrame];
                            }
                            else
                            {
                                if(a.currentAnim.currentFrame == (a.currentAnim as StackAnimation).frames.Count)
                                {
                                    a.currentAnim.currentFrame = 0;
                                }
                                sprite.rect = (a.currentAnim as StackAnimation).frames[a.currentAnim.currentFrame];
                            }
                        }
                        else
                        {
                            if(a is Animator)
                            {
                                if(a.currentAnim.currentFrame < (a.currentAnim as Animation).frames.Count - 1)
                                {
                                    ++a.currentAnim.currentFrame;
                                }
                                sprite.rect[0] = (a.currentAnim as Animation).frames[a.currentAnim.currentFrame];
                            }
                            else
                            {
                                if(a.currentAnim.currentFrame < (a.currentAnim as StackAnimation).frames.Count - 1)
                                {
                                    ++a.currentAnim.currentFrame;
                                }
                                sprite.rect = (a.currentAnim as StackAnimation).frames[a.currentAnim.currentFrame];
                            }
                        }
                            
                    }
                }
            }

        }


    }
}
