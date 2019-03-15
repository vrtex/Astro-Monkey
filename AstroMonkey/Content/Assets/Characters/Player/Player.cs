using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets
{
    class Player: Core.GameObject
    {
        public Player()
        {
            transform.position = new Vector2(50, 90);
            AddComponent(new Graphics.Sprite(this, "player", new Rectangle(32, 32, 32, 32)));
            AddComponent(new Graphics.Animator(this));
            AddComponent(new Navigation.MovementComponent(this));
            AddComponent(new Input.InputCompoent(this));

            //Added animations
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32),
                        new Rectangle(32, 0, 32, 32),
                        new Rectangle(0, 0, 32, 32),
                        new Rectangle(64, 0, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32),
                        new Rectangle(32, 32, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32),
                        new Rectangle(32, 64, 32, 32),
                        new Rectangle(0, 64, 32, 32),
                        new Rectangle(64, 64, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32),
                        new Rectangle(32, 96, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().SetAnimation("IdleDown");

            Graphics.AnimationManager.Instance.AddAnimator(GetComponent<Graphics.Animator>());
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var c in components)
                c.Update(gameTime);

            // move this mess somewhere else. Or don't I don't care
            Vector2 currVel = GetComponent<Navigation.MovementComponent>().CurrentVelocity;
            if(Util.Statics.IsNearlyEqual(currVel.Length(), 0, 0.001))
                GetComponent<Graphics.Animator>().SetAnimation("IdleDown");
            else
            {
                double currentDirection = GetComponent<Navigation.MovementComponent>().CurrentDirection;
                currentDirection += Math.PI;
                if(currentDirection >= -Math.PI * 0.25 && currentDirection < Math.PI * 0.75)
                    GetComponent<Graphics.Animator>().SetAnimation("WalkUp");
                else if(currentDirection < Math.PI * 1.25)
                    GetComponent<Graphics.Animator>().SetAnimation("WalkRight");
                else if(currentDirection < Math.PI * 1.75)
                    GetComponent<Graphics.Animator>().SetAnimation("WalkDown");
                else
                    GetComponent<Graphics.Animator>().SetAnimation("WalkLeft");
            }
        }
    }
}
