using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using AstroMonkey.Graphics;
using AstroMonkey.Util;

namespace AstroMonkey.Input
{
    class InputComponent : Core.Component
    {
        Navigation.MovementComponent moveComp;
        private readonly AxisBinding verticalAxis;
        private readonly AxisBinding horizontalAxis;
        private Core.GameObject target = new Core.GameObject();
        private bool projectileToSpawn = false;

        private readonly string verticalBindingName = "move up";
        private readonly string horizontalBindingName = "move right";
        private readonly string spawnBindingName = "spawn";

        public InputComponent(Core.GameObject parent) : base(parent)
        {
            moveComp = parent.GetComponent<Navigation.MovementComponent>();
            verticalAxis = new AxisBinding(Keys.S, Keys.W);
            horizontalAxis = new AxisBinding(Keys.D, Keys.A);
            ActionBinding spawnBinding = new ActionBinding(EMouseButton.Left);

            verticalAxis.OnUpdate += Move;
            horizontalAxis.OnUpdate += Move;
            spawnBinding.OnTrigger += Spawn;

            InputManager.Manager.AddAxisBinding(verticalBindingName, verticalAxis);
            InputManager.Manager.AddAxisBinding(horizontalBindingName, horizontalAxis);

            InputManager.Manager.AddActionBinding(spawnBindingName, spawnBinding);

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
            target.transform.position = InputManager.Manager.MouseCursor + parent.transform.position - Statics.GetResolition(ViewManager.Instance.ScreenSize) / 2f;
        }

        private void Spawn()
        {

            lock(this)
                projectileToSpawn = true;
            // Core.GameManager.SpawnObject(projectile);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //target.transform.position = InputManager.Manager.MouseCursor + parent.transform.position - Graphics.ViewManager.Instance.ScreenSize / 2f;
            target.transform.position = InputManager.Manager.MouseCursorInWorldSpace;
            if(projectileToSpawn)
            {
                lock(this)
                {
                    Assets.Objects.AlienBullet projectile = new Assets.Objects.AlienBullet(new Core.Transform(Parent.transform));

                    Vector2 parentPosition = parent.transform.position;
                    Vector2 targetPosition = Input.InputManager.Manager.MouseCursorInWorldSpace;
                    Vector2 direction = targetPosition - parentPosition;
                    direction.Normalize();

                    projectile.GetComponent<Navigation.ProjectileMovementComponent>().Direction = direction;
                    projectile.GetComponent<Navigation.ProjectileMovementComponent>().Velocity = 800f;

                    projectile.Damage = new Gameplay.DamageInfo(parent, 10);

                    Core.GameManager.SpawnObject(projectile);
                    projectileToSpawn = false;
                }
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            AxisBinding horizontalBinding = InputManager.Manager.GetAxisBinding(horizontalBindingName);
            AxisBinding verticalBinding = InputManager.Manager.GetAxisBinding(verticalBindingName);

            horizontalAxis.OnUpdate -= Move;
            verticalAxis.OnUpdate -= Move;

            ActionBinding spawnBinding = InputManager.Manager.GetActionBinding(spawnBindingName);

            spawnBinding.OnTrigger -= Spawn;

            InputManager.Manager.RemoveBinding(spawnBindingName);
            InputManager.Manager.RemoveBinding(horizontalBindingName);
            InputManager.Manager.RemoveBinding(verticalBindingName);
        }
    }
}
