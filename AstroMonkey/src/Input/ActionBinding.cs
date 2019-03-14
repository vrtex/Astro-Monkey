using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AstroMonkey.Input
{
    class ActionBinding
    {
        public delegate void ActionBindingEvent();
        public event ActionBindingEvent OnTrigger;
        public event ActionBindingEvent OnRelease;


        public Keys key { get; private set; }
        private bool status = false;
        public ActionBinding(Keys key)
        {
            this.key = key;
        }

        internal void CheckKey(Input.KeyInputEventArgs args)
        {
            if(!args.key.Equals(key))
                return;

            if(args.pressed && !status)
                FlipStatus();
            if(!args.pressed && status)
                FlipStatus();

        }

        private void FlipStatus()
        {
            status = !status;
            if(status && OnTrigger != null)
                OnTrigger();
            else if(!status && OnRelease != null)
                OnRelease();
        }
    }
}
