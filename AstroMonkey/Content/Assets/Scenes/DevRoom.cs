using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class DevRoom: Core.Scene
    {
        public override void Load()
        {
            objects.Add(new Objects.Player(new Vector2(20f, 50f)));

            objects.Add(new Objects.Player(new Vector2(90f, 70f)));
            objects[1].GetComponent<Graphics.Animator>().SetAnimation("WalkDown");

            objects.Add(new Objects.Klucha(new Vector2(140f, 100f)));
            objects[2].GetComponent<Graphics.Animator>().SetAnimation("WalkUp");
        }

        public override void UnLoad()
        {
            
        }
    }
}
