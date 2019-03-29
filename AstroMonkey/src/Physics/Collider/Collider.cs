using System.Collections.Generic;
using System.Diagnostics;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public abstract class Collider : Component
    {
        private CollisionChanell collisionChanell;
        private Dictionary<CollisionChanell, ReactType> reaction;
        private Vector2 relativePosition;
        protected float scale;
        private bool temp;

        public Collider(
            GameObject gameObject,
            CollisionChanell collisionChanell = CollisionChanell.Object,
            Vector2 relativePosition = new Vector2(),
            bool temp = false)
            : base(gameObject)
        {
            this.collisionChanell = collisionChanell;
            this.relativePosition = relativePosition;
            this.temp = temp;
            scale = SceneManager.scale;

            SetReactions();

            if(!temp)
                PhysicsManager.AddCollider(this);
        }

        ~Collider()
        {
            if (!temp)
                PhysicsManager.RemoveCollider(this);
        }

        public CollisionChanell GetCollisionChanell()
        {
            return collisionChanell;
        }

        
        public void SetCollisionChanell(CollisionChanell collisionChanell)
        {
            this.collisionChanell = collisionChanell;
            SetReactions();
        }


        public Vector2 GetRelativePosition()
        {
            return relativePosition;
        }

        public void SetRelativePosition(Vector2 relativePosition)
        {
            this.relativePosition = relativePosition;
        }


        public Vector2 GetPosition()
        {
            return Vector2.Add(Parent.transform.position, relativePosition);
        }

        public void SetPosition(Vector2 position)
        {
            //Debug.WriteLine("POS" + position);
            //Debug.WriteLine("REL" + relativePosition);
            //Debug.WriteLine("SUB" + Vector2.Subtract(position, relativePosition));
            Parent.transform.position = Vector2.Subtract(position, relativePosition);
        }

        /// <summary>
        /// Zwraca typ reakcji na dany kanał kolizji.
        /// </summary>
        public ReactType GetReaction(CollisionChanell collisionChanell)
        {
            return reaction[collisionChanell];
        }

        private void SetReactions()
        {
            reaction = new Dictionary<CollisionChanell, ReactType>();

            switch (collisionChanell)
            {
                case CollisionChanell.Player:
                    reaction.Add(CollisionChanell.Player, ReactType.Block);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Item, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Overlap);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Enemy:
                    reaction.Add(CollisionChanell.Player, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Block);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Item:
                    reaction.Add(CollisionChanell.Player, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Block);
                    break;
                case CollisionChanell.Object:
                    reaction.Add(CollisionChanell.Player, ReactType.Block);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Block);
                    reaction.Add(CollisionChanell.Item, ReactType.Block);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Hitbox:
                    reaction.Add(CollisionChanell.Player, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Bullets:
                    reaction.Add(CollisionChanell.Player, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Block);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.InteractPlayer:
                    reaction.Add(CollisionChanell.Player, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.InteractBullet:
                    reaction.Add(CollisionChanell.Player, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Item, ReactType.Block);
                    reaction.Add(CollisionChanell.Object, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                default:
                    reaction.Add(CollisionChanell.Player, ReactType.Block);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Block);
                    reaction.Add(CollisionChanell.Item, ReactType.Block);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Block);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
            }
        }
    }
}