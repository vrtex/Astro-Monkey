using Microsoft.Xna.Framework;

namespace AstroMonkey.Core
{
    public abstract class Component
    {
        public bool active;
        protected GameObject parent;

        public GameObject Parent {
            get { return parent; }
        }

        protected Component(GameObject parent)
        {
            this.parent = parent;
            active = true;
        }

        public virtual void Update(GameTime gameTime) { }
    }
}