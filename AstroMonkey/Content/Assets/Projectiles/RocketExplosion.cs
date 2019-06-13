using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;

namespace AstroMonkey.Assets.Objects
{
    class RocketExplosion : Core.GameObject
    {
        public RocketExplosion(Transform transform) : base(transform)
        {

            Gameplay.SuicideComponent suicide = AddComponent(new Gameplay.SuicideComponent(this));
            suicide.Start(1000);
        }
    }
}
