using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Input
{
	class InputUI: Core.Component
	{
		private bool        enter = false;

		public InputUI(Core.GameObject parent) : base(parent)
		{
            ActionBinding clicked;
            clicked = InputManager.Manager.GetActionBinding("click");
            if(clicked == null)
                clicked = new ActionBinding(EMouseButton.Left);

            clicked.OnTrigger += OnClick;

            if(InputManager.Manager.GetActionBinding("click") == null)
			    InputManager.Manager.AddActionBinding("click", clicked);

            InputManager.Manager.OnMouseMove += MouseMove;
		}

        private void MouseMove(MouseInputEventArgs mouseArgs)
        {
            OnEnter();
            OnExit();
        }

        private void OnClick() //wykrycie kliknięcia w obszar elementu UI
		{
            Console.WriteLine("click " + (parent as UI.UIElement).position );
			Vector2 mousePos = InputManager.Manager.MouseCursor;
			Rectangle parentPos = (parent as UI.UIElement).position;
			
			if(parentPos.X <= mousePos.X
			&& parentPos.X + parentPos.Width >= mousePos.X
			&& parentPos.Y <= mousePos.Y
			&& parentPos.Y + parentPos.Height >= mousePos.Y)
			{
				(parent as UI.UIElement).OnClick();
			}
		}

		private void OnEnter()
		{
			if(enter) return;

			enter = true;

			Vector2 mousePos = InputManager.Manager.MouseCursor;
			Rectangle parentPos = (parent as UI.UIElement).position;

			if(parentPos.X <= mousePos.X
			&& parentPos.X + parentPos.Width >= mousePos.X
			&& parentPos.Y <= mousePos.Y
			&& parentPos.Y + parentPos.Height >= mousePos.Y)
			{
				(parent as UI.UIElement).OnEnter();
			}
		}

		private void OnExit()
		{
			if(!enter) return;

			enter = false;

			Vector2 mousePos = InputManager.Manager.MouseCursor;
			Rectangle parentPos = (parent as UI.UIElement).position;

			if(!(parentPos.X <= mousePos.X
			&& parentPos.X + parentPos.Width >= mousePos.X
			&& parentPos.Y <= mousePos.Y
			&& parentPos.Y + parentPos.Height >= mousePos.Y))
			{
				(parent as UI.UIElement).OnExit();
			}
		}

        public override void Destroy()
        {
            base.Destroy();
            Console.WriteLine("lol " + (parent as UI.UIElement).position );
            Input.InputManager.Manager.GetActionBinding("click").OnTrigger -= OnClick;
            InputManager.Manager.OnMouseMove -= MouseMove;
        }
    }
}
