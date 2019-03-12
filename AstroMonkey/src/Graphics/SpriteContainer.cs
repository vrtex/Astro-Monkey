using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    public sealed class SpriteContainer
    {
        private static  SpriteContainer             _instance = new SpriteContainer();
        public  Dictionary<string, Texture2D>       images = new Dictionary<string, Texture2D>();

        public static SpriteContainer Instance
        {
            get
            {
                return _instance;
            }
        }

        static SpriteContainer()
        {   
        }

        public void LoadTextures(Game game)
        {
            images.Add("player", game.Content.Load<Texture2D>(@"Characters/Player/PlayerConture"));
            images.Add("enemy", game.Content.Load<Texture2D>(@"Characters/Enemys/Klucha"));
            images.Add("floor", game.Content.Load<Texture2D>(@"Map/Floor/PlatformFloor"));
            images.Add("wall", game.Content.Load<Texture2D>(@"Map/Objects/Wall"));
            images.Add("item", game.Content.Load<Texture2D>(@"Items/Banana"));
        }

        public Texture2D GetImage(string name)
        {
            Texture2D tex = null;
            images.TryGetValue(name, out tex);
            return tex;
        }
    }
}
