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
    }
}
