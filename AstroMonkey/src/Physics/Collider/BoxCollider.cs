using System.Collections.Generic;
using AstroMonkey.Core;

namespace AstroMonkey.Physics.Collider
{
    public class BoxCollider : Collider
    {
        public BoxCollider(GameObject gameObject, CollisionChanell collisionChanell, Dictionary<CollisionChanell, ReactType> reaction) : base(gameObject, collisionChanell, reaction)
        {
        }
    }
}