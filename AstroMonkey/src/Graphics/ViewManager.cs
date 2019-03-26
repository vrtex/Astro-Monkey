using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class ViewManager
    {
        public static ViewManager Instance { get; private set; } = new ViewManager();
        public List<Core.GameObject> sprites = new List<Core.GameObject>();
        public List<Core.GameObject> floor = new List<Core.GameObject>();
        public Core.Transform playerTransform = null;
        public Vector2 ScreenSize;

        private Util.ViewComparable vc = new Util.ViewComparable();

        private ViewManager()
        {

        }

        public void AddSprite(Core.GameObject sprite)
        {
            if(sprite is Assets.Objects.Floor) floor.Add(sprite);
            else sprites.Add(sprite);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred,
                            BlendState.AlphaBlend,
                            SamplerState.PointClamp, null, null, null,
                            Matrix.CreateTranslation(
                                -playerTransform.position.X + spriteBatch.GraphicsDevice.Viewport.Width / 2,
                                -playerTransform.position.Y + spriteBatch.GraphicsDevice.Viewport.Height / 2, 0));

            foreach(Core.GameObject s in floor)
            {
                Sprite sprite = s.GetComponent<Graphics.Sprite>();
                spriteBatch.Draw(
                    sprite.image,
                    new Vector2(
                        s.transform.position.X,
                        s.transform.position.Y),
                    null,
                    sprite.rect[0],
                    new Vector2(
                        sprite.rect[0].Width / 2,
                        sprite.rect[0].Height / 2),
                    s.transform.rotation,
                    s.transform.scale);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred,
                            BlendState.AlphaBlend, 
                            SamplerState.PointClamp, null, null, null,
                            Matrix.CreateTranslation(
                                -playerTransform.position.X + spriteBatch.GraphicsDevice.Viewport.Width / 2,
                                -playerTransform.position.Y + spriteBatch.GraphicsDevice.Viewport.Height / 2, 0));

            sprites.Sort(vc);

            foreach(Core.GameObject s in sprites)
            {
                Sprite sprite = s.GetComponent<Graphics.Sprite>();
                for(int i = 0; i < sprite.rect.Count; ++i)
                {
                    spriteBatch.Draw(
                        sprite.image,
                        new Vector2(
                            s.transform.position.X,
                            s.transform.position.Y - i * s.transform.scale.Y),
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
