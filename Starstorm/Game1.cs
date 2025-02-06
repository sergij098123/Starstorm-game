﻿using System.Collections.Generic;
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
    public Vector2 MainMenu_Text_1_Pos = new Vector2(0, 0);
    protected override void Initialize()
    {
        var Game1Initialize = new Game1Initialize();
        _graphics.IsFullScreen = true;
        screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;

        Font.Fifaks24 = Content.Load<SpriteFont>("Fifaks24.Font");
        Font.Fifaks36 = Content.Load<SpriteFont>("Fifaks36.Font");
        Font.Fifaks92 = Content.Load<SpriteFont>("Fifaks92.Font");
        Font.Fifaks144 = Content.Load<SpriteFont>("Fifaks144.Font");
        Font.Fifaks_variant = Font.Fifaks92;
        
        MainMenu_Text_1_Pos = new Vector2(screenWidth / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, screenHeight / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - screenHeight / 4);
        Sprites.Sprites.Button.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F1"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F2"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button2.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F1"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button2.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F2"), Color.White, SpriteEffects.None);
        base.Initialize();
        screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        Window.AllowUserResizing = true;

        Game1Initialize.Main(this.Services, _graphics.GraphicsDevice);
        Initialize_Hitbox.InitializeStartMenu();

        StartMenu.Background.scale = GraphicsDevice.Adapter.CurrentDisplayMode.Width / StartMenu.BackgroundSprite.texture.Width;
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
        if (Hitboxes.StartMenu.Button.Button2.Contains(Mouse.GetState().Position))
        {
            if(StartMenu.Button_2.Button1.scale == 3.5f){
                StartMenu.Button_2.Button1.scale = 3.65f;
                StartMenu.Button_2.Button2.scale = 3.65f;
            }
            if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                Effects.CorrectEffect.Play();
                Thread.Sleep(Effects.CorrectEffect.Duration);
                Exit();
            }
            //Console.WriteLine("Button1");
        } 
        else{
            StartMenu.Button_2.Button1.scale = 3.5f;
            StartMenu.Button_2.Button2.scale = 3.5f;
        }
        StartMenu.Button.Button1.position = new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8);
        StartMenu.Button.Button2.position = new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button.Button1.scale, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8);
        StartMenu.Button_2.Button1.position = new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + screenHeight / 8 * 2.5f);
        StartMenu.Button_2.Button2.position = new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * StartMenu.Button_2.Button1.scale, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + screenHeight / 8 * 2.5f);
        
        Initialize_Hitbox.InitializeStartMenu();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
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
        base.Draw(gameTime);
    }
}