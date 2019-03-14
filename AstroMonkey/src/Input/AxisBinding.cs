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


        public float speed { get; set; } = 0.01f;
        public float gravity { get; set; } = 0.01f;

        public float Value { get; private set; }
        public Keys positiveKey { get; private set; }
        public Keys negativeKey { get; private set; }

        public AxisBinding(Keys positiveKey, Keys negativeKey)
        {
            this.positiveKey = positiveKey;
            this.negativeKey = negativeKey;
        }

        public void Update()
        {
            float change = 0.0f;
            if(InputManager.manager.IsKeyPressed(positiveKey))
                change += 1;
            if(InputManager.manager.IsKeyPressed(negativeKey))
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
