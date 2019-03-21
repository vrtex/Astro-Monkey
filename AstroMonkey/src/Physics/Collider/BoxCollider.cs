﻿using System.Collections.Generic;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics.Collider
{
    public class BoxCollider : Collider
    {
        public float width { get; set; }
        public float height { get; set; }

        public BoxCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 position = new Vector2(), float width = 1, float height = 1) : base(gameObject, collisionChanell, position)
        {
            this.width = width;
            this.height = height;
        }
    }
}