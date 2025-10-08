using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace Starstorm.Sprites
{
    class Sprites
    {
        public class Button
        {
            public class StartMenu
            {
                public static Sprite.Sprite Frame1 = null;
                public static Sprite.Sprite Frame2 = null;
            }
        }
        public class Button2
        {
            public class StartMenu
            {
                public static Sprite.Sprite Frame1;
                public static Sprite.Sprite Frame2;
            }
        }
        public class Placeholder
        {
            public static Sprite.Sprite pc1;
            public static Sprite.Sprite pc2;
            public static Sprite.Sprite pc3;
            public static Sprite.Sprite pc4;
            public static Sprite.Sprite pc5;
        }
    }
}