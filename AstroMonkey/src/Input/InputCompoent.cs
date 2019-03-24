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
        private Core.GameObject target = new Core.GameObject();

        public InputCompoent(Core.GameObject parent) : base(parent)
        {
            moveComp = parent.GetComponent<Navigation.MovementComponent>();
            verticalAxis = new AxisBinding(Keys.S, Keys.W);
            horizontalAxis = new AxisBinding(Keys.D, Keys.A);
            ActionBinding playBinding = new ActionBinding(Keys.P);

            verticalAxis.OnUpdate += Move;
            horizontalAxis.OnUpdate += Move;
            playBinding.OnTrigger += Play;

            InputManager.Manager.AddAxisBinding("move up", verticalAxis);
            InputManager.Manager.AddAxisBinding("move right", horizontalAxis);
            InputManager.Manager.AddActionBinding("play", playBinding);

            moveComp.CurrentFocus = target;
            InputManager.Manager.OnMouseMove += MoveTarget;
        }

        private void Move(float trash)
        {
            if(moveComp == null)
                return;

            Vector2 newDirection = new Vector2(horizontalAxis.Value, verticalAxis.Value);
            if(!Util.Statics.IsNearlyEqual(newDirection.Length(), 0, 0.01))
                newDirection.Normalize();
            
            moveComp.AddMovementInput(newDirection);

            MoveTarget(new MouseInputEventArgs(EMouseButton.None, new Vector2(), new Vector2()));
        }

        private void MoveTarget(MouseInputEventArgs args)
        {
            target.transform.position = InputManager.Manager.MouseCursor + parent.transform.position - Graphics.ViewManager.Instance.ScreenSize / 2f;
        }

        private void Play()
        {
            Assets.Objects.Player player = (Assets.Objects.Player)parent;
            player.testSource.Play();
        }

    }
}
