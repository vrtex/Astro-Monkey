using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Core
{
    class SceneManager
    {
        public List<Scene> animators = new List<Scene>();
        public static SceneManager Instance { get; private set; } = new SceneManager();

        static SceneManager()
        {
        }
    }
}
