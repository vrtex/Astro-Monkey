using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Graphics
{
    class CameraComponent : Core.Component
    {
        public Matrix Transform { get; private set; } = new Matrix();
        public CameraComponent(GameObject parent) : base(parent)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Transform = Matrix.CreateTranslation(
                parent.transform.position.X,
                parent.transform.position.Y,
                0);
        }
    }
}
