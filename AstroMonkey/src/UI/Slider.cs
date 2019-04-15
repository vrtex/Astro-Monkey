using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.UI
{
    class Slider: UIElement
    {
        public Graphics.Sprite      imageBackground;
        public Graphics.Sprite      imageSlider;

        public float                value;


		public Slider(Core.Transform _transform) : base(_transform)
        {

		}

		public Slider(Vector2 anchorPosition, Vector2 anchorSize, float value) : this(new Core.Transform())
		{
			this.anchorPosition = anchorPosition;
			this.anchorSize = anchorSize;
			this.value = value;

			//imageBackground.color = Util.Statics.AstroColor(28);
			//imageSlider.color = Util.Statics.AstroColor(28);
			AnchorToWorldspace(1f);
		}

		public override Vector2 WorldspaceToScreenspace(Vector2 centerPos) { return Vector2.Zero; }
		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos) { }
		public override void OnClick() { }
		public override void OnEnter() { }
		public override void OnExit() { }
	}
}
