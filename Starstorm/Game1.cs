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
    //Here`s the sprites initialization
    Sprite _StartUI_Foreground_left;
    Song _backgroundMusic;
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Initialize()
    {
        _StartUI_Foreground_left = new Sprite(Content.Load<Texture2D>("Start.FG.Left"), new Vector2(0, 0), 3.8f, Color.White);
        _backgroundMusic = Content.Load<Song>("test_bg_sound");
        // TODO: Add your initialization logic here
        MediaPlayer.Play(_backgroundMusic);
        MediaPlayer.IsRepeating = true; // Для повторення музики
        base.Initialize();
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if(Keyboard.GetState().IsKeyDown(Keys.F11))
        {
            _graphics.ToggleFullScreen();
        }   
        // TODO: Add your update logic here

        
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black); // Чорний фон для смуг

        // Співвідношення сторін екрану та зображення
        float screenAspect = _graphics.PreferredBackBufferWidth / (float)_graphics.PreferredBackBufferHeight;
        float imageAspect = _StartUI_Foreground_left.texture.Width / (float)_StartUI_Foreground_left.texture.Height;

        // Логування для перевірки
        Console.WriteLine("Screen Aspect: " + screenAspect);
        Console.WriteLine("Image Aspect: " + imageAspect);

        // Розмір і позиція зображення
        Rectangle drawRectangle;

        if (imageAspect > screenAspect)
        {
            // Зображення ширше, ніж екран
            int scaledHeight = (int)(_graphics.PreferredBackBufferWidth / imageAspect);
            int verticalMargin = (_graphics.PreferredBackBufferHeight - scaledHeight) / 2;
            drawRectangle = new Rectangle(0, verticalMargin, _graphics.PreferredBackBufferWidth, scaledHeight);
        }
        else
        {
            // Зображення вужче, ніж екран
            int scaledWidth = (int)(_graphics.PreferredBackBufferHeight * imageAspect);
            int horizontalMargin = (_graphics.PreferredBackBufferWidth - scaledWidth) / 2;
            drawRectangle = new Rectangle(horizontalMargin, 0, scaledWidth, _graphics.PreferredBackBufferHeight);
        }

        // Логування для перевірки розміру
        Console.WriteLine("DrawRectangle: " + drawRectangle);

        // Малюємо зображення
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _StartUI_Foreground_left.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
