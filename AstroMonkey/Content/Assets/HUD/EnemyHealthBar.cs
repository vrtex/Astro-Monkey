using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using AstroMonkey.Navigation;
using Microsoft.Xna.Framework;
using AstroMonkey.Graphics;

namespace AstroMonkey.Assets.Objects
{
    class EnemyHealthBar: GameObject
    {
        private int height = 1;
        public int size = 20;

        public EnemyHealthBar() : this(new Transform())
        {
        }
        public EnemyHealthBar(Transform _transform) : base(_transform)
        {
            Load(_transform, Vector2.Zero, Vector2.Zero);
        }
        public EnemyHealthBar(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
        }
        public EnemyHealthBar(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
        }

        public EnemyHealthBar(Transform _transform, Vector2 offsetTeleport, Vector2 offsetSprite) : base(_transform)
        {
            Load(_transform, offsetTeleport, offsetSprite);
        }

        private void Load(Transform _transform, Vector2 offsetTeleport, Vector2 offsetSprite)
        {
            TeleportTo tt = new TeleportTo(this);
            tt.offset = offsetTeleport;
            AddComponent(tt);

            List<Rectangle> bar = new List<Rectangle>();
            bar.Add(new Rectangle(size, 2, size, height));
            bar.Add(new Rectangle(size, 0, size, height));

            Sprite gfx = new Sprite(this, "bar", bar);
            gfx.anchor = offsetSprite;
			gfx.stackOffset = 0;
			gfx.origin = new Vector2(10, 0);
            AddComponent(gfx);
        }

        public void SetTrack(Transform track)
        {
            GetComponent<TeleportTo>().trackPoint = track;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            TeleportTo track = GetComponent<TeleportTo>();
            if(track != null) transform.position = track.trackPoint.position + track.offset;

			//track.
        }

    }
}
