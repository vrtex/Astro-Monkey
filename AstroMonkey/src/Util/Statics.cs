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

        public static bool IsNearlyEqual(Vector2 a, Vector2 b, float epsilon = 0.0001f)
        {
            return IsNearlyEqual(a.X, a.Y, epsilon) && IsNearlyEqual(a.X, a.Y, epsilon);
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

		public static Vector2 GetResolition(int resolution)
		{
			if(resolution == 0)
			{
				return new Vector2(1024, 768);
			}
			else if(resolution == 1)
			{
				return new Vector2(1280, 720);
			}
			else if(resolution == 2)
			{
				return new Vector2(1400, 1050);
			}
			else if(resolution == 3)
			{
				return new Vector2(1680, 1050);
			}
			else if(resolution == 4)
			{
				return new Vector2(1920, 1080);
			}
			else if(resolution == 5)
			{
				return new Vector2(1920, 1200);
			}
			return new Vector2(800, 600);
		}
    }
}
