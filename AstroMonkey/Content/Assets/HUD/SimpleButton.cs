using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using AstroMonkey.Navigation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AstroMonkey.Graphics;
using System.Diagnostics;
using System.Collections.Generic;

namespace AstroMonkey.Assets.Objects
{
	class SimpleButton: UI.Image
	{
		public SimpleButton() : this(new Transform())
        {
		}
		public SimpleButton(Transform _transform) : base(_transform)
        {
			Load();
		}
		public SimpleButton(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
        {
		}
		public SimpleButton(Vector2 position) : this(new Core.Transform(position, Vector2.One))
        {
		}

		private void Load()
		{
			anchorPosition = new Vector2(1f, 0.2f);
			anchorSize = new Vector2(0.2f, 0.1f);
			image = new Sprite(this, "alien01", new List<Rectangle> { new Rectangle(0, 0, 21, 21) });

			AnchorToWorldspace(1f);

			AddComponent(new Input.InputUI(this));
		}

		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{
			Vector2 tempPos = Vector2.Zero;
			tempPos = centerPos - ViewManager.Instance.WinSize() / 2;
			tempPos.X += position.X;
			tempPos.Y += position.Y;
			spriteBatch.Draw(image.image, tempPos, image.color);
		}

		public override void OnClick()
		{
			Debug.WriteLine("Jestem klikniety");
		}

		public override void OnEnter()
		{
			image.color = Util.Statics.Colors.DARK_RED;
		}
		public override void OnExit()
		{
			image.color = Util.Statics.Colors.WHITE_1;
		}

	}
}
