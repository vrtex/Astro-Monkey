using System;
using System.Collections.Generic;
using System.Linq;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Physics.Collider
{
    public class BoxCollider : Collider
    {
        public float width { get; set; }
        public float height { get; set; }

        public BoxCollider(GameObject gameObject, CollisionChanell collisionChanell = CollisionChanell.Object, Vector2 relativePosition = new Vector2(), float width = 1, float height = 1) : base(gameObject, collisionChanell, relativePosition)
        {
            float epsilon = (float)Math.PI / 8;
            float rotation = Parent.transform.rotation;

            if (Math.Abs(rotation - Math.PI / 2) < epsilon || Math.Abs(rotation - Math.PI / 2 - Math.PI) < epsilon)
            {
                this.height = width * scale;
                this.width = height * scale;
            }
            else
            {
                this.width = width * scale;
                this.height = height * scale;
            }
        }


        public override void DrawBorder(SpriteBatch spriteBatch)
        {
            Color borderColor = Util.Statics.Colors.DARK_RED;
            int thicknessOfBorder = 1;

            Texture2D pixel;
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Util.Statics.Colors.WHITE_1 });

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