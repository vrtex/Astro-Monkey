using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Input
{
	class InputUI: Core.Component
	{
		public InputUI(Core.GameObject parent) : base(parent)
		{
			ActionBinding clicked = new ActionBinding(EMouseButton.Left);

			clicked.OnTrigger += OnClick;

			InputManager.Manager.AddActionBinding("click", clicked);
		}

		private void OnClick() //wykrycie kliknięcia w obszar elementu UI
		{
			Vector2 mousePos = InputManager.Manager.MouseCursorInWorldSpace;
			Rectangle parentPos = (parent as UI.UIElement).position;

			if(parentPos.X <= mousePos.X
			&& parentPos.X + parentPos.Height >= mousePos.X
			&& parentPos.Y <= mousePos.Y
			&& parentPos.Y + parentPos.Height >= mousePos.Y)
			{
				(parent as UI.UIElement).OnClick();
			}
		}
	}
}
