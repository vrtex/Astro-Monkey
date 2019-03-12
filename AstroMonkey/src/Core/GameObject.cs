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
    }
}