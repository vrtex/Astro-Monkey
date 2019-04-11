using System;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Scenes
{
    class Basement : Core.Scene
    {
        public override void Load()
        {
            base.Load();
            Vector2 alienPos = new Vector2(350f, 170f);
            GameManager.SpawnObject(new Objects.Alien01(alienPos, new Vector2(sceneScale, sceneScale), (float)(Math.PI)));

            Vector2 playerPos = new Vector2(20f, 650f);

            Objects.Player player = new Objects.Player(playerPos, new Vector2(sceneScale, sceneScale), 0f);
            GameManager.SpawnObject(player);

            Vector2 step = alienPos - playerPos;
            step /= 10f;
            for(int i = 0; i < 9; ++i)
            {
                playerPos += step;
                Core.GameObject gameObject = new Objects.Banana(playerPos, new Vector2(sceneScale, sceneScale));
                GameManager.SpawnObject(gameObject);
            }

            Graphics.ViewManager.Instance.PlayerTransform = player.transform;
        }
    }
}
