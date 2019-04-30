using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AstroMonkey.Core;
using AstroMonkey.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Physics.Collider
{
    public class CircleCollider : Collider
    {
        public float radius { get; set; }

        public CircleCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 relativePosition = new Vector2(), float radius = 1, bool temp = false)
            : base(gameObject, collisionChanell, relativePosition, temp)
        {
            this.radius = radius * scale;
        }

        public override void DrawBorder(SpriteBatch spriteBatch)
        {
            Color borderColor = Util.Statics.Colors.DARK_RED;
            int thicknessOfBorder = 1;

            Texture2D pixel;
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Util.Statics.Colors.WHITE_1 });

            float width = radius * 2;
            float height = radius * 2;

            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle((int)(this.GetPosition().X - width / 2), (int)(this.GetPosition().Y - height / 2), (int)width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle((int)(this.GetPosition().X - width / 2), (int)(this.GetPosition().Y - height / 2), thicknessOfBorder, (int)height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle(((int)(this.GetPosition().X + width / 2) - thicknessOfBorder),
                (int)(this.GetPosition().Y - height / 2),
                thicknessOfBorder,
                (int)height), borderColor);

            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle((int)(this.GetPosition().X - width / 2),
                (int)(this.GetPosition().Y + height / 2) - thicknessOfBorder,
                (int)width,
                thicknessOfBorder), borderColor);

            spriteBatch.DrawString(Graphics.SpriteContainer.Instance.GetFont("text"), this.parent.ToString().Split('.').Last(), GetPosition(), Util.Statics.Colors.DARK_RED);
        }
    }
}