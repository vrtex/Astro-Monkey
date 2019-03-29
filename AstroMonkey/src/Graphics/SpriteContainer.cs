﻿using System.Collections.Generic;
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
            images.Add("alien01", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien01"));
            images.Add("alien02", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien02"));
            images.Add("alien03", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien03"));

            //otoczenie
            images.Add("floor", game.Content.Load<Texture2D>(@"gfx/Map/Floor/PlatformFloor"));
            images.Add("wall", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall"));
            images.Add("corner", game.Content.Load<Texture2D>(@"gfx/Map/Objects/corner"));
            images.Add("column", game.Content.Load<Texture2D>(@"gfx/Map/Objects/column"));
            images.Add("cockpit", game.Content.Load<Texture2D>(@"gfx/Map/Objects/cockpit"));
            images.Add("armchair", game.Content.Load<Texture2D>(@"gfx/Map/Objects/armchair"));
            images.Add("fridge", game.Content.Load<Texture2D>(@"gfx/Map/Objects/fridge"));
            images.Add("case", game.Content.Load<Texture2D>(@"gfx/Map/Objects/case"));
            images.Add("caseMicrowave", game.Content.Load<Texture2D>(@"gfx/Map/Objects/caseMicrowave"));
            images.Add("caseCaffe", game.Content.Load<Texture2D>(@"gfx/Map/Objects/caseCaffe"));
            images.Add("table", game.Content.Load<Texture2D>(@"gfx/Map/Objects/Table"));
            images.Add("neonSign", game.Content.Load<Texture2D>(@"gfx/Map/Objects/NeonSign"));

            //interaktywne
            images.Add("terminal", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/terminal"));
            images.Add("terminalOff", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/terminalOff"));
            images.Add("buttonWall", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/buttonWall"));
            images.Add("buttonClicked", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/buttonClicked"));

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
