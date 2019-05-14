using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Util
{
	public enum Anchor
	{
		LeftTop			= 0,
		MiddleTop		= 1,
		RightTop		= 2,
		LeftCenter		= 3,
		Center			= 4,
		RightCenter		= 5,
		LeftBottom		= 6,
		MiddleBottom	= 7,
		MiddleRight		= 8
	}

	public enum NavPointPosition
	{
		None				= 0,
		UpLeft				= 1,
		UpRight				= 2,
		Up					= 3,
		DownRight			= 4,
		Right				= 6,
		CornerUpRight		= 7,
		DownLeft			= 8,
		Left				= 9,
		CornerUpLeft		= 11,
		Down				= 12,
		CornerDownLeft		= 13,
		CornerDownRight		= 14,
		All					= 15
	}
}
