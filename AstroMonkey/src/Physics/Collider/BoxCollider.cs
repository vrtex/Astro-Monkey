using System;
using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public class BoxCollider : Collider
    {
        public float width { get; set; }
        public float height { get; set; }

        public BoxCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 relativePosition = new Vector2(), float width = 1, float height = 1) : base(gameObject, collisionChanell, relativePosition)
        {
            float epsilon = (float)Math.PI / 8;
            float rotation = Parent.transform.rotation;

            if (Math.Abs(rotation - Math.PI / 2) < epsilon || Math.Abs(rotation + Math.PI / 2) < epsilon)
            {
                this.height = width * scale;
                this.width = height * scale;
            }
            else
            {
                this.width = width * scale;
                this.height = height * scale;
            }
        }
    }
}