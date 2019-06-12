using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class TextWidget : Widget
    {
        public delegate void WidgetEvent(Widget widget);
        public event WidgetEvent OnClick;

        bool clicked = false;

        private string displayString = "";
        public readonly Color inactiveColor = Color.White;
        public Color activeColor = Color.Yellow;

        public Color Color;

        public SpriteFont font = SpriteContainer.Instance.GetFont("planetary");
        Vector2 textScale = new Vector2(1, 1);
        Vector2 textSize = new Vector2();

        private bool isButton = false;
        private bool mouseInside = false;

        public bool IsButton {
            get => isButton;
            set
            {
                if(value == isButton)
                    return;
                isButton = value;
                if(isButton)
                    AttachButtonEvents();
                else
                    DetachButtonEvents();
            }
        }

        public string DisplayString {
            get => displayString;
            set
            {
                this.displayString = value;
                textSize = font.MeasureString(displayString);
                var graphics = ViewManager.Instance.graphics;
                Vector2 screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                Vector2 PixelSize = GetPixelSize();
                textScale.X = stretchX ? (PixelSize.X / textSize.X) : 1;
                textScale.Y = stretchY ? (PixelSize.Y / textSize.Y) : 1;
            }
        }

        public TextWidget(Vector2 position) : this(position, new Vector2())
        {
        }

        public TextWidget(Vector2 position, Vector2 size) : base(position, size)
        {
            Color = inactiveColor;
        }

        public override Rectangle GetDestinationRectangle()
        {
            var baseRect = base.GetDestinationRectangle();
            if(stretchX && stretchY)
                return baseRect;

            if(!stretchY)
                baseRect.Height = (int)textSize.Y;

            if(!stretchX)
                baseRect.Width = (int)textSize.X;

            return baseRect;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(clicked)
            {
                OnClick?.Invoke(this);
                clicked = false;
            }
            spriteBatch.DrawString(font, DisplayString, GetPixelPosition(), Color, 0, new Vector2(), textScale, SpriteEffects.None, 0);
        }

        public override void AddToScreen()
        {
            base.AddToScreen();
            if(IsButton)
                AttachButtonEvents();
        }

        public override void RemoveFromScreen()
        {
            if(IsButton)
                DetachButtonEvents();
            base.RemoveFromScreen();
        }

        private void AttachButtonEvents()
        {
            Input.InputManager.Manager.OnMouseMove += CheckMousePosition;
            Input.InputManager.Manager.OnMouseButtonPressed += CheckMouseClick;
        }

        private void DetachButtonEvents()
        {
            Input.InputManager.Manager.OnMouseMove -= CheckMousePosition;
            Input.InputManager.Manager.OnMouseButtonPressed -= CheckMouseClick;
        }

        private void CheckMousePosition(Input.MouseInputEventArgs mouseArgs)
        {
            Rectangle rect = GetDestinationRectangle();
            bool inside = rect.Contains(mouseArgs.NewPosition.X, mouseArgs.NewPosition.Y);
            if(inside == mouseInside)
                return;

            mouseInside = inside;
            Color = mouseInside ? activeColor : inactiveColor;
        }

        private void CheckMouseClick(Input.MouseInputEventArgs mouseArgs)
        {
            if(!mouseInside)
                return;

            clicked = true;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       