using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Starstorm.Sprite;
using Starstorm.Logic;
using Microsoft.Xna.Framework.Content;

namespace Starstorm.Objects
{
    class StartMenu
    {
        public ContentManager Content;
        public static Object Background;
        public static Sprite.Sprite BackgroundSprite;
        public StartMenu(ContentManager content)
        {
            Content = content;
        }
        public class Button
        {
            public static Object Button1;
            public static Object Button2;
        }
        public class Button_2
        {
            public static Object Button1;
            public static Object Button2;
        }
        public class Button_3
        {
            public static Object Button1;
            public static Object Button2;
        }
    }
    public class Test
    {
        public ContentManager Content;
        public Test(ContentManager content)
        {
            Content = content;
        }
        public static Object BG;
        public static object Character;
    }
    public class Placeholder
    {
        public static object pc1;
        public static object pc2;
        public static object pc3;
        public static object pc4;
        public static object pc5;
    }
}