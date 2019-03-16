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

        static ViewManager()
        {

        }

        public void AddSprite(Core.GameObject sprite)
        {
            sprites.Add(sprite);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            //Debug.WriteLine(sprites.Count);
            foreach(Core.GameObject s in sprites)
            {
                Graphics.Sprite sprite = s.GetComponent<Graphics.Sprite>();
                spriteBatch.Draw(sprite.image,
                new Vector2(
                    s.transform.position.X - sprite.rect.Width / 2,
                    s.transform.position.Y - sprite.rect.Height / 2),
                    sprite.rect, Color.Wheat);
            }
        }
        
    }
}
