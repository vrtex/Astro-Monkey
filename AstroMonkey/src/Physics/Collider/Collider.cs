using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public abstract class Collider : Component
    {
        private CollisionChanell collisionChanell;
        private Dictionary<CollisionChanell, ReactType> reaction;
        private Vector2 position;

        public Collider(
            GameObject gameObject,
            CollisionChanell collisionChanell = CollisionChanell.Object,
            Vector2 position = new Vector2())
            : base(gameObject)
        {
            this.collisionChanell = collisionChanell;
            this.position = position;

            setReactions();


        }

        private void setReactions()
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