namespace AstroMonkey.Core
{
    public class Component
    {
        public bool active;
        private GameObject parent;

        public GameObject Parent {
            get { return parent; }
        }

        public Component(GameObject parent)
        {
            this.parent = parent;
            active = true;
        }
    }
}