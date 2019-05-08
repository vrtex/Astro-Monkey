using AstroMonkey.Physics.Collider;
using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class BaseAmmo : GameObject
    {
        protected int height = 16;
        protected int size = 16;

        private Collider collider;
        public Type ProjectileType { get; protected set; }
        public int Count { get; private set; } = 1;

        public BaseAmmo(Core.Transform transform) : base(transform)
        {

        }

        protected virtual void Load(Core.Transform transform)
        {
            collider = AddComponent(new CircleCollider(this, CollisionChanell.Item, Vector2.Zero, size / 2));
            collider.OnBeginOverlap += CheckOverlap;
        }

        private void CheckOverlap(Collider thisCollider, Collider otherCollider)
        {
            GameObject otherObject = otherCollider.Parent;

            if(!(otherObject is Player))
                return;

            Gun playerGun = otherObject.GetComponent<Gun>();

            if(playerGun == null)
                throw new ApplicationException("Monkey dosn't have a gun, big boo-boo");

            bool acctepted = playerGun.RestoreAmmo(this);
            if(acctepted)
                Destroy();

        }
    }
}
