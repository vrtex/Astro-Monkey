using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Core
{
    class ObjectManager
    {
        public static ObjectManager Instance { get; private set; } = new ObjectManager();

        static ObjectManager()
        {
        }
    }
}
