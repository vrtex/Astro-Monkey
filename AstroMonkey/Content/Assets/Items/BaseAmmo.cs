using AstroMonkey.Physics.Collider;
using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Objects
{
    class BaseAmmo : GameObject
    {
        protected int height = 16;
        protected int size = 16;

        private Collider collider;
        protected Type projectileType;
        protected int count = 1;

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


        }
    }
}
