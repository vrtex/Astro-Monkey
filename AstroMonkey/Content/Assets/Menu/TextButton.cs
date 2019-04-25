using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using AstroMonkey.Navigation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AstroMonkey.Graphics;
using System.Diagnostics;

namespace AstroMonkey.Assets.Objects
{
	class TextButton: UI.Text
	{
		public delegate void	clickEvent(TextButton textButton);
		public event			clickEvent onClick;
		public int				value = 0;
		public bool				hover = false;

        private Audio.AudioSource clickSFX;
        private Audio.AudioSource hoverSFX;

        public TextButton() : this(new Transform())
		{
		}
		public TextButton(Transform _transform) : base(_transform)
		{
		}
		public TextButton(Vector2 position, Vector2 scale, float rotation = 0f) : this(new Core.Transform(position, scale, rotation))
		{
		}
		public TextButton(Vector2 position) : this(new Core.Transform(position, Vector2.One))
		{
		}

		public TextButton(string text, string fontName, Vector2 anchorPosition, Vector2 anchorSize) : this(new Core.Transform())
		{
			SetText(text, fontName, anchorPosition, anchorSize);
			Load();
		}

		public void SetText(string text, string fontName, Vector2 anchorPosition, Vector2 anchorSize)
		{
			this.anchorPosition = anchorPosition;
			this.anchorSize = anchorSize;
			this.text = text;
			this.fontName = fontName;
			color = Util.Statics.AstroColor(28);
			AnchorToWorldspace(0.5f);
		}

		public void Load()
		{
			
			AddComponent(new Input.InputUI(this));
            clickSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("MenuClick")));
            hoverSFX = AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("MenuHover")));
        }

		public override Vector2 WorldspaceToScreenspace(Vector2 centerPos)
		{
			Vector2 tempPos = Vector2.Zero;
			tempPos = centerPos - ViewManager.Instance.WinSize() / 2;
			tempPos.X += position.X;
			tempPos.Y += position.Y;

			return tempPos;
		}

		public override void Draw(SpriteBatch spriteBatch, Vector2 centerPos)
		{
			if(!enable) return;
			spriteBatch.DrawString(SpriteContainer.Instance.GetFont(fontName), text, WorldspaceToScreenspace(centerPos), color);
		}

		public override void OnClick()
		{
			if(!enable) return;
            clickSFX.Play();
			onClick?.Invoke(this);
		}

		public override void OnEnter()
		{
			if(!enable) return;
			if(!hover)
			{
                hoverSFX.Play();
				color = Util.Statics.AstroColor(9);
				hover = true;
			}
		}
		public override void OnExit()
		{
			if(!enable) return;
			if(hover)
			{
				color = Util.Statics.AstroColor(28);
				hover = false;
			}
			
		}

	}
}
