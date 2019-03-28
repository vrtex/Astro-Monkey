using System;
using System.Collections.Generic;
using AstroMonkey.Core;

namespace AstroMonkey.Util
{
    class ViewComparable: IComparer<GameObject>
    {
        public int Compare(GameObject a, GameObject b)
        {
            return (int)(a.transform.position.Y - b.transform.position.Y);
        }
    }
}
