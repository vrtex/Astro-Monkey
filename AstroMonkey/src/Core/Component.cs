namespace AstroMonkey.Core
{
    public abstract class Component
    {
        public bool active;
        private GameObject parent;

        public GameObject Parent {
            get { return parent; }
        }

        protected Component(GameObject parent)
        {
            this.parent = parent;
            active = true;
        }
    }
}