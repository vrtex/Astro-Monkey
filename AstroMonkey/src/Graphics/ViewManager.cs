using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace AstroMonkey.Graphics
{
    class ViewManager
    {
        public static ViewManager Instance { get; private set; } = new ViewManager();
        public static List<Core.GameObject> sprites = new List<Core.GameObject>();
        public static Core.Transform playerTransform = null;

        private ViewManager()
        {

        }

        public void AddSprite(Core.GameObject sprite)
        {
            sprites.Add(sprite);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred,
                            BlendState.AlphaBlend, 
                            SamplerState.PointClamp, null, null, null,
                            Matrix.CreateTranslation(
                                -Graphics.ViewManager.playerTransform.position.X + spriteBatch.GraphicsDevice.Viewport.Width / 2,
                                -Graphics.ViewManager.playerTransform.position.Y + spriteBatch.GraphicsDevice.Viewport.Height / 2, 0));
            //Debug.WriteLine(sprites.Count);

            foreach(Core.GameObject s in sprites)
            {
                Graphics.Sprite sprite = s.GetComponent<Graphics.Sprite>();
                for(int i = 0; i < sprite.rect.Count; ++i)
                {
                    spriteBatch.Draw(
                    sprite.image,
                    new Vector2(
                        s.transform.position.X,
                        s.transform.position.Y - i),
                    null,
                    sprite.rect[i],
                    new Vector2(
                        sprite.rect[i].Width / 2,
                        sprite.rect[i].Height / 2),
                    s.transform.rotation,
                    s.transform.scale);
                }
            }
            spriteBatch.End();
        }
        
    }
}
