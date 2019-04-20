using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;

namespace AstroMonkey.Gameplay
{
    public class InteractComponent : Component
    {
        public InteractComponent(GameObject parent) : base(parent)
        {
        }

        public virtual void Interact(GameObject interacting)
        {
            Console.WriteLine(interacting);
        }
    }
}
