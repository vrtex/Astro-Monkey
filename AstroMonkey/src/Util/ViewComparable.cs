using System.Collections.Generic;
using AstroMonkey.Core;

namespace AstroMonkey.Util
{
    class ViewComparable: IComparer<GameObject>
    {
        public int Compare(GameObject a, GameObject b)
        {
            int val = (int)(a.transform.position.Y - b.transform.position.Y);
            if(val == 0) val = (int)(a.transform.position.X - b.transform.position.X);
            return val;
        }
    }
}
