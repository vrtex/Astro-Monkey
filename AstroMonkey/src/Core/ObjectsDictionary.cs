using System;
using System.Collections.Generic;

namespace AstroMonkey.Core
{
    static class ObjectsDictionary
    {
        public static float upRotation = 0;
        public static float rightRotation = (float)Math.PI * 0.5f;
        public static float downRotation = (float)Math.PI;
        public static float leftRotation = -(float)Math.PI * 0.5f;
        //public static float leftRotation = (float)Math.PI * 1.5f;

        public static Dictionary<int, Tuple<Type, float>> objects = new Dictionary<int, Tuple<Type, float>>
        {

            // FLOOR BEGIN


            // floor platform
            [1] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatform01), upRotation),
            [2] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatform02), upRotation),
            [3] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatform03), upRotation),

            // floor dirty
            [5] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirt01), upRotation),
            [6] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirt02), upRotation),
            [7] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirt03), upRotation),
            [8] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirt04), upRotation),

            // floor crushed
            [9] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformCrush01), upRotation),
            [10] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformCrush02), upRotation),
            [11] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformCrush03), upRotation),
            [12] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformCrush04), upRotation),

            // floor crushed and dirty
            [13] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirtyCrush01), upRotation),
            [14] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirtyCrush02), upRotation),
            [15] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirtyCrush03), upRotation),
            [16] = new Tuple<Type, float>(typeof(Assets.Objects.FloorPlatformDirtyCrush04), upRotation),

            // floor crate
            [21] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate01), upRotation),
            [22] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate02), upRotation),
            [23] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate03), upRotation),
            [24] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate04), upRotation),
            [25] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate05), upRotation),
            [26] = new Tuple<Type, float>(typeof(Assets.Objects.FloorCrate06), upRotation),

            // exit level
            [41] = new Tuple<Type, float>(typeof(Assets.Objects.FloorExit), upRotation),

            // FLOOR END

            // FURNITURE BEGIN

            // wall
            [161] = new Tuple<Type, float>(typeof(Assets.Objects.Wall), upRotation),
            [181] = new Tuple<Type, float>(typeof(Assets.Objects.Wall), rightRotation),
            [201] = new Tuple<Type, float>(typeof(Assets.Objects.Wall), downRotation),
            [221] = new Tuple<Type, float>(typeof(Assets.Objects.Wall), leftRotation),

            // wall door
            [162] = new Tuple<Type, float>(typeof(Assets.Objects.WallDoor), upRotation),
            [182] = new Tuple<Type, float>(typeof(Assets.Objects.WallDoor), rightRotation),
            [202] = new Tuple<Type, float>(typeof(Assets.Objects.WallDoor), downRotation),
            [222] = new Tuple<Type, float>(typeof(Assets.Objects.WallDoor), leftRotation),

            // wall corner
            [163] = new Tuple<Type, float>(typeof(Assets.Objects.WallCorner), upRotation),
            [183] = new Tuple<Type, float>(typeof(Assets.Objects.WallCorner), rightRotation),
            [203] = new Tuple<Type, float>(typeof(Assets.Objects.WallCorner), downRotation),
            [223] = new Tuple<Type, float>(typeof(Assets.Objects.WallCorner), leftRotation),

            // door left
            [164] = new Tuple<Type, float>(typeof(Assets.Objects.DoorLeft), upRotation),
            [184] = new Tuple<Type, float>(typeof(Assets.Objects.DoorLeft), rightRotation),
            [204] = new Tuple<Type, float>(typeof(Assets.Objects.DoorLeft), downRotation),
            [224] = new Tuple<Type, float>(typeof(Assets.Objects.DoorLeft), leftRotation),


            // door right
            [165] = new Tuple<Type, float>(typeof(Assets.Objects.DoorRight), upRotation),
            [185] = new Tuple<Type, float>(typeof(Assets.Objects.DoorRight), rightRotation),
            [205] = new Tuple<Type, float>(typeof(Assets.Objects.DoorRight), downRotation),
            [225] = new Tuple<Type, float>(typeof(Assets.Objects.DoorRight), leftRotation),

            // half wall
            [166] = new Tuple<Type, float>(typeof(Assets.Objects.HalfWall), upRotation),
            [186] = new Tuple<Type, float>(typeof(Assets.Objects.HalfWall), rightRotation),
            [206] = new Tuple<Type, float>(typeof(Assets.Objects.HalfWall), downRotation),
            [226] = new Tuple<Type, float>(typeof(Assets.Objects.HalfWall), leftRotation),

            // Column
            [167] = new Tuple<Type, float>(typeof(Assets.Objects.Column), upRotation),
            [187] = new Tuple<Type, float>(typeof(Assets.Objects.Column), rightRotation),
            [207] = new Tuple<Type, float>(typeof(Assets.Objects.Column), downRotation),
            [227] = new Tuple<Type, float>(typeof(Assets.Objects.Column), leftRotation),

            // wall corner pillar
            [168] = new Tuple<Type, float>(typeof(Assets.Objects.WallCornerPhillar), upRotation),
            [188] = new Tuple<Type, float>(typeof(Assets.Objects.WallCornerPhillar), rightRotation),
            [208] = new Tuple<Type, float>(typeof(Assets.Objects.WallCornerPhillar), downRotation),
            [228] = new Tuple<Type, float>(typeof(Assets.Objects.WallCornerPhillar), leftRotation),

            // cockpit
            [169] = new Tuple<Type, float>(typeof(Assets.Objects.Cockpit), upRotation),
            [189] = new Tuple<Type, float>(typeof(Assets.Objects.Cockpit), rightRotation),
            [209] = new Tuple<Type, float>(typeof(Assets.Objects.Cockpit), downRotation),
            [229] = new Tuple<Type, float>(typeof(Assets.Objects.Cockpit), leftRotation),

            // fridge
            [170] = new Tuple<Type, float>(typeof(Assets.Objects.Fridge), upRotation),
            [190] = new Tuple<Type, float>(typeof(Assets.Objects.Fridge), rightRotation),
            [210] = new Tuple<Type, float>(typeof(Assets.Objects.Fridge), downRotation),
            [230] = new Tuple<Type, float>(typeof(Assets.Objects.Fridge), leftRotation),

            // armchair
            [171] = new Tuple<Type, float>(typeof(Assets.Objects.Armchair), upRotation),
            [191] = new Tuple<Type, float>(typeof(Assets.Objects.Armchair), rightRotation),
            [211] = new Tuple<Type, float>(typeof(Assets.Objects.Armchair), downRotation),
            [231] = new Tuple<Type, float>(typeof(Assets.Objects.Armchair), leftRotation),

            // case
            [172] = new Tuple<Type, float>(typeof(Assets.Objects.Case), upRotation),
            [192] = new Tuple<Type, float>(typeof(Assets.Objects.Case), rightRotation),
            [212] = new Tuple<Type, float>(typeof(Assets.Objects.Case), downRotation),
            [232] = new Tuple<Type, float>(typeof(Assets.Objects.Case), leftRotation),

            // case coffe
            [173] = new Tuple<Type, float>(typeof(Assets.Objects.CaseCaffe), upRotation),
            [193] = new Tuple<Type, float>(typeof(Assets.Objects.CaseCaffe), rightRotation),
            [213] = new Tuple<Type, float>(typeof(Assets.Objects.CaseCaffe), downRotation),
            [233] = new Tuple<Type, float>(typeof(Assets.Objects.CaseCaffe), leftRotation),

            // case micro
            [174] = new Tuple<Type, float>(typeof(Assets.Objects.CaseMicrowave), upRotation),
            [194] = new Tuple<Type, float>(typeof(Assets.Objects.CaseMicrowave), rightRotation),
            [214] = new Tuple<Type, float>(typeof(Assets.Objects.CaseMicrowave), downRotation),
            [234] = new Tuple<Type, float>(typeof(Assets.Objects.CaseMicrowave), leftRotation),

            // table
            [175] = new Tuple<Type, float>(typeof(Assets.Objects.Table), upRotation),
            [195] = new Tuple<Type, float>(typeof(Assets.Objects.Table), rightRotation),
            [215] = new Tuple<Type, float>(typeof(Assets.Objects.Table), downRotation),
            [235] = new Tuple<Type, float>(typeof(Assets.Objects.Table), leftRotation),

            // Neon sign
            [176] = new Tuple<Type, float>(typeof(Assets.Objects.NeonSign), upRotation),
            [196] = new Tuple<Type, float>(typeof(Assets.Objects.NeonSign), rightRotation),
            [216] = new Tuple<Type, float>(typeof(Assets.Objects.NeonSign), downRotation),
            [236] = new Tuple<Type, float>(typeof(Assets.Objects.NeonSign), leftRotation),

            // terminal on
            [177] = new Tuple<Type, float>(typeof(Assets.Objects.Terminal), upRotation),
            [197] = new Tuple<Type, float>(typeof(Assets.Objects.Terminal), rightRotation),
            [217] = new Tuple<Type, float>(typeof(Assets.Objects.Terminal), downRotation),
            [237] = new Tuple<Type, float>(typeof(Assets.Objects.Terminal), leftRotation),

            // terminal off
            [178] = new Tuple<Type, float>(typeof(Assets.Objects.TerminalOff), upRotation),
            [198] = new Tuple<Type, float>(typeof(Assets.Objects.TerminalOff), rightRotation),
            [218] = new Tuple<Type, float>(typeof(Assets.Objects.TerminalOff), downRotation),
            [238] = new Tuple<Type, float>(typeof(Assets.Objects.TerminalOff), leftRotation),

            // button
            [179] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWall), upRotation),
            [199] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWall), rightRotation),
            [219] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWall), downRotation),
            [239] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWall), leftRotation),

            // button clicked
            [180] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWallClicked), upRotation),
            [200] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWallClicked), rightRotation),
            [220] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWallClicked), downRotation),
            [240] = new Tuple<Type, float>(typeof(Assets.Objects.ButtonWallClicked), leftRotation),

			// wall 2
            [241] = new Tuple<Type, float>(typeof(Assets.Objects.Wall02), upRotation),
			[261] = new Tuple<Type, float>(typeof(Assets.Objects.Wall02), rightRotation),
			[281] = new Tuple<Type, float>(typeof(Assets.Objects.Wall02), downRotation),
			[301] = new Tuple<Type, float>(typeof(Assets.Objects.Wall02), leftRotation),

			// wall 3
            [242] = new Tuple<Type, float>(typeof(Assets.Objects.Wall03), upRotation),
			[262] = new Tuple<Type, float>(typeof(Assets.Objects.Wall03), rightRotation),
			[282] = new Tuple<Type, float>(typeof(Assets.Objects.Wall03), downRotation),
			[302] = new Tuple<Type, float>(typeof(Assets.Objects.Wall03), leftRotation),

			// wall 4
            [243] = new Tuple<Type, float>(typeof(Assets.Objects.Wall04), upRotation),
			[263] = new Tuple<Type, float>(typeof(Assets.Objects.Wall04), rightRotation),
			[283] = new Tuple<Type, float>(typeof(Assets.Objects.Wall04), downRotation),
			[303] = new Tuple<Type, float>(typeof(Assets.Objects.Wall04), leftRotation),

			// wall 5
            [244] = new Tuple<Type, float>(typeof(Assets.Objects.Wall05), upRotation),
			[264] = new Tuple<Type, float>(typeof(Assets.Objects.Wall05), rightRotation),
			[284] = new Tuple<Type, float>(typeof(Assets.Objects.Wall05), downRotation),
			[304] = new Tuple<Type, float>(typeof(Assets.Objects.Wall05), leftRotation),

			// wall 6
            [245] = new Tuple<Type, float>(typeof(Assets.Objects.Wall06), upRotation),
			[265] = new Tuple<Type, float>(typeof(Assets.Objects.Wall06), rightRotation),
			[285] = new Tuple<Type, float>(typeof(Assets.Objects.Wall06), downRotation),
			[305] = new Tuple<Type, float>(typeof(Assets.Objects.Wall06), leftRotation),

			// wall 7
            [246] = new Tuple<Type, float>(typeof(Assets.Objects.Wall07), upRotation),
			[266] = new Tuple<Type, float>(typeof(Assets.Objects.Wall07), rightRotation),
			[286] = new Tuple<Type, float>(typeof(Assets.Objects.Wall07), downRotation),
			[306] = new Tuple<Type, float>(typeof(Assets.Objects.Wall07), leftRotation),

            // FURNITURE END

            // ITEMS BEGIN

            // banana
            [461] = new Tuple<Type, float>(typeof(Assets.Objects.Banana), upRotation),
            [481] = new Tuple<Type, float>(typeof(Assets.Objects.Banana), rightRotation),
            [501] = new Tuple<Type, float>(typeof(Assets.Objects.Banana), downRotation),
            [521] = new Tuple<Type, float>(typeof(Assets.Objects.Banana), leftRotation),

            // nuts
            [462] = new Tuple<Type, float>(typeof(Assets.Objects.Nut), upRotation),
            [482] = new Tuple<Type, float>(typeof(Assets.Objects.Nut), rightRotation),
            [502] = new Tuple<Type, float>(typeof(Assets.Objects.Nut), downRotation),
            [522] = new Tuple<Type, float>(typeof(Assets.Objects.Nut), leftRotation),

            // Rifle ammo
            [463] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), upRotation),
            [483] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), rightRotation),
            [503] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), downRotation),
            [523] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), leftRotation),

            // Gun ammo
            [464] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), upRotation),
            [484] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), rightRotation),
            [504] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), downRotation),
            [524] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), leftRotation),

            // Launcher ammo
            [465] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoLuncher), upRotation),
            [485] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoLuncher), rightRotation),
            [505] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoLuncher), downRotation),
            [525] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoLuncher), leftRotation),

            // ITEMS END

            // CHARACTERS BEGIN

            // palyer
            [621] = new Tuple<Type, float>(typeof(Assets.Objects.Player), upRotation),
            [641] = new Tuple<Type, float>(typeof(Assets.Objects.Player), rightRotation),
            [661] = new Tuple<Type, float>(typeof(Assets.Objects.Player), downRotation),
            [681] = new Tuple<Type, float>(typeof(Assets.Objects.Player), leftRotation),

            // alien 1
            [622] = new Tuple<Type, float>(typeof(Assets.Objects.Alien01), upRotation),
            [642] = new Tuple<Type, float>(typeof(Assets.Objects.Alien01), rightRotation),
            [662] = new Tuple<Type, float>(typeof(Assets.Objects.Alien01), downRotation),
            [682] = new Tuple<Type, float>(typeof(Assets.Objects.Alien01), leftRotation),

            // alien 2
            [623] = new Tuple<Type, float>(typeof(Assets.Objects.Alien02), upRotation),
            [643] = new Tuple<Type, float>(typeof(Assets.Objects.Alien02), rightRotation),
            [663] = new Tuple<Type, float>(typeof(Assets.Objects.Alien02), downRotation),
            [683] = new Tuple<Type, float>(typeof(Assets.Objects.Alien02), leftRotation),

            // alien 3
            [624] = new Tuple<Type, float>(typeof(Assets.Objects.Alien03), upRotation),
            [644] = new Tuple<Type, float>(typeof(Assets.Objects.Alien03), rightRotation),
            [664] = new Tuple<Type, float>(typeof(Assets.Objects.Alien03), downRotation),
            [684] = new Tuple<Type, float>(typeof(Assets.Objects.Alien03), leftRotation)

            // CHARACTERS END
        };

		public static Dictionary<int, Util.NavPointPosition> navPos = new Dictionary<int, Util.NavPointPosition>
		{
            // wall
            [161] = Util.NavPointPosition.Up,
			[181] = Util.NavPointPosition.Right,
			[201] = Util.NavPointPosition.Down,
			[221] = Util.NavPointPosition.Left,

            // wall door
            [162] = Util.NavPointPosition.Up,
			[182] = Util.NavPointPosition.Right,
			[202] = Util.NavPointPosition.Down,
			[222] = Util.NavPointPosition.Left,

            // wall corner
            [163] = Util.NavPointPosition.UpLeft,
			[183] = Util.NavPointPosition.UpRight,
			[203] = Util.NavPointPosition.DownRight,
			[223] = Util.NavPointPosition.DownLeft,

           //door left
            [164] = Util.NavPointPosition.Right,
			[184] = Util.NavPointPosition.Down,
			[204] = Util.NavPointPosition.Left,
			[224] = Util.NavPointPosition.Up,

            // door right
            [165] = Util.NavPointPosition.Left,
			[185] = Util.NavPointPosition.Up,
			[205] = Util.NavPointPosition.Right,
			[225] = Util.NavPointPosition.Down,
			
            // half wall
            [166] = Util.NavPointPosition.None,
			[186] = Util.NavPointPosition.None,
			[206] = Util.NavPointPosition.None,
			[226] = Util.NavPointPosition.None,

            // Column
            [167] = Util.NavPointPosition.None,
			[187] = Util.NavPointPosition.None,
			[207] = Util.NavPointPosition.None,
			[227] = Util.NavPointPosition.None,

            // wall corner pillar
            [168] = Util.NavPointPosition.CornerUpLeft,
			[188] = Util.NavPointPosition.CornerUpRight,
			[208] = Util.NavPointPosition.CornerDownRight,
			[228] = Util.NavPointPosition.CornerDownLeft,

            // cockpit
            [169] = Util.NavPointPosition.None,
			[189] = Util.NavPointPosition.None,
			[209] = Util.NavPointPosition.None,
			[229] = Util.NavPointPosition.None,

            // fridge
            [170] = Util.NavPointPosition.Up,
			[190] = Util.NavPointPosition.Right,
			[210] = Util.NavPointPosition.Down,
			[230] = Util.NavPointPosition.Left,

            // armchair
            [171] = Util.NavPointPosition.None,
			[191] = Util.NavPointPosition.None,
			[211] = Util.NavPointPosition.None,
			[231] = Util.NavPointPosition.None,

            // case
            [172] = Util.NavPointPosition.Up,
			[192] = Util.NavPointPosition.Right,
			[212] = Util.NavPointPosition.Down,
			[232] = Util.NavPointPosition.Left,

            // case coffe
            [173] = Util.NavPointPosition.Up,
			[193] = Util.NavPointPosition.Right,
			[213] = Util.NavPointPosition.Down,
			[233] = Util.NavPointPosition.Left,

            // case micro
            [174] = Util.NavPointPosition.Up,
			[194] = Util.NavPointPosition.Right,
			[214] = Util.NavPointPosition.Down,
			[234] = Util.NavPointPosition.Left,

            // table
            [175] = Util.NavPointPosition.None,
			[195] = Util.NavPointPosition.None,
			[215] = Util.NavPointPosition.None,
			[235] = Util.NavPointPosition.None,

			// wall 2
			[241] = Util.NavPointPosition.Up,
			[261] = Util.NavPointPosition.Right,
			[281] = Util.NavPointPosition.Down,
			[301] = Util.NavPointPosition.Left,

			// wall 3
            [242] = Util.NavPointPosition.Up,
			[262] = Util.NavPointPosition.Right,
			[282] = Util.NavPointPosition.Down,
			[302] = Util.NavPointPosition.Left,

			// wall 4
            [243] = Util.NavPointPosition.Up,
			[263] = Util.NavPointPosition.Right,
			[283] = Util.NavPointPosition.Down,
			[303] = Util.NavPointPosition.Left,

			// wall 5
            [244] = Util.NavPointPosition.Up,
			[264] = Util.NavPointPosition.Right,
			[284] = Util.NavPointPosition.Down,
			[304] = Util.NavPointPosition.Left,

			// wall 6
            [245] = Util.NavPointPosition.Up,
			[265] = Util.NavPointPosition.Right,
			[285] = Util.NavPointPosition.Down,
			[305] = Util.NavPointPosition.Left,

			// wall 7
            [246] = Util.NavPointPosition.Up,
			[266] = Util.NavPointPosition.Right,
			[286] = Util.NavPointPosition.Down,
			[306] = Util.NavPointPosition.Left,
		};
	}
}
