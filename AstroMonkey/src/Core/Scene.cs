using System.Collections.Generic;

namespace AstroMonkey.Core
{
    class Scene
    {
        protected float sceneScale = 3f;

        public List<GameObject> objects        = new List<GameObject>();


        public virtual void Reset() { }

        public virtual void Load()
        {
            // ??
            foreach(GameObject obj in objects)
                obj.Destroy();
            objects.Clear();
        }

        public virtual void UnLoad()
        {
            foreach(GameObject obj in objects)
                obj.Destroy();
            Graphics.ViewManager.Instance.PlayerTransform = null;
        }
    }
}
