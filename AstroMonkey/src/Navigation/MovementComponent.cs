using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using AstroMonkey.Core;

namespace AstroMonkey.Navigation
{
    class MovementComponent: Core.Component
    {
        public Vector2 CurrentVelocity { get; private set; } = new Vector2();
        public float CurrentDirection { get; private set; }
        public GameObject CurrentFocus { get; set; }

        public float Speed { get; set; } = 190.0f;

        public MovementComponent(Core.GameObject parent): base(parent)
        {

        }

        public void AddMovementInput(Vector2 velocity)
        {
            CurrentVelocity = velocity;
            if(CurrentFocus == null)
                CurrentDirection = (float)Math.Atan2(CurrentVelocity.Y, CurrentVelocity.X);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 previousPosition = parent.transform.position;
            parent.transform.position += CurrentVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
            parent.transform.rotation = GetNextRotation(previousPosition);
            CurrentDirection = parent.transform.rotation;
        }

        private float GetNextRotation(Vector2 previousPosition)
        {
            Vector2 lookDirection = new Vector2();
            if(CurrentFocus != null)
            {
                lookDirection = parent.transform.position - CurrentFocus.transform.position;
            }
            else
            {
                if(previousPosition == parent.transform.position)
                    return parent.transform.rotation;
                lookDirection = parent.transform.position - previousPosition;
            }
            lookDirection *= -1;
            return (float)(Math.PI * 0.5 + Math.Atan2(lookDirection.Y, lookDirection.X));
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              