using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Starstorm.Sprite;
using Starstorm.Logic;
using Microsoft.Xna.Framework.Content;

namespace Starstorm.Objects{
    class StartMenu{
        public ContentManager Content;
        public static Object Background;
        public static Sprite.Sprite BackgroundSprite;
        public StartMenu(ContentManager content)
        {
            Content = content;
        }
        public class Button{
            public static Object Button1;
            public static Object Button2;
        }
    }
}