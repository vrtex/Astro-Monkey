using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Core
{
    class Scene
    {
        public List<GameObject> objects        = new List<GameObject>();

        public virtual void Load()
        {

        }

        public virtual void UnLoad()
        {

        }
    }
}
