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
    }
}