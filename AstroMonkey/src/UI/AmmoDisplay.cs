using AstroMonkey.Core;
using AstroMonkey.Gameplay;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.UI
{
    class AmmoDisplay : GameObject
    {
        private Text text;
        // private Image image;

        public AmmoDisplay(GameObject parent)
        {
            text = GameManager.SpawnObject(new Text("0/0", "planetary", new Vector2(0.8f, 0.8f), new Vector2(0.1f, 0.1f)));
        }

        public void SetAmmoCount(AmmoInfo ammoInfo)
        {

            text.SetText("" + ammoInfo.loaded + "/" + ammoInfo.reservesLeft + "\n" +
                ammoInfo.type.Name);
        }

        public override void Destroy()
        {
            text.Destroy();
            base.Destroy();
        }
    }
}
