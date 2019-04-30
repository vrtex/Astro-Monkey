using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using AstroMonkey.Util;

namespace AstroMonkey.Input
{
    class AxisBinding
    {
        public delegate void AxisEvent(float newValue);
        public event AxisEvent OnUpdate;


        public float speed { get; set; } = 0.1f;
        public float gravity { get; set; } = 0.1f;

        public float Value { get; private set; }
        public Keys PositiveKey { get; private set; }
        public Keys NegativeKey { get; private set; }

        public AxisBinding(Keys positiveKey, Keys negativeKey)
        {
            this.PositiveKey = positiveKey;
            this.NegativeKey = negativeKey;
        }

        public void Update()
        {
            float change = 0.0f;
            if(InputManager.Manager.IsKeyPressed(PositiveKey))
                change += 1;
            if(InputManager.Manager.IsKeyPressed(NegativeKey))
                change -= 1;

            change *= speed;
            if(Statics.IsNearlyEqual(change, 0.0f) && !Statics.IsNearlyEqual(Value, 0.0f))
                change = gravity * Math.Sign(Value) * -1;

            float newValue = MathHelper.Clamp(Value + change, -1f, 1f);
            if(Statics.IsNearlyEqual(Value, newValue, speed / 2))
                return;

            Value = newValue;
            if(Statics.IsNearlyEqual(Value, 0.0f))
                Value = 0.0f;
            OnUpdate(Value);
        }
    }
}
