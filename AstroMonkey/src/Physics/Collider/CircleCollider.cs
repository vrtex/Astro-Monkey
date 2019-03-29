using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public class CircleCollider : Collider
    {
        public float radius { get; set; }

        public CircleCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 relativePosition = new Vector2(), float radius = 1)
            : base(gameObject, collisionChanell, relativePosition)
        {
            this.radius = radius;
        }
    }
}