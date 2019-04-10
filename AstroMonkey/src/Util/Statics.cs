using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Util
{
    class Statics
    {
        public static bool IsNearlyEqual(float a, float b, float epsilon = 0.0001f)
        {
            return Math.Abs(a - b) < epsilon;
        }

        public static bool IsNearlyEqual(double a, double b, double epsilon = 0.0001f)
        {
            return Math.Abs(a - b) < epsilon;
        }

		public static Color AstroColor(int color)
		{
			switch(color)
			{
				case 9:
				{
					return new Color(255, 174, 0);
				}
				case 28:
				{
					return new Color(215, 215, 215);
				}
			}

			return Color.Fuchsia;
		}
    }
}
