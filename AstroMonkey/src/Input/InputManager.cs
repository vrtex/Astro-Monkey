using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using AstroMonkey.Graphics;

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
        public bool pressed;

        public MouseInputEventArgs(EMouseButton button, Vector2 oldPosition, Vector2 newPosition, bool pressed = false)
        {
            this.Button = button;
            this.OldPosition = oldPosition;
            this.NewPosition = newPosition;
            this.pressed = pressed;
        }

        public override String ToString()
        {
            return "New position: " + NewPosition.ToString() + " old position: " + OldPosition + " key: " + Button.ToString();
        }
    }

    class InputManager
    {
        public delegate void KeyboardEvent(KeyInputEventArgs key);
        public event KeyboardEvent OnKeyPressed;
        public event KeyboardEvent OnKeyReleased;

        public delegate void MouseEvent(MouseInputEventArgs mouseArgs);
        public event MouseEvent OnMouseMove;
        public event MouseEvent OnMouseButtonPressed;
        public event MouseEvent OnMouseButtonReleased;


        KeyboardState PreviousKeyboardState;
        MouseState PreviousMouseState;
        List<Keys> ObservedKeys = new List<Keys>();
        private Timer tickTimer = new Timer(16);
        public Vector2 MouseCursor { get; private set; } = new Vector2();
        public Vector2 MouseCursorInWorldSpace {
            get => Manager.MouseCursor + ViewManager.Instance.PlayerTransform.position - Util.Statics.GetResolition(ViewManager.Instance.ScreenSize) / 2f;
        }

        private Dictionary<String, ActionBinding> actionBindings = new Dictionary<string, ActionBinding>();
        private Dictionary<String, AxisBinding> axisBindings = new Dictionary<string, AxisBinding>();

        public static InputManager Manager { get; private set; } = new InputManager();
        private InputManager()
        {
            tickTimer.Elapsed += OnTick;
            tickTimer.Start();
            Initialize();
        }

        private void Initialize()
        {
            PreviousKeyboardState = Keyboard.GetState();
            PreviousMouseState = Mouse.GetState();
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

        public void AddActionBinding(String name, ActionBinding binding, bool allowReplace = true)
        {
            if(actionBindings.ContainsKey(name))
                if(!allowReplace)
                    throw new ApplicationException("trying to replace existing action binding");
                else
                    actionBindings.Remove(name);

            //OnKeyPressed += binding.CheckKey;
            //OnKeyReleased += binding.CheckKey;

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

        public void AddAxisBinding(String name, AxisBinding binding, bool allowReplace = true)
        {
            if(axisBindings.ContainsKey(name))
                if(!allowReplace)
                    throw new ApplicationException("trying to replace existing axis binding");
                else
                    axisBindings.Remove(name);


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

        public void RemoveBinding(string name)
        {
            axisBindings.Remove(name);
            actionBindings.Remove(name);
        }

        private void OnTick(Object o, ElapsedEventArgs args)
        {
            Update();
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

            MouseCursor = newState.Position.ToVector2();
        }

        private void ProcessMouseButton(MouseState newState)
        {
            if(newState.LeftButton != PreviousMouseState.LeftButton)
            {
                if(newState.LeftButton == ButtonState.Pressed && OnMouseButtonPressed != null)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Left, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y), true));
                else if(OnMouseButtonReleased != null)
                    OnMouseButtonReleased(new MouseInputEventArgs(EMouseButton.Left, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
            }
            if(newState.RightButton != PreviousMouseState.RightButton)
            {
                if(newState.LeftButton == ButtonState.Pressed && OnMouseButtonPressed != null)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Right, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y), true));
                else if(OnMouseButtonReleased != null)
                    OnMouseButtonReleased(new MouseInputEventArgs(EMouseButton.Right, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y)));
            }
            else if(newState.MiddleButton != PreviousMouseState.MiddleButton && OnMouseButtonPressed != null)
            {
                if(newState.LeftButton == ButtonState.Pressed)
                    OnMouseButtonPressed(new MouseInputEventArgs(EMouseButton.Middle, new Vector2(PreviousMouseState.X, PreviousMouseState.Y), new Vector2(newState.X, newState.Y), true));
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
    }
}
