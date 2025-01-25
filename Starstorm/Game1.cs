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

namespace Starstorm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    public int screenWidth;
    public int screenHeight;
    public Vector2 MainMenu_Text_1_Pos;
    protected override void Initialize()
    {
        var Game1Initialize = new Game1Initialize();
        _graphics.IsFullScreen = true;
        Game1Initialize.Main(this.Services, _graphics.GraphicsDevice);
        Font.Fifaks_variant = Font.Fifaks24;
        MainMenu_Text_1_Pos = new Vector2(0, 0);
        base.Initialize();
        screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        Window.AllowUserResizing = true;
        
        StartMenu.Background.scale = GraphicsDevice.Adapter.CurrentDisplayMode.Width / StartMenu.BackgroundSprite.texture.Width;
        Font.Fifaks_variant = Font.Fifaks92;
        MainMenu_Text_1_Pos = new Vector2(screenWidth / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, screenHeight / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - screenHeight / 4);
    }
    private bool _isFullscreen = false; // Чи включено повноекранний режим
    private bool _isF11Pressed = false; // Чи зафіксовано натискання F11
    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        // Перемикаємо режим, якщо F11 натиснута, але не утримується
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
        MainMenu_Text_1_Pos = new Vector2(screenWidth / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, screenHeight / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - screenHeight / 4);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        Objects.StartMenu.Button.Button1.rectangle = new Rectangle(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height / 2, Sprites.Sprites.Button.StartMenu.Frame1.texture.Width, Sprites.Sprites.Button.StartMenu.Frame1.texture.Height);
        Objects.StartMenu.Button.Button1.position = new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame2.texture.Width / 2, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame2.texture.Height / 2);
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        StartMenu.Background.Draw(_spriteBatch);
        _spriteBatch.DrawString(Font.Fifaks_variant, "Starstorm", MainMenu_Text_1_Pos, Color.White);
        Objects.StartMenu.Button.Button1.Draw(_spriteBatch);
        _spriteBatch.DrawString(Font.Fifaks24, "Start", new Vector2(Objects.StartMenu.Button.Button1.rectangle.X + Objects.StartMenu.Button.Button1.rectangle.Width / 2 - Font.Fifaks_variant.MeasureString("Start").X / 2, Objects.StartMenu.Button.Button1.rectangle.Y + Objects.StartMenu.Button.Button1.rectangle.Height / 2 - Font.Fifaks_variant.MeasureString("Start").Y / 2), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
