using AstroMonkey.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Gameplay
{
	class DoorTerminal: InteractComponent
	{
		public List<GameObject> doors = new List<GameObject>();

		public bool             isOn = true;

		public DoorTerminal(GameObject parent) : base(parent)
		{

		}

		public override void Interact(GameObject interacting)
		{
			foreach(GameObject d in doors)
			{
				if(d is Assets.Objects.Door)
				{
					if((d as Assets.Objects.Door).isOpen)
					{
						(d as Assets.Objects.Door).isOpen = false;
						d.GetComponent<Graphics.StackAnimator>().SetAnimation("Close");
						d.GetComponent<Physics.Collider.Collider>().isActive = true;
					}
					else
					{
						(d as Assets.Objects.Door).isOpen = true;
						d.GetComponent<Graphics.StackAnimator>().SetAnimation("Open");
						d.GetComponent<Physics.Collider.Collider>().isActive = false;
					}
				}
			}

			isOn = !isOn;
			if(isOn)
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("On");
			}
			else
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Off");
			}
			
		}
	}
}
