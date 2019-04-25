using AstroMonkey.Core;
using AstroMonkey.Assets.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AstroMonkey.UI
{
    class HealthBar: Component
    {
        EnemyHealthBar lifebar = null;

        public HealthBar(GameObject parent) : base(parent)
        {
            
        }

        public HealthBar(GameObject parent, int size): this(parent)
        {
            float sceneScale = SceneManager.scale;

            lifebar = new EnemyHealthBar(new Transform(new Vector2(0f, 0f), 
                                            new Vector2(sceneScale, sceneScale), 
                                            0f),
                                            new Vector2(0, size),
                                            new Vector2(0, -size));
            lifebar.SetTrack(parent.transform);
            parent.OnDestroy += DestroyHealthBar;
            GameManager.SpawnObject(lifebar);
        }

        private void DestroyHealthBar(GameObject destroyed)
        {
            lifebar.Destroy();
        }

        public void Refresh(Gameplay.Health damaged, Gameplay.DamageInfo dmgInfo)
        {
            SetValue(damaged.GetPercentage());
        }

		public void SetValue(float value)
		{
			lifebar.GetComponent<Graphics.Sprite>().rect[1] = new Rectangle(lifebar.size, 0, (int)(lifebar.size * value), 1);
		}
    }
}
