using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Gameplay
{
    struct DamageInfo
    {
        public Core.GameObject damageDealer;
        public int value;

        public DamageInfo(Core.GameObject damageDealer, int value)
        {
            this.damageDealer = damageDealer;
            this.value = value;
        }
    }
}
