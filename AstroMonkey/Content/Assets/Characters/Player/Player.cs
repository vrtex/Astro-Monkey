using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Player: Core.GameObject
    {
        int side = 0;

        public Player(): this(new Core.Transform())
        {
        }
        public Player(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Player(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public Player(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        { 
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "player", new Rectangle(32, 32, 32, 32)));
            AddComponent(new Graphics.Animator(this));
            AddComponent(new Navigation.MovementComponent(this));
            AddComponent(new Input.InputCompoent(this));

            //dodawanie animacji
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32)},
                    166,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32),
                        new Rectangle(32, 0, 32, 32),
                        new Rectangle(0, 0, 32, 32),
                        new Rectangle(64, 0, 32, 32)},
                    166,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32)},
                    166,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32),
                        new Rectangle(32, 32, 32, 32)},
                    166,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32)},
                    166,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32),
                        new Rectangle(32, 64, 32, 32),
                        new Rectangle(0, 64, 32, 32),
                        new Rectangle(64, 64, 32, 32)},
                    166,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32)},
                    166,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32),
                        new Rectangle(32, 96, 32, 32)},
                    166,
                    true));
            GetComponent<Graphics.Animator>().SetAnimation("IdleDown");

        }

        public override void Update(GameTime gameTime)
        {
            foreach(var c in components)
                c.Update(gameTime);

            // move this mess somewhere else. Or don't I don't care
            Vector2 currVel = GetComponent<Navigation.MovementComponent>().CurrentVelocity;
            if(Util.Statics.IsNearlyEqual(currVel.Length(), 0, 0.001))
            {
                if(side == 0) GetComponent<Graphics.Animator>().SetAnimation("IdleUp");
                else if(side == 1) GetComponent<Graphics.Animator>().SetAnimation("IdleRight");
                else if(side == 2) GetComponent<Graphics.Animator>().SetAnimation("IdleDown");
                else if(side == 3) GetComponent<Graphics.Animator>().SetAnimation("IdleLeft");
            }
            else
            {
                double currentDirection = GetComponent<Navigation.MovementComponent>().CurrentDirection;
                currentDirection += Math.PI;
                if(currentDirection >= -Math.PI * 0.25 && currentDirection < Math.PI * 0.75)
                {
                    side = 0;
                    GetComponent<Graphics.Animator>().SetAnimation("WalkUp");
                }
                else if(currentDirection < Math.PI * 1.25)
                {
                    side = 1;
                    GetComponent<Graphics.Animator>().SetAnimation("WalkRight");
                } 
                else if(currentDirection < Math.PI * 1.75)
                {
                    side = 2;
                    GetComponent<Graphics.Animator>().SetAnimation("WalkDown");
                }
                else
                {
                    side = 3;
                    GetComponent<Graphics.Animator>().SetAnimation("WalkLeft");
                }
            }
        }
    }
}
