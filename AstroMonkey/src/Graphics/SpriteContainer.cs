using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    public sealed class SpriteContainer
    {
        public Dictionary<string, Texture2D>       images = new Dictionary<string, Texture2D>();

        public static SpriteContainer Instance { get; private set; } = new SpriteContainer();

        static SpriteContainer()
        {   
        }

        public void LoadTextures(Game game)
        {
            images.Add("mark", game.Content.Load<Texture2D>(@"gfx/UI/HUD/mark"));

            images.Add("player", game.Content.Load<Texture2D>(@"gfx/Characters/Player/PlayerConture"));
            images.Add("monkey", game.Content.Load<Texture2D>(@"gfx/Characters/Player/monkey"));
            images.Add("enemy", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Klucha"));
            images.Add("alien01", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/alien01"));
            images.Add("floor", game.Content.Load<Texture2D>(@"gfx/Map/Floor/PlatformFloor"));
            images.Add("wall", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall"));
            images.Add("corner", game.Content.Load<Texture2D>(@"gfx/Map/Objects/corner"));
            images.Add("item", game.Content.Load<Texture2D>(@"gfx/Items/Banana"));
            images.Add("computer", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/Computer"));
        }

        public Texture2D GetImage(string name)
        {
            Texture2D tex = null;
            images.TryGetValue(name, out tex);
            return tex;
        }
    }
}
