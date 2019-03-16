using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AstroMonkey.Graphics
{
    class ViewManager
    {
        public static ViewManager Instance { get; private set; } = new ViewManager();
        public static List<Core.GameObject> sprites = new List<Core.GameObject>();
        private CameraComponent currentCamera;

        static ViewManager()
        {

        }

        public void AddSprite(Core.GameObject sprite)
        {
            sprites.Add(sprite);
        }

        public void SetCamera(CameraComponent camera)
        {
            currentCamera = camera;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            Matrix position = currentCamera == null ? Matrix.Identity : currentCamera.Transform;

            // spriteBatch.Begin(transformMatrix: position);
            spriteBatch.Begin();
            foreach(Core.GameObject s in sprites)
            {

                Sprite sprite = s.GetComponent<Graphics.Sprite>();
                // spriteBatch.Draw(sprite.image, destinationRectangle: sprite.rect);
                spriteBatch.Draw(
                    sprite.image,
                    new Vector2(
                        s.transform.position.X,
                        s.transform.position.Y),
                    null,
                    sprite.rect,
                    new Vector2(
                        sprite.rect.Width / 2,
                        sprite.rect.Height / 2),
                    s.transform.rotation,
                    s.transform.scale);
            }

            spriteBatch.End();
        }
        
    }
}
