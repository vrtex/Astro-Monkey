using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Physics.Collider
{
    public abstract class Collider : Component
    {
        private CollisionChanell collisionChanell;
        private Dictionary<CollisionChanell, ReactType> reaction;
        private Vector2 relativePosition;
        protected float scale;
		
        private bool temp;

        public delegate void ColliderEvent(Collider thisCollider, Collider otherCollider);
        public event ColliderEvent OnBeginOverlap;
        public event ColliderEvent OnEndOverlap;
        public event ColliderEvent OnBlockingCollision;

        public List<Collider> collisons = new List<Collider>();

		public bool isActive = true;

		public Collider(
            GameObject gameObject,
            CollisionChanell collisionChanell = CollisionChanell.Object,
            Vector2 relativePosition = new Vector2(),
            bool temp = false)
            : base(gameObject)
        {
            scale = SceneManager.scale;
            this.relativePosition = Vector2.Multiply(relativePosition, new Vector2(scale, scale));
            SetRotation();

            this.collisionChanell = collisionChanell;
            SetReactions();
            
            this.temp = temp;
            if(!temp)
                PhysicsManager.AddCollider(this);
        }

        public override void Destroy()
        {
            if (!temp)
                PhysicsManager.RemoveCollider(this);
            base.Destroy();
        }

        public void OnBlockDetected(Collider other)
        {
            OnBlockingCollision?.Invoke(this, other);
        }

        public void RunOnBeginOverlap(Collider c)
        {
            if(collisons.Contains(c))
                return;
            collisons.Add(c);
            OnBeginOverlap?.Invoke(this, c);
        }

        public void RunOnEndOverlap(Collider c)
        {
            bool deleted = collisons.Remove(c);
            if(!deleted)
                return;
            OnEndOverlap?.Invoke(this, c);
        }

        /// <summary>
        /// Rysuj wszystkie collidery
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void DrawBorder(SpriteBatch spriteBatch);

        
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
            Parent.transform.position = Vector2.Subtract(position, relativePosition);
        }

        /// <summary>
        /// Zwraca typ reakcji na dany kanał kolizji.
        /// </summary>
        public ReactType GetReaction(CollisionChanell collisionChanell)
        {
            return reaction[collisionChanell];
        }

        public List<GameObject> GetOverlapingObjects()
        {
            List<GameObject> toReturn = new List<GameObject>();

            foreach(var collider in collisons)
                toReturn.Add(collider.Parent);

            return toReturn.Distinct().ToList();
        }

        private void SetRotation()
        {
            float epsilon = (float)Math.PI / 8;
            float rotation = Parent.transform.rotation;
            //if(rotation > (float)(Math.PI))
            //{
            //    rotation -= (float)(Math.PI);
            //}
            
            if (Math.Abs(rotation - 0) < epsilon) // FACE UP
            {

            }
            else if (Math.Abs(rotation - Math.PI / 2) < epsilon) // FACE LEFT
            {
                float temp = relativePosition.Y;
                relativePosition.Y = relativePosition.X;
                relativePosition.X = -temp;
            }
            else if(Math.Abs(rotation - Math.PI) < epsilon) // FACE DOWN
            {
                relativePosition.X = -relativePosition.X;
                relativePosition.Y = -relativePosition.Y;
            }
            else //FACE RIGHT
            {
                float temp = relativePosition.X;
                relativePosition.X = relativePosition.Y;
                relativePosition.Y = -temp;
            }
        }

        public void SetReaction(Dictionary<CollisionChanell, ReactType> reaction)
        {
            this.reaction = reaction;
        }

		public void SetReaction(CollisionChanell channel, ReactType reaction)
		{
			this.reaction[channel] = reaction;
		}

		public Dictionary<CollisionChanell, ReactType> GetReaction()
        {
            return reaction;
        }

        private void SetReactions()
        {
            reaction = new Dictionary<CollisionChanell, ReactType>();

            switch (collisionChanell)
            {
                case CollisionChanell.Player:
                    reaction.Add(CollisionChanell.Player, ReactType.Block);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Block);
                    reaction.Add(CollisionChanell.Item, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Overlap);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Overlap);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Enemy:
                    reaction.Add(CollisionChanell.Player, ReactType.Block);
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
                    reaction.Add(CollisionChanell.Bullets, ReactType.Overlap);
                    reaction.Add(CollisionChanell.InteractPlayer, ReactType.Ignore);
                    reaction.Add(CollisionChanell.InteractBullet, ReactType.Ignore);
                    break;
                case CollisionChanell.Bullets:
                    reaction.Add(CollisionChanell.Player, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Enemy, ReactType.Overlap);
                    reaction.Add(CollisionChanell.Item, ReactType.Ignore);
                    reaction.Add(CollisionChanell.Object, ReactType.Block);
                    reaction.Add(CollisionChanell.Hitbox, ReactType.Block);
                    reaction.Add(CollisionChanell.Bullets, ReactType.Ignore);
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