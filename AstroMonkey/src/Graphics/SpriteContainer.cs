using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    public sealed class SpriteContainer
    {
        public Dictionary<string, Texture2D>       images = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont>       fonts = new Dictionary<string, SpriteFont>();

        public static SpriteContainer Instance { get; private set; } = new SpriteContainer();

        static SpriteContainer()
        {   
        }

        public void LoadTextures(Game game)
        {
            //interfejs
            images.Add("mark", game.Content.Load<Texture2D>(@"gfx/UI/HUD/mark"));
            images.Add("bar", game.Content.Load<Texture2D>(@"gfx/UI/HUD/bar"));
            images.Add("gunIcons", game.Content.Load<Texture2D>(@"gfx/HUD/guns"));

            //efekty
            images.Add("poop", game.Content.Load<Texture2D>(@"gfx/Projectiles/Poop")); 
            images.Add("rocket", game.Content.Load<Texture2D>(@"gfx/Projectiles/Rocket"));
            images.Add("bulletHit", game.Content.Load<Texture2D>(@"gfx/Projectiles/BulletHit"));
            images.Add("alienBullet", game.Content.Load<Texture2D>(@"gfx/Projectiles/AlienBullet"));
			images.Add("pistolBullet", game.Content.Load<Texture2D>(@"gfx/Projectiles/PistolBullet"));

			//postacie
			images.Add("monkey", game.Content.Load<Texture2D>(@"gfx/Characters/Player/monkey"));
            images.Add("alien01", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien01"));
            images.Add("alien02", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien02"));
            images.Add("alien03", game.Content.Load<Texture2D>(@"gfx/Characters/Enemies/Alien03"));

            //podłoga
            images.Add("floorPlatform", game.Content.Load<Texture2D>(@"gfx/Map/Floor/FloorPlatform"));
            images.Add("floorCrate", game.Content.Load<Texture2D>(@"gfx/Map/Floor/FloorCrate"));

            //otoczenie
            images.Add("wall", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall"));
            images.Add("wallDoor", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wallDoor"));
            images.Add("corner", game.Content.Load<Texture2D>(@"gfx/Map/Objects/corner"));
            images.Add("cornerPhillar", game.Content.Load<Texture2D>(@"gfx/Map/Objects/cornerPhillar"));
            images.Add("column", game.Content.Load<Texture2D>(@"gfx/Map/Objects/column"));
            images.Add("cockpit", game.Content.Load<Texture2D>(@"gfx/Map/Objects/cockpit"));
            images.Add("armchair", game.Content.Load<Texture2D>(@"gfx/Map/Objects/armchair"));
            images.Add("fridge", game.Content.Load<Texture2D>(@"gfx/Map/Objects/fridge"));
            images.Add("case", game.Content.Load<Texture2D>(@"gfx/Map/Objects/case"));
            images.Add("caseMicrowave", game.Content.Load<Texture2D>(@"gfx/Map/Objects/caseMicrowave"));
            images.Add("caseCaffe", game.Content.Load<Texture2D>(@"gfx/Map/Objects/caseCaffe"));
            images.Add("table", game.Content.Load<Texture2D>(@"gfx/Map/Objects/Table"));
            images.Add("neonSign", game.Content.Load<Texture2D>(@"gfx/Map/Objects/NeonSign"));
            images.Add("half-wall", game.Content.Load<Texture2D>(@"gfx/Map/Objects/half-wall"));
            images.Add("doorRight", game.Content.Load<Texture2D>(@"gfx/Map/Objects/DoorRight"));
            images.Add("doorLeft", game.Content.Load<Texture2D>(@"gfx/Map/Objects/DoorLeft"));
			images.Add("wall02", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall02"));
			images.Add("wall03", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall03"));
			images.Add("wall04", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall04"));
			images.Add("wall05", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall05"));
			images.Add("wall06", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall06"));
			images.Add("wall07", game.Content.Load<Texture2D>(@"gfx/Map/Objects/wall07"));

			//interaktywne
			images.Add("terminal", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/terminal"));
            images.Add("terminalOff", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/terminalOff"));
            images.Add("buttonWall", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/buttonWall"));
            images.Add("buttonClicked", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/buttonClicked"));

			//nawigacja
			images.Add("navigationPoint", game.Content.Load<Texture2D>(@"gfx/Map/Interactable/navPoint"));

			//przedmioty
			images.Add("banana", game.Content.Load<Texture2D>(@"gfx/Items/Banana"));
            images.Add("nut", game.Content.Load<Texture2D>(@"gfx/Items/Nut"));
            images.Add("ammoRiffle", game.Content.Load<Texture2D>(@"gfx/Items/AmmoRiffle"));
            images.Add("ammoGun", game.Content.Load<Texture2D>(@"gfx/Items/AmmoGun"));
            images.Add("ammoLuncher", game.Content.Load<Texture2D>(@"gfx/Items/AmmoLuncher"));
            
            //fonty
            fonts.Add("text", game.Content.Load<SpriteFont>(@"spritefonts/text"));
			fonts.Add("planetary", game.Content.Load<SpriteFont>(@"spritefonts/PlanetaryContact"));

			//sceny
			images.Add("scene01", game.Content.Load<Texture2D>(@"gfx/Scenes/scene01"));
			images.Add("scene02", game.Content.Load<Texture2D>(@"gfx/Scenes/scene02"));
			images.Add("scene03", game.Content.Load<Texture2D>(@"gfx/Scenes/scene03"));
			images.Add("scene04", game.Content.Load<Texture2D>(@"gfx/Scenes/scene04"));
			images.Add("scene05", game.Content.Load<Texture2D>(@"gfx/Scenes/scene05"));
		}

        public Texture2D GetImage(string name)
        {
            Texture2D tex = null;
            images.TryGetValue(name, out tex);

            if(tex == null)
                throw new System.ApplicationException("Texture " + name + " does not exist");

            return tex;
        }

        public SpriteFont GetFont(string name)
        {
            SpriteFont font = null;
            fonts.TryGetValue(name, out font);
            return font;
        }
    }
}
