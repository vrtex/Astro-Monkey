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


        public Keys Key { get; private set; } = Keys.None;
        public EMouseButton MouseButton { get; private set; } = EMouseButton.None;
        private bool status = false;

        public ActionBinding(Keys key)
        {
            this.Key = key;

            InputManager.Manager.OnKeyPressed += CheckKey;
            InputManager.Manager.OnKeyReleased += CheckKey;
        }

        public ActionBinding(EMouseButton button)
        {
            this.MouseButton = button;

            InputManager.Manager.OnMouseButtonPressed += CheckMouseButton;
            InputManager.Manager.OnMouseButtonReleased += CheckMouseButton;
        }

        internal void CheckKey(Input.KeyInputEventArgs args)
        {
            if(!args.Key.Equals(Key))
                return;

            if(args.pressed && !status)
                FlipStatus();
            if(!args.pressed && status)
                FlipStatus();

        }

        internal void CheckMouseButton(MouseInputEventArgs mouseArgs)
        {
            if(mouseArgs.Button != MouseButton)
                return;

            if(mouseArgs.pressed && !status)
                FlipStatus();
            if(!mouseArgs.pressed && status)
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
