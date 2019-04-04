using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Gameplay
{
    class SuicideComponent : Component
    {
        System.Timers.Timer timer;

        public SuicideComponent(GameObject parent) : base(parent)
        {
        }

        public void Start(int millis)
        {
            timer = new System.Timers.Timer((double)millis);
            timer.Elapsed += Suicide;
        }

        private void Suicide(object sender, System.Timers.ElapsedEventArgs e)
        {
            GameManager.DestroyObject(parent);
        }
    }
}
