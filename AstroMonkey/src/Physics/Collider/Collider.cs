using System.Collections.Generic;
using AstroMonkey.Core;

namespace AstroMonkey.Physics.Collider
{
    public abstract class Collider : Component
    {
        private CollisionChanell collisionChanell;
        private Dictionary<CollisionChanell, ReactType> reaction;

        public Collider(GameObject gameObject, CollisionChanell collisionChanell, Dictionary<CollisionChanell, ReactType> reaction) : base(gameObject)
        {
            this.collisionChanell = collisionChanell;
            this.reaction = reaction;
        }
    }
}