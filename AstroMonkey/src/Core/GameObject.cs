using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Core
{
    public class GameObject
    {
        public Transform transform;
        protected List<Component> components;

        public delegate void DestroyEvent(GameObject destroyed);
        public event DestroyEvent OnDestroy;

        public List<Component> Components {
            get { return components; }
        }

        public GameObject(): this(new Transform())
        {
        }

        public GameObject(Transform transform)
        {
            this.transform = transform;
            components = new List<Component>();
        }

        public Component AddComponent(Component component)
        {
            components.Add(component);
            return component;
        }

        public Component RemoveComponent(Component component)
        {
            components.RemoveAll(x => x == component);
            return component;
        }

        public List<T> GetComponents<T>() where T: Component
        {
            List<T> toReturn = new List<T>();

            foreach(Component c in components)
                if(c is T)
                    toReturn.Add((T)c);

            return toReturn;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach(Component c in components)
                if(c is T) return (T)c;

            return null;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(var c in components)
                c.Update(gameTime);
        }

        public virtual void Destroy()
        {
            foreach(Component c in components)
                c.Destroy();
            OnDestroy?.Invoke(this);
        }
    }
}