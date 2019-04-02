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
            SceneManager.Instance.currScene.objects.Add(lifebar);
        }

		public void SetValue(float value)
		{
			lifebar.GetComponent<Graphics.Sprite>().rect[1] = new Rectangle(lifebar.size, 0, (int)(20 * value), 1);
		}
    }
}
