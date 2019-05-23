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
						(d as Assets.Objects.Door).openCollider.isActive = false;
						(d as Assets.Objects.Door).closeCollider.isActive = true;
						foreach(Assets.Objects.NavPoint nav in (d as Assets.Objects.Door).navPoints)
						{
							nav.isActive = false;
						}
					}
					else
					{
						(d as Assets.Objects.Door).isOpen = true;
						d.GetComponent<Graphics.StackAnimator>().SetAnimation("Open");
						(d as Assets.Objects.Door).openCollider.isActive = true;
						(d as Assets.Objects.Door).closeCollider.isActive = false;
						foreach(Assets.Objects.NavPoint nav in (d as Assets.Objects.Door).navPoints)
						{
							nav.isActive = true;
						}
					}
				}
			}

			isOn = !isOn;
			if(isOn)
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("On");
				(parent as Assets.Objects.Terminal).computerSFX.Play();
			}
			else
			{
				parent.GetComponent<Graphics.StackAnimator>().SetAnimation("Off");
				(parent as Assets.Objects.Terminal).computerSFX.Play();
			}
			
		}
	}
}
