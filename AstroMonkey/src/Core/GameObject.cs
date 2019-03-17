using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Core
{
    public abstract class GameObject
    {
        public Transform transform;
        protected List<Component> components;

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

        public void AddComponent(Component component)
        {
            components.Add(component);
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

        public virtual void Update(GameTime gameTime) { }
    }
}