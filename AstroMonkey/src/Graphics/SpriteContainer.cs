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
            //interfejs
            images.Add("mark", game.Content.Load<Texture2D>(@"gfx/UI/HUD/mark"));

            //efekty
            images.Add("poop", game.Content.Load<Texture2D>(@"gfx/Projectiles/Poop")); 
            images.Add("rocket", game.Content.Load<Texture2D>(@"gfx/Projectiles/Rocket"));
            images.Add("bulletHit", game.Content.Load<Texture2D>(@"gfx/Projectiles/BulletHit"));
            images.Add("alienBullet", game.Content.Load<Texture2D>(@"gfx/Projectiles/AlienBullet"));

            //postacie
            images.Add("monkey", game.Content.Load<Texture2D>(@"gfx/Characters/Player/monkey"));
            images.Add("alien01", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/alien01"));

            //otoczenie
            images.Add("floor", game.Content.Load<Texture2D>(@"gfx/Map/Floor/PlatformFloor"));
            images.Add("wall", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall"));
            images.Add("corner", game.Content.Load<Texture2D>(@"gfx/Map/Objects/corner"));
            images.Add("computer", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/Computer"));

            //przedmioty
            images.Add("banana", game.Content.Load<Texture2D>(@"gfx/Items/Banana"));
            images.Add("nut", game.Content.Load<Texture2D>(@"gfx/Items/Nut"));
            images.Add("ammoRiffle", game.Content.Load<Texture2D>(@"gfx/Items/AmmoRiffle"));
            images.Add("ammoGun", game.Content.Load<Texture2D>(@"gfx/Items/AmmoGun"));
            images.Add("ammoLuncher", game.Content.Load<Texture2D>(@"gfx/Items/AmmoLuncher"));
            
        }

        public Texture2D GetImage(string name)
        {
            Texture2D tex = null;
            images.TryGetValue(name, out tex);
            return tex;
        }
    }
}
