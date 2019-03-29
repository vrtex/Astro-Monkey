using System;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class Basement : Core.Scene
    {
        public override void Load()
        {
            base.Load();
            objects.Add(new Objects.Alien01(new Vector2(350f, 170f), new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

            Objects.Player player = new Objects.Player(new Vector2(20f, 650f), new Vector2(sceneScale, sceneScale), 0f);
            objects.Add(player);
            Graphics.ViewManager.Instance.PlayerTransform = player.transform;
        }
    }
}
