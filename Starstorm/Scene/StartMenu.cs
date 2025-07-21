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
using Starstorm.Variables;

namespace Starstorm.Draw{
    class StartMenuST{
        public static void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight, Vector2 MainMenu_Text_1_Pos, GraphicsDevice GraphicsDevice)
        {
            GraphicsDevice.Clear(Color.Black);
            StartMenu.Background.Draw(_spriteBatch);
            StartMenu.Button.Button1.Draw(_spriteBatch);
            StartMenu.Button_2.Button1.Draw(_spriteBatch);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            _spriteBatch.DrawString(Font.Fifaks_variant, "Starstorm", MainMenu_Text_1_Pos, Color.White);
            _spriteBatch.DrawString(Font.Fifaks36, "Start", new Vector2(screenWidth / 2 - Font.Fifaks36.MeasureString("Start").X / 2 - screenWidth / 48, screenHeight / 3 - Font.Fifaks36.MeasureString("Start").Y + screenHeight / 5 + screenHeight / 25 - screenHeight / 8), Color.White);
            _spriteBatch.DrawString(Font.Fifaks36, "Exit", new Vector2(screenWidth / 2 - Font.Fifaks36.MeasureString("Exit").X / 2 - screenWidth / 48, screenHeight / 3 - Font.Fifaks36.MeasureString("Exit").Y + screenHeight / 5 + screenHeight / 25 + screenHeight / 8 * 2.5f), Color.White);
            _spriteBatch.End();

            StartMenu.Button.Button2.Draw(_spriteBatch);
            StartMenu.Button_2.Button2.Draw(_spriteBatch);
        }
        public static void Update(){
            if(Hitboxes.StartMenu.Button.Button1.Contains(Mouse.GetState().Position))
            {
                if(StartMenu.Button.Button1.scale == 3.5f){
                    StartMenu.Button.Button1.scale = 3.65f;
                    StartMenu.Button.Button2.scale = 3.65f;
                }
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    StartMenu.Button.Button1.Sprite = Sprites.Sprites.Button.StartMenu.Frame2;
                    StartMenu.Button.Button2.Sprite = Sprites.Sprites.Button2.StartMenu.Frame2;
                    Var.scene = "Test";
                    //Effects.CorrectEffect.Play();
                }
                else
                {
                    StartMenu.Button.Button1.Sprite = Sprites.Sprites.Button.StartMenu.Frame1;
                    StartMenu.Button.Button2.Sprite = Sprites.Sprites.Button2.StartMenu.Frame1;
                }
                //Console.WriteLine("Button1");
            }
            else{
                StartMenu.Button.Button1.scale = 3.5f;
                StartMenu.Button.Button2.scale = 3.5f;
            }
            if (Hitboxes.StartMenu.Button.Button2.Contains(Mouse.GetState().Position))
            {
                if(StartMenu.Button_2.Button1.scale == 3.5f){
                    StartMenu.Button_2.Button1.scale = 3.65f;
                    StartMenu.Button_2.Button2.scale = 3.65f;
                }
                if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                    Effects.CorrectEffect.Play();
                    Thread.Sleep(Effects.CorrectEffect.Duration);
                    Var.isExit = true;
                }
                //Console.WriteLine("Button1");
            } 
            else{
                StartMenu.Button_2.Button1.scale = 3.5f;
                StartMenu.Button_2.Button2.scale = 3.5f;
            }
            Var.StartMenu.Position.MainMenu_Text_1 = new Vector2(Var.StartMenu.Screen.width / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, Var.StartMenu.Screen.height / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - Var.StartMenu.Screen.height / 4);

            StartMenu.Button.Button1.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - Var.StartMenu.Screen.height / 8);
            StartMenu.Button.Button2.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - Var.StartMenu.Screen.height / 8);
            StartMenu.Button_2.Button1.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + Var.StartMenu.Screen.height / 8 * 2.5f);
            StartMenu.Button_2.Button2.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + Var.StartMenu.Screen.height / 8 * 2.5f);
        }
    }
}