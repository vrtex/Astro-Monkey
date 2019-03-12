using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public class CircleCollider : Collider
    {
        private Vector2 position;
        private float radius;

        public CircleCollider(GameObject gameObject, CollisionChanell collisionChanell, Dictionary<CollisionChanell, ReactType> reaction, Vector2 position, float radius)
            : base(gameObject, collisionChanell, reaction)
        {
            this.position = position;
            this.radius = radius;
        }
    }
}