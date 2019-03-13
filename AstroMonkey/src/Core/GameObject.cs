using System.Collections.Generic;

namespace AstroMonkey.Core
{
    public class GameObject
    {
        public Transform transform;
        private List<Component> components;

        public List<Component> Components {
            get { return components; }
        }

        public GameObject()
        {
            transform = new Transform();
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
    }
}