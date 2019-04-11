using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Assets.Scenes
{
    class Level1 : Core.Scene
    {
        public override void Load()
        {
            base.Load();
            LoadFromFile("Content/Maps/AstroMonkey.tmx");

            Objects.Player playerObject = GetObjectsByClass<Assets.Objects.Player>()[0];
            if(playerObject == null)
                throw new ApplicationException("something went wrong");
            Graphics.ViewManager.Instance.PlayerTransform = playerObject.transform;
        }
    }
}
