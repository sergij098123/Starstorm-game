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

namespace Starstorm.Update
{
    class STUpdate
    {
        public static void Update(bool _isF11Pressed, bool _isFullscreen, GraphicsDevice GraphicsDevice, GraphicsDeviceManager _graphics, ContentManager Content, GameWindow Window, KeyboardState keyboardState){
            if (keyboardState.IsKeyDown(Keys.F11))
            {
                if (!_isF11Pressed)
                {
                    _isF11Pressed = true;
                    _isFullscreen = !_isFullscreen;

                    if (_isFullscreen)
                    {
                        // Увімкнення повноекранного режиму
                        _graphics.IsFullScreen = true;
                        _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
                        _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
                        StartMenu.Background.scale = GraphicsDevice.Adapter.CurrentDisplayMode.Width / StartMenu.BackgroundSprite.texture.Width;
                        Font.Fifaks_variant = Font.Fifaks144;
                    }
                    else
                    {
                        // Повернення віконного режиму
                        _graphics.IsFullScreen = false;
                        _graphics.PreferredBackBufferWidth = 800;
                        _graphics.PreferredBackBufferHeight = 480;
                        StartMenu.Background.scale = GraphicsDevice.Viewport.Width / StartMenu.BackgroundSprite.texture.Width;
                        Font.Fifaks_variant = Font.Fifaks24;                
                    }

                    _graphics.ApplyChanges();
                }
            }
            else
            {
                // Скидаємо стан, якщо клавішу відпустили
                _isF11Pressed = false;
            }
            Var.StartMenu.Position.MainMenu_Text_1 = new Vector2(Var.StartMenu.Screen.width / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, Var.StartMenu.Screen.height / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - Var.StartMenu.Screen.height / 4);
            //Console.WriteLine(StartMenu.Button.Button1.scale);
            if(Hitboxes.StartMenu.Button.Button1.Contains(Mouse.GetState().Position))
            {
                if(StartMenu.Button.Button1.scale == 3.5f){
                    StartMenu.Button.Button1.scale = 3.65f;
                    StartMenu.Button.Button2.scale = 3.65f;
                }
                if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                    StartMenu.Button.Button1.Sprite = Sprites.Sprites.Button.StartMenu.Frame2;
                    StartMenu.Button.Button2.Sprite = Sprites.Sprites.Button2.StartMenu.Frame2;
                    //Effects.CorrectEffect.Play();
                }
                else{
                    StartMenu.Button.Button1.Sprite = Sprites.Sprites.Button.StartMenu.Frame1;
                    StartMenu.Button.Button2.Sprite = Sprites.Sprites.Button2.StartMenu.Frame1;
                }
                //Console.WriteLine("Button1");
            }
            else{
                StartMenu.Button.Button1.scale = 3.5f;
                StartMenu.Button.Button2.scale = 3.5f;
            }
            
            StartMenu.Button.Button1.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - Var.StartMenu.Screen.height / 8);
            StartMenu.Button.Button2.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - Var.StartMenu.Screen.height / 8);
            StartMenu.Button_2.Button1.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + Var.StartMenu.Screen.height / 8 * 2.5f);
            StartMenu.Button_2.Button2.position = new Vector2(Var.StartMenu.Screen.width / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, Var.StartMenu.Screen.height / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + Var.StartMenu.Screen.height / 8 * 2.5f);
            
            Initialize_Hitbox.InitializeStartMenu();
        }
    }
}