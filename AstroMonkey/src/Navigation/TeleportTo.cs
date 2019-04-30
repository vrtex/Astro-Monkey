using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Navigation
{
    class TeleportTo: Component
    {
        public Transform trackPoint = null;
        public Vector2 offset = Vector2.Zero;

        public TeleportTo(GameObject parent) : base(parent)
        {
            
        }
        
    }
}
