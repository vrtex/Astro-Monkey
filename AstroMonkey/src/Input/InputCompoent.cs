using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Input
{
    class InputCompoent : Core.Component
    {
        Navigation.MovementComponent moveComp;
        private readonly AxisBinding verticalAxis;
        private readonly AxisBinding horizontalAxis;

        public InputCompoent(Core.GameObject parent) : base(parent)
        {
            moveComp = parent.GetComponent<Navigation.MovementComponent>();
            verticalAxis = new AxisBinding(Keys.S, Keys.W);
            horizontalAxis = new AxisBinding(Keys.D, Keys.A);

            verticalAxis.OnUpdate += Move;
            horizontalAxis.OnUpdate += Move;

            InputManager.Manager.AddAxisBinding("move up", verticalAxis);
            InputManager.Manager.AddAxisBinding("move right", horizontalAxis);
        }

        private void Move(float trash)
        {
            if(moveComp == null)
                return;

            Vector2 newDirection = new Vector2(horizontalAxis.Value, verticalAxis.Value);
            if(!Util.Statics.IsNearlyEqual(newDirection.Length(), 0, 0.01))
                newDirection.Normalize();
            
            moveComp.AddMovementInput(newDirection);
        }

    }
}
