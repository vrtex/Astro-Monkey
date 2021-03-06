﻿using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using AstroMonkey.Graphics;
using AstroMonkey.Util;
using System.Collections.Generic;

namespace AstroMonkey.Input
{
    class InputComponent : Core.Component
    {
        Navigation.MovementComponent moveComp;

        private readonly AxisBinding verticalAxis;
        private readonly AxisBinding horizontalAxis;
        private readonly ActionBinding shootBinding;
        private readonly ActionBinding interactBinding;
        private readonly ActionBinding scrollUpBinding;
        private readonly ActionBinding scrollDownBinding;
        private readonly ActionBinding reloadBinding;

        private readonly ActionBinding pistolSwapBinding;
        private readonly ActionBinding riffleSwapBinding;
        private readonly ActionBinding launcherSwapBinding;
        private readonly ActionBinding shotgunSwapBinding;

        private Core.GameObject target = new Core.GameObject();
        private bool projectileToSpawn = false;
		private Gameplay.Gun gun;

        private readonly string pistolSwapName = "pistol swap";
        private readonly string riffleSwapName = "riffle swap";
        private readonly string launcherSwapName = "launcher swap";
        private readonly string shotgunSwapName = "shotgun swap";

        private readonly string verticalBindingName = "move up";
        private readonly string horizontalBindingName = "move right";
        private readonly string shootBindingName = "shoot";
        private readonly string interactBindName = "interact";
        private readonly string scrollUpBindName = "weapon up";
        private readonly string scrollDownBindName = "weapon down";
        private readonly string reloadBindName = "reload";

        public InputComponent(Core.GameObject parent) : base(parent)
        {
            moveComp = parent.GetComponent<Navigation.MovementComponent>();
			gun = Parent.GetComponent<Gameplay.Gun>();

            verticalAxis = new AxisBinding(Keys.S, Keys.W);
            horizontalAxis = new AxisBinding(Keys.D, Keys.A);
            shootBinding = new ActionBinding(EMouseButton.Left);
            interactBinding = new ActionBinding(Keys.E);
            scrollUpBinding = new ActionBinding(EMouseButton.WheelUp);
            scrollDownBinding = new ActionBinding(EMouseButton.WheelDown);
            reloadBinding = new ActionBinding(Keys.R);

            pistolSwapBinding = new ActionBinding(Keys.D1);
            riffleSwapBinding = new ActionBinding(Keys.D2);
            shotgunSwapBinding = new ActionBinding(Keys.D3);
            launcherSwapBinding = new ActionBinding(Keys.D4);

            AttachBindings();

            InputManager.Manager.AddAxisBinding(verticalBindingName, verticalAxis);
            InputManager.Manager.AddAxisBinding(horizontalBindingName, horizontalAxis);

            InputManager.Manager.AddActionBinding(shootBindingName, shootBinding);
            InputManager.Manager.AddActionBinding(interactBindName, interactBinding);

            InputManager.Manager.AddActionBinding(scrollDownBindName, scrollDownBinding);
            InputManager.Manager.AddActionBinding(scrollUpBindName, scrollUpBinding);
            InputManager.Manager.AddActionBinding(reloadBindName, reloadBinding);

            InputManager.Manager.AddActionBinding(pistolSwapName, pistolSwapBinding);
            InputManager.Manager.AddActionBinding(riffleSwapName, riffleSwapBinding);
            InputManager.Manager.AddActionBinding(launcherSwapName, launcherSwapBinding);
            InputManager.Manager.AddActionBinding(shotgunSwapName, shotgunSwapBinding);

            moveComp.CurrentFocus = target;
            InputManager.Manager.OnMouseMove += MoveTarget;
        }

        public void AttachBindings()
        {
            verticalAxis.OnUpdate += Move;
            horizontalAxis.OnUpdate += Move;
            shootBinding.OnTrigger += StartShooting;
            shootBinding.OnRelease += StopShooting;
            interactBinding.OnTrigger += Interact;
            scrollDownBinding.OnTrigger += ChangeAmmoDown;
            scrollUpBinding.OnTrigger += ChangeAmmoUp;
            reloadBinding.OnTrigger += Reload;

            pistolSwapBinding.OnTrigger += SwapToPistol;
            riffleSwapBinding.OnTrigger += SwapToRiffle;
            shotgunSwapBinding.OnTrigger += SwapToShotgun;
            launcherSwapBinding.OnTrigger += SwapToLauncher;
        }

        private void SwapToLauncher()
        {
            gun.ChangeAmmo(typeof(Assets.Objects.Rocket));
        }

        private void SwapToShotgun()
        {
            gun.ChangeAmmo(typeof(Assets.Objects.ShotgunProjectile));
        }

        private void SwapToRiffle()
        {
            gun.ChangeAmmo(typeof(Assets.Objects.RifleBullet));
        }

        private void SwapToPistol()
        {
            gun.ChangeAmmo(typeof(Assets.Objects.PistolBullet));
        }

        public void DetachBindings()
        {
            verticalAxis.OnUpdate -= Move;
            horizontalAxis.OnUpdate -= Move;
            shootBinding.OnTrigger -= StartShooting;
            shootBinding.OnRelease -= StopShooting;
            interactBinding.OnTrigger -= Interact;
            scrollDownBinding.OnTrigger -= ChangeAmmoDown;
            scrollUpBinding.OnTrigger -= ChangeAmmoUp;
            reloadBinding.OnTrigger -= Reload;

            pistolSwapBinding.OnTrigger -= SwapToPistol;
        }

        private void StopShooting()
        {
            gun.StopShooting();
        }

        private void TogglePause()
        {
            throw new System.NotImplementedException();
        }

        private void Reload()
        {
            gun.Reload();
        }

        private void ChangeAmmoDown()
        {
            gun.ChangeAmmo(false);
        }

        private void ChangeAmmoUp()
        {
            gun.ChangeAmmo(true);
        }

        private void Interact()
        {
            List<Core.GameObject> inRange = Parent.GetComponent<Physics.Collider.Collider>().GetOverlapingObjects();

            foreach(var colliding in inRange)
            {
                Gameplay.InteractComponent interactComponent = colliding.GetComponent<Gameplay.InteractComponent>();
                if(interactComponent == null)
                    continue;

                interactComponent.Interact(Parent);
            }
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

        private void StartShooting()
        {
            gun.Shoot(InputManager.Manager.MouseCursorInWorldSpace);
            //lock(this)
            //    projectileToSpawn = true;
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
					Vector2 targetPosition = Input.InputManager.Manager.MouseCursorInWorldSpace;
					gun.Shoot(targetPosition);
                    projectileToSpawn = false;
                }
            }
        }

        public override void Destroy()
        {

            // AxisBinding horizontalBinding = InputManager.Manager.GetAxisBinding(horizontalBindingName);
            // AxisBinding verticalBinding = InputManager.Manager.GetAxisBinding(verticalBindingName);

            DetachBindings();

            ActionBinding spawnBinding = InputManager.Manager.GetActionBinding(shootBindingName);
            if(spawnBinding != null)
                spawnBinding.OnTrigger -= StartShooting;

            InputManager.Manager.RemoveBinding(shootBindingName);
            InputManager.Manager.RemoveBinding(horizontalBindingName);
            InputManager.Manager.RemoveBinding(verticalBindingName);
            base.Destroy();
        }
    }
}
