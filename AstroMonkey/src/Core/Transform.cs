using Microsoft.Xna.Framework;

namespace AstroMonkey.Core
{
    public class Transform
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;

        public Transform(Vector2 position, Vector2 scale, float rotation = 0)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }

        public Transform(): this(Vector2.Zero, Vector2.Zero, 0f)
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