using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Util
{
    class RNG
    {
        public static RNG Instance { get; private set; } = new RNG();
        public static Random random = new Random();

        static RNG()
        {
 
        }

         
    }
}
