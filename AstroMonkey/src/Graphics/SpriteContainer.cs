using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class SpriteContainer
    {
        public  Dictionary<string, Texture2D>       images = new Dictionary<string, Texture2D>();

        public SpriteContainer()
        {
            LoadTextures();
        }

        private void LoadTextures()
        {

        }
    }
}
