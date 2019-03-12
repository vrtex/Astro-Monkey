using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public class CircleCollider : Collider
    {
        private float radius;


        public CircleCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 position = new Vector2(), float radius = 1)
            : base(gameObject, collisionChanell, position)
        {
            this.radius = radius;
        }
    }
}