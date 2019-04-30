using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Core
{
    public class Transform
    {
        public Vector2 position;
        public Vector2 scale;
        private float _rotation;
        public float rotation {
            get => _rotation;
            set
            {

                _rotation = value % (float)(Math.PI * 2);
                if(_rotation < 0)
                    _rotation = (float)(2 * Math.PI) + _rotation;
            }
        }

        public Transform(Vector2 position, Vector2 scale, float rotation = 0)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }

        public Transform(): this(Vector2.Zero, Vector2.One, 0f)
        {
        }

        public Transform(Transform transform): this(transform.position, transform.scale, transform.rotation)
        {
        }

        public override string ToString()
        {
            return "Transform: " + position + " " + rotation + " " + scale;
        }
    }
}