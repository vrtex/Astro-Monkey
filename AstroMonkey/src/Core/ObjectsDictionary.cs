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

            // Gun ammo
            [463] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), upRotation),
            [483] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), rightRotation),
            [503] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), downRotation),
            [523] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoGun), leftRotation),

            // Rifle ammo
            [464] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), upRotation),
            [484] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), rightRotation),
            [504] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), downRotation),
            [524] = new Tuple<Type, float>(typeof(Assets.Objects.AmmoRiffle), leftRotation),

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
    }
}
