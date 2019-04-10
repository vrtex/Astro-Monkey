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
			ActionBinding clicked = new ActionBinding(EMouseButton.Left);

			clicked.OnTrigger += OnClick;

			InputManager.Manager.AddActionBinding("click", clicked);
		}

		private void OnClick() //wykrycie kliknięcia w obszar elementu UI
		{
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

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			OnEnter();
			OnExit();
		}
	}
}
