using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace AstroMonkey.Input
{
    public class KeyInputEventArgs : EventArgs
    {
        public Keys Key { get; }
        public bool pressed;

        public KeyInputEventArgs(Keys k, bool pressed)
        {
            Key = k;
            this.pressed = pressed;
        }

        public override string ToString()
        {
            return "Key: " + Key;
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
        public Vector2 OldPosition { get; }
        public Vector2 NewPosition { get; }
        public EMouseButton Button { get; }

        public MouseInputEventArgs(EMouseButton button, Vector2 oldPosition, Vector2 newPosition)
        {
            this.Button = button;
            this.OldPosition = oldPosition;
            this.NewPosition = newPosition;
        }

        public override String ToString()
        {
            return "New position: " + NewPosition.ToString() + " old position: " + OldPosition + " key: " + Button.ToString();
        }
    }

    /// <summary>
    /// Handles input using events
    /// before using add interesting keys using AddObservedKey
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

        private Dictionary<String, ActionBinding> actionBindings = new Dictionary<string, ActionBinding>();
        private Dictionary<String, AxisBinding> axisBindings = new Dictionary<string, AxisBinding>();

        public static InputManager Manager { get; private set; } = new InputManager();
        private InputManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            PreviousKeyboardState = Keyboard.GetState();
            PreviousMouseState = Mouse.GetState();
            Thread starter = new Thread(new ThreadStart(this.MainLoop));
            bActive = true;
            starter.Start();
        }

        public bool IsKeyPressed(Keys key)
        {
            return PreviousKeyboardState.IsKeyDown(key);
        }

        public void AddObservedKey(Keys newKey)
        {
            if(ObservedKeys.Contains(newKey))
                return;
            ObservedKeys.Add(newKey);
        }

        public void AddActionBinding(String name, ActionBinding binding)
        {
            if(actionBindings.ContainsKey(name))
                throw new ApplicationException("trying to replace existing action binding");

            OnKeyPressed += binding.CheckKey;
            OnKeyReleased += binding.CheckKey;

            AddObservedKey(binding.Key);

            actionBindings.Add(name, binding);
        }

        public ActionBinding GetActionBinding(String name)
        {
            foreach(KeyValuePair<String, ActionBinding> pair in actionBindings)
                if(pair.Key == name)
                    return pair.Value;
            return null;
        }

        public void AddAxisBinding(String name, AxisBinding binding)
        {
            if(actionBindings.ContainsKey(name))
                throw new ApplicationException("trying to replace existing axis binding");

            AddObservedKey(binding.PositiveKey);
            AddObservedKey(binding.NegativeKey);

            axisBindings.Add(name, binding);
        }

        public AxisBinding GetAxisBinding(String name)
        {
            foreach(KeyValuePair<String, AxisBinding> pair in axisBindings)
                if(pair.Key == name)
                    return pair.Value;
            return null;
        }

        private void MainLoop()
        {
            while(bActive)
            {
                Update();
                Thread.Sleep(16);
            }
        }

        private void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            ProcessKeyboardChange(currentKeyboardState);

            ProcessMouseChange(currentMouseState);

            PreviousKeyboardState = currentKeyboardState;
            PreviousMouseState = Mouse.GetState();

            foreach(AxisBinding b in axisBindings.Values)
                b.Update();
        }

        private void ProcessKeyboardChange(KeyboardState newState)
        {
            if(newState.Equals(PreviousKeyboardState))
                return;

            foreach(Keys key in ObservedKeys)
            {
                if(newState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key) && OnKeyPressed != null)
                    OnKeyPressed(new KeyInputEventArgs(key, true));
                else if(newState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key) && OnKeyReleased != null)
                    OnKeyReleased(new KeyInputEventArgs(key, false));
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
        
        public void End()
        {
            bActive = false;
        }
    }
}
