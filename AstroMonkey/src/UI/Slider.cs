﻿using System;
using System.Diagnostics;
using System.Text;
using AstroMonkey.Graphics;
using AstroMonkey.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.UI
{
    class Slider: UIElement
    {
        private String sliderBackground;
        private const int SLIDER_INTERFACE_SIZE = 2;
        private const int SLIDER_WIDTH = 15;
        public float value;
        private String text;

        public delegate void SliderEvent(Slider slider);
        public event SliderEvent onChange;

        private Color color = Util.Statics.Colors.WHITE_1;
        private Audio.AudioSource clickSFX;
        private Audio.AudioSource hoverSFX;


        public Slider(Core.Transform _transform) : base(_transform)
        {
            InputManager.Manager.OnMouseButtonReleased += ReleaseSlider;
            Load();
        }

        public Slider(Vector2 anchorPosition, Vector2 anchorSize, float value, String text) : this(new Core.Transform())
		{
			this.anchorPosition = anchorPosition;
			this.anchorSize = anchorSize;
			this.value = value;
            this.text = text;
            AnchorToWorldspace(0.5f);


            drawSliderBackground();
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
            if (!enable) return;
            spriteBatch.DrawString(SpriteContainer.Instance.GetFont("planetary"), drawSlider(value), WorldspaceToScreenspace(centerPos), color);
        }

        // <====|||========================>
        // <====|||------------------------>
        // <||||||=========================>

        private void drawSliderBackground()
        {
            StringBuilder stringBuilder = new StringBuilder(SLIDER_WIDTH + SLIDER_INTERFACE_SIZE);

            stringBuilder.Append('<');
            for (int i = 0; i < SLIDER_WIDTH; i++)
            {
                stringBuilder.Append('=');
            }
            stringBuilder.Append('>');
            stringBuilder.Append("  " + text);
            sliderBackground = stringBuilder.ToString();
        }

        private String drawSlider(float value)
        {
            value = MathHelper.Clamp(value, 0, 1);
            StringBuilder slider = new StringBuilder(sliderBackground);

            int val = MathHelper.Clamp((int) (SLIDER_INTERFACE_SIZE / 2 + SLIDER_WIDTH * value),
                SLIDER_INTERFACE_SIZE / 2 + 1, SLIDER_WIDTH - SLIDER_INTERFACE_SIZE / 2);

            slider[val] = '|';
            slider[val + 1] = '|';
            slider[val - 1] = '|';


            return slider.ToString();
        }

        public override void OnClick()
        {
            if(!enable) return;
            InputManager.Manager.OnMouseMove += UpdateCursorPosition;
            FollowCursor();
        }

        private void FollowCursor()
        {
            value = (InputManager.Manager.MouseCursor.X - position.X) / 300;
            value = MathHelper.Clamp(value, 0, 1);
            if(value < 0.13f)
                value = 0f;
            onChange?.Invoke(this);
        }

        //public override void OnClick()
        //{
        //    if (!enable) return;
        //    clickSFX.Play();
        //    onClick?.Invoke(this);
        //}
        public override void OnEnter()
        {
            color = Util.Statics.Colors.ORANGE;
        }

        public override void OnExit()
        {
            color = Util.Statics.Colors.WHITE_1;
        }

        private void ReleaseSlider(MouseInputEventArgs mouseArgs)
        {
            if(mouseArgs.Button != EMouseButton.Left)
                return;
            InputManager.Manager.OnMouseMove -= UpdateCursorPosition;
        }

        private void UpdateCursorPosition(MouseInputEventArgs mouseArgs)
        {
            FollowCursor();
        }

        public override void Destroy()
        {
            InputManager.Manager.OnMouseMove -= UpdateCursorPosition;
            InputManager.Manager.OnMouseButtonReleased -= ReleaseSlider;
            base.Destroy();
        }
    }
}
