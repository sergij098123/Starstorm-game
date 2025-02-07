using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Starstorm.Logic;
using Starstorm.Old;
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
using Starstorm.Variables;

namespace Starstorm.Draw{
    class StartMenu_Draw{
        public static void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight, Vector2 MainMenu_Text_1_Pos, GraphicsDevice GraphicsDevice, GameTime gameTime){
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            StartMenu.Background.Draw(_spriteBatch);
            _spriteBatch.DrawString(Font.Fifaks_variant, "Starstorm", MainMenu_Text_1_Pos, Color.White);

            StartMenu.Button.Button1.Draw(_spriteBatch);
            _spriteBatch.DrawString(Font.Fifaks36, "Start", new Vector2(screenWidth / 2 - Font.Fifaks36.MeasureString("Start").X / 2 - screenWidth / 48, screenHeight / 3 - Font.Fifaks36.MeasureString("Start").Y + screenHeight / 5 + screenHeight / 25 - screenHeight / 8), Color.White);
            StartMenu.Button.Button2.Draw(_spriteBatch);

            StartMenu.Button_2.Button1.Draw(_spriteBatch);
            _spriteBatch.DrawString(Font.Fifaks36, "Exit", new Vector2(screenWidth / 2 - Font.Fifaks36.MeasureString("Exit").X / 2 - screenWidth / 48, screenHeight / 3 - Font.Fifaks36.MeasureString("Exit").Y + screenHeight / 5 + screenHeight / 25 + screenHeight / 8 * 2.5f), Color.White);
            StartMenu.Button_2.Button2.Draw(_spriteBatch);

            _spriteBatch.End();
        }
    }
}