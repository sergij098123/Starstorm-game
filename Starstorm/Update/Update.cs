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
                _isF11Pressed = false;
            
            Initialize_Hitbox.InitializeStartMenu();
        }
    }
}