using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Starstorm.Logic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;
using Starstorm.Sound;
using Starstorm.Objects;
using Starstorm.Initialize;
using System.Runtime.Serialization;
using Starstorm.Fonts;
using Starstorm.Logic.Hitboxes;
using System.Threading;
using Starstorm.Draw;

namespace Starstorm.Variables
{
    public class Var
    {
        public class Player
        {
            public static int direction = 1; // 0 = up, 1 = down, 2 = left, 3 = right
            public static bool isMoving = false;
        }
        public static GameTime GameTime;
        public class StartMenu
        {
            public static class Screen
            {
                public static int width;
                public static int height;
            }
            public static class Position
            {
                public static Vector2 MainMenu_Text_1 = new Vector2(0, 0);
            }
        }
        public static class Test
        {
            public static Vector2 PlayerShift = new Vector2(0, 0);
        }
        public static string scene = "StartMenu";
        public static bool isExit = false;
    }
}