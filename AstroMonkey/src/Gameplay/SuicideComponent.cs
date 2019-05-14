using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AstroMonkey.Gameplay
{
    class SuicideComponent : Component
    {
        System.Timers.Timer timer;

        public SuicideComponent(GameObject parent) : base(parent)
        {
        }

        public override void Destroy()
        {
            timer.Stop();
            base.Destroy();
        }

        public void Start(int millis)
        {
            timer = new System.Timers.Timer((double)millis);
            timer.Elapsed += Suicide;
            timer.Start();
        }

        private void Suicide(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine("suicide");
            GameManager.DestroyObject(parent);
        }
    }
}
