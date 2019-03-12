using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace AstroMonkey
{
    public class KeyInputEventArgs : EventArgs
    {
        public Keys key { get; }

        public KeyInputEventArgs(Keys k)
        {
            key = k;
        }

        public override string ToString()
        {
            return "Key: " + key;
        }
    }

    public enum EMouseButton
    {
        None,
        Left,
        Middle,
        Right
    };

    public class MouseInputEventArgs : EventArgs
    {
        public Vector2 oldPosition { get; }
        public Vector2 newPosition { get; }
        public EMouseButton button { get; }

        public MouseInputEventArgs(EMouseButton button, Vector2 oldPosition, Vector2 newPosition)
        {
            this.button = button;
            this.oldPosition = oldPosition;
            this.newPosition = newPosition;
        }

        public override String ToString()
        {
            return "New position: " + newPosition.ToString() + " old position: " + oldPosition + " key: " + button.ToString();
        }
    }

    /// <summary>
    /// Handles input using events
    /// before using call Initialize and add interesting keys using AddObservedKey
    /// call End() before ending the game, otherwise you'll thread won't stop
    /// </summary>
    class InputManager
    {
        /// <summary>
        /// fires off when key is pressed/released.
        /// </summary>
        /// <param name="key">which key was pressed/released?</param>
        public delegate void KeyboardEvent(KeyInputEventArgs key);
        /// <summary>
        /// fires off when key is pressed.
        /// </summary>
        public event KeyboardEvent OnKeyPressed;
        /// <summary>
        /// fires off when key is released.
        /// </summary>
        public event KeyboardEvent OnKeyReleased;

        /// <summary>
        /// fires off when mouse button is pressed/released (only works for left button for now)
        /// OnMouseMove fires off when mouse is moved
        /// </summary>
        /// <param name="mouseArgs">contains info about event: which button was pressed (None for OnMouseMove), 
        /// old and new position (should be same for presses/releases)</param>
        public delegate void MouseEvent(MouseInputEventArgs mouseArgs);
        /// <summary>
        /// fires off when mouse is moved. Button in args should be None
        /// </summary>
        public event MouseEvent OnMouseMove;
        /// <summary>
        /// fires off when mouse button is pressed. Args should contain info on pressed button and current position
        /// </summary>
        public event MouseEvent OnMouseButtonPressed;
        /// <summary>
        /// fires off when mouse button is pressed. Args should contain info on released button and current position
        /// </summary>
        public event MouseEvent OnMouseButtonReleased;


        KeyboardState PreviousKeyboardState;
        MouseState PreviousMouseState;
        List<Keys> ObservedKeys = new List<Keys>();
        private bool bActive = false;

        public void Initialize()
        {
            PreviousKeyboardState = Keyboard.GetState();
            PreviousMouseState = Mouse.GetState();
            Thread starter = new Thread(new ThreadStart(this.MainLoop));
            bActive = true;
            starter.Start();
        }

        public void AddObservedKey(Keys newKey)
        {
            if(ObservedKeys.Contains(newKey))
                return;
            ObservedKeys.Add(newKey);
        }

        private void MainLoop()
        {
            while(bActive)
            {
                Update();
                Thread.Sleep(16);
            }
        }

        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            ProcessKeyboardChange(currentKeyboardState);

            ProcessMouseChange(currentMouseState);

            PreviousKeyboardState = currentKeyboardState;
            PreviousMouseState = Mouse.GetState();
        }

        private void ProcessKeyboardChange(KeyboardState newState)
        {
            if(newState.Equals(PreviousKeyboardState))
                return;

            foreach(Keys key in ObservedKeys)
            {
                if(newState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key) && OnKeyPressed != null)
                    OnKeyPressed(new KeyInputEventArgs(key));
                else if(newState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key) && OnKeyReleased != null)
                    OnKeyReleased(new KeyInputEventArgs(key));
            }
        }

        private void ProcessMouseChange(MouseState newState)
        {
            if(newState.Equals(PreviousMouseState))
                return;

            ProcessMouseButton(newState);
            ProcessMouseMove(newState);
        }

        private void ProcessMouseButton(MouseState newState)
        {
            if(newState.LeftButton != PreviousMouseState.LeftButton)
            {
                if(newState.LeftButton == ButtonState.Pressed && OnMouseButtonPressed != null)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Left, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
                else if(OnMouseButtonReleased != null)
                    OnMouseButtonReleased(new MouseInputEventArgs(EMouseButton.Left, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
            }
            // TODO: only left mouse button works
            if(newState.RightButton != PreviousMouseState.RightButton)
            {
                if(newState.LeftButton == ButtonState.Pressed && OnMouseButtonPressed != null)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Right, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
                else if(OnMouseButtonReleased != null)
                    OnMouseButtonReleased(new MouseInputEventArgs(EMouseButton.Right, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
            }
            else if(newState.MiddleButton != PreviousMouseState.MiddleButton && OnMouseButtonPressed != null)
            {
                if(newState.LeftButton == ButtonState.Pressed)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Middle, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
                else if(OnMouseButtonReleased != null)
                    OnMouseButtonReleased(new MouseInputEventArgs(EMouseButton.Middle, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
            }
        }

        private void ProcessMouseMove(MouseState newState)
        {
            if(Math.Abs(newState.X - PreviousMouseState.X) < 0.01 && Math.Abs(newState.Y - PreviousMouseState.Y) < 0.01)
                return;
            if(OnMouseMove == null)
                return;
            OnMouseMove(new MouseInputEventArgs(EMouseButton.None,
                new Vector2(PreviousMouseState.X, PreviousMouseState.Y),
                new Vector2(newState.X, newState.Y)
                ));
        }
        
        internal void End()
        {
            bActive = false;
        }
    }
}
