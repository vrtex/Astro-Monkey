using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Monkey: Core.GameObject
    {
        public Monkey()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Monkey(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Monkey(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Monkey(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.StackSprite(this, "monkey", new List<Rectangle> {
                new Rectangle(0, 0, 16, 16),
                new Rectangle(16, 0, 16, 16),
                new Rectangle(32, 0, 16, 16),
                new Rectangle(48, 0, 16, 16),
                new Rectangle(64, 0, 16, 16),
                new Rectangle(80, 0, 16, 16),
                new Rectangle(96, 0, 16, 16),
                new Rectangle(112, 0, 16, 16),
                new Rectangle(128, 0, 16, 16),
                new Rectangle(144, 0, 16, 16)}));

        }
    }
}
