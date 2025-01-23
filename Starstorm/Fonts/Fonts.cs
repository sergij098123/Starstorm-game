using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace Starstorm.Fonts{
    class Font{
        public static SpriteFont Fifaks24;
        public static SpriteFont Fifaks92;
        public Font(ContentManager Content){
            Fifaks24 = Content.Load<SpriteFont>("Fifaks24.Font");
            Fifaks92 = Content.Load<SpriteFont>("Fifaks92.Font");
        }
    }
}