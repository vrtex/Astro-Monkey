using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Navigation
{
    class MovementComponent: Core.Component
    {
        public Vector2 CurrentVelocity { get; private set; } = new Vector2();
        public float CurrentDirection { get; private set; }


        public float Speed { get; set; } = 100.0f;

        public MovementComponent(Core.GameObject parent): base(parent)
        {

        }

        public void AddMovementInput(Vector2 velocity)
        {
            CurrentVelocity = velocity;
            CurrentDirection = (float)Math.Atan2(CurrentVelocity.Y, CurrentVelocity.X);
        }

        public override void Update(GameTime gameTime)
        {
            parent.transform.position += CurrentVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              