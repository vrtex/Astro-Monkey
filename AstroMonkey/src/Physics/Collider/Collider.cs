using System.Collections.Generic;

namespace AstroMonkey.Physics.Collider
{
    public abstract class Collider
    {
        private CollisionChanell collisionChanell = new CollisionChanell();
        private Dictionary<CollisionChanell, ReactType> reaction;

        Collider(CollisionChanell collisionChanell = CollisionChanell.Enemy)
        {
            
        }
    }
}