using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace AstroMonkey.Audio
{
    class SoundContainer
    {

        public static SoundContainer Instance = new SoundContainer();

        private Dictionary<String, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        private SoundContainer() { }


        public void AddSound(String name, String path, ContentManager contentManager)
        {
            sounds.Add(name, contentManager.Load<SoundEffect>(path));
        }

        public SoundEffect GetSoundEffect(String id)
        {
            SoundEffect toReturn;
            sounds.TryGetValue(id, out toReturn);
            if(toReturn == null)
            {
                Console.WriteLine("Unexisting sound: " + id);
                Console.WriteLine(new System.Diagnostics.StackTrace());
            }
            return toReturn;
        }
    }
}
