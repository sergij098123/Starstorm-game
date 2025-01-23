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
    private int screenWidth;
    private int screenHeight;
    private SpriteFont Fifaks_variant;
    private Vector2 MainMenu_Text_1_Pos;
    protected override void Initialize()
    {
        var Game1Initialize = new Game1Initialize();
        _graphics.IsFullScreen = true;
        Game1Initialize.Main(this.Services, _graphics.GraphicsDevice);
        Font.Fifaks24 = Content.Load<SpriteFont>("Fifaks24.Font");
        Font.Fifaks92 = Content.Load<SpriteFont>("Fifaks92.Font");
        Fifaks_variant = Font.Fifaks24;
        MainMenu_Text_1_Pos = new Vector2(0, 0);
        base.Initialize();
        screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
    }
    private bool _isFullscreen = false; // Чи включено повноекранний режим
    private bool _isF11Pressed = false; // Чи зафіксовано натискання F11
    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        // Перемикаємо режим, якщо F11 натиснута, але не утримується
        if (keyboardState.IsKeyDown(Keys.F11))
        {
            MainMenu_Text_1_Pos = new Vector2(screenWidth / 2 - Fifaks_variant.MeasureString("Starstorm").X / 2, screenHeight / 2 - Fifaks_variant.MeasureString("Starstorm").Y / 2);
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
                    Fifaks_variant = Font.Fifaks92;
                }
                else
                {
                    // Повернення віконного режиму
                    _graphics.IsFullScreen = false;
                    _graphics.PreferredBackBufferWidth = 800; // Стандартна ширина (замінити на бажану)
                    _graphics.PreferredBackBufferHeight = 600; // Стандартна висота (замінити на бажану)
                    StartMenu.Background.scale = GraphicsDevice.Viewport.Width / StartMenu.BackgroundSprite.texture.Width;
                    Fifaks_variant = Font.Fifaks24;
                }

                _graphics.ApplyChanges();
            }
        }
        else
        {
            // Скидаємо стан, якщо клавішу відпустили
            _isF11Pressed = false;
        }



        //Console.WriteLine("X: " + Mouse.GetState().X + " Y: " + Mouse.GetState().Y);

        MouseState mouse = Mouse.GetState();
        Point mousePosition = new Point(mouse.X, mouse.Y);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        StartMenu.Background.Draw(_spriteBatch);
        _spriteBatch.DrawString(Fifaks_variant, "Starstorm", MainMenu_Text_1_Pos, Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
