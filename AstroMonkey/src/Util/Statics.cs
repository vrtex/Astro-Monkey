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
        public static float musicVolume = 1f;
        public static float soundVolume = 1f;

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

        public static int Map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static float Map(float x, float in_min, float in_max, float out_min, float out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public struct Colors
        {
            static Colors()
            {
                Colors.GOLD = new Color(242, 209, 0);
                Colors.YELLOW = new Color(255, 239, 68);
                Colors.INTENSIVE_BLUE = new Color(36, 36, 252);
                Colors.BLUE = new Color(32, 24, 184);
                Colors.WHITE_2 = new Color(207, 207, 207);
                Colors.BLACK = new Color(0, 0, 0);
                Colors.RED_BROWN_1 = new Color(96, 24, 4);
                Colors.RED_BROWN_2 = new Color(72, 0, 0);
                Colors.DIRTY_GREEN = new Color(64, 124, 46);
                Colors.ORANGE = new Color(255, 174, 0);
                Colors.INTENSIVE_GREEN = new Color(15, 255, 0);
                Colors.PINKEST_PINK_OF_THE_PINKEST_PINK = new Color(255, 15, 252);
                Colors.OLIVE = new Color(199, 176, 49);
                Colors.DARK_RED = new Color(130, 0, 0);
                Colors.BROWN_6 = new Color(52, 32, 12);
                Colors.GRAY_2 = new Color(104, 110, 121);
                Colors.GRAY_3 = new Color(76, 80, 88);
                Colors.GRAY_4 = new Color(64, 68, 76);
                Colors.GRAY_5 = new Color(56, 60, 68);
                Colors.GRAY_6 = new Color(40, 40, 48);
                Colors.BROWN_3 = new Color(105, 68, 27);
                Colors.BROWN_4 = new Color(104, 60, 36);
                Colors.BROWN_5 = new Color(84, 40, 32);
                Colors.BROWN_7 = new Color(40,24,12);
                Colors.BROWN_1 = new Color(152, 92, 64);
                Colors.PURPLE_1 = new Color(136, 64, 156);
                Colors.PURPLE_2 = new Color(104, 48, 120);
                Colors.PURPLE_3 = new Color(72, 28, 80);
                Colors.WHITE_1 = new Color(215, 215, 215);
                Colors.GRAY_1 = new Color(154, 154, 154);
                Colors.LIGHT_YELLOW = new Color(255, 232, 123);
                Colors.BROWN_2 = new Color(115, 56, 0);
            }
            
            public static Color GOLD { get; }
            public static Color YELLOW { get; }
            public static Color INTENSIVE_BLUE { get; }
            public static Color BLUE { get; }
            public static Color WHITE_2 { get; }
            public static Color BLACK { get; }
            public static Color RED_BROWN_1 { get; }
            public static Color RED_BROWN_2 { get; }
            public static Color DIRTY_GREEN { get; }
            public static Color ORANGE { get; }
            public static Color INTENSIVE_GREEN { get; }
            public static Color PINKEST_PINK_OF_THE_PINKEST_PINK { get; }
            public static Color OLIVE { get; }
            public static Color DARK_RED { get; }
            public static Color BROWN_6 { get; }
            public static Color GRAY_2 { get; }
            public static Color GRAY_3 { get; }
            public static Color GRAY_4 { get; }
            public static Color GRAY_5 { get; }
            public static Color GRAY_6 { get; }
            public static Color BROWN_3 { get; }
            public static Color BROWN_4 { get; }
            public static Color BROWN_5 { get; }
            public static Color BROWN_7 { get; }
            public static Color BROWN_1 { get; }
            public static Color PURPLE_1 { get; }
            public static Color PURPLE_2 { get; }
            public static Color PURPLE_3 { get; }
            public static Color WHITE_1 { get; }
            public static Color GRAY_1 { get; }
            public static Color LIGHT_YELLOW { get; }
            public static Color BROWN_2 { get; }


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
