using Microsoft.Xna.Framework;
using Starstorm;
using Starstorm.Sound;
using Microsoft.Xna.Framework.Audio;
using Starstorm.Sprites;
using Starstorm.Sprite;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Starstorm.Objects;
using Starstorm.Fonts;
using Starstorm.Logic;
using Starstorm.Initialize;
using Starstorm.Variables;

namespace Starstorm.Initialize
{
    public class Game1Initialize
    {
        private ContentManager Content;
        private GraphicsDevice GraphicsDevice;
        public static int screenWidth;
        public static int screenHeight;
        // Метод для ініціалізації з GraphicsDevice
        public void Main(IServiceProvider serviceProvider, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            // Ініціалізуємо GraphicsDevice
            GraphicsDevice = graphicsDevice;

            // Ініціалізація ContentManager
            Content = new ContentManager(serviceProvider, "Content");
            Content.RootDirectory = "Content";

            // Завантаження музики та створення об'єкта StartMenu
            var Songs = new Songs(Content, serviceProvider);
            Var.StartMenu.Screen.height = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            Var.StartMenu.Screen.width = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;

            Effects.CorrectEffect = Content.Load<SoundEffect>("correct_sfx");

            StartMenu.BackgroundSprite = new Sprite.Sprite(Content.Load<Texture2D>("Start.BG.Image"), Color.White, SpriteEffects.None);
            StartMenu.Background = new Objects.Object(
                new Vector2(0, 0),
                //new Vector2(
                //    (GraphicsDevice.Viewport.Width - StartMenu.BackgroundSprite.texture.Width) / 2,
                //    (GraphicsDevice.Viewport.Height - StartMenu.BackgroundSprite.texture.Height) / 2
                //),
                0f,
                GraphicsDevice.Viewport.Width / (float)StartMenu.BackgroundSprite.texture.Width,    
                new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), 
                StartMenu.BackgroundSprite
                //Sprites.Sprites.Button.StartMenu.Frame1
            );

            Objects.StartMenu.Button.Button1 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                //new Rectangle(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height / 2, Sprites.Sprites.Button.StartMenu.Frame1.texture.Width, Sprites.Sprites.Button.StartMenu.Frame1.texture.Height),
                Sprites.Sprites.Button.StartMenu.Frame1
                //StartMenu.BackgroundSprite
            );
            Objects.StartMenu.Button.Button2 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                Sprites.Sprites.Button2.StartMenu.Frame1
            );
            

            Objects.StartMenu.Button_2.Button1 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + screenHeight / 8 * 2.5f),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                Sprites.Sprites.Button.StartMenu.Frame1
            );
            Objects.StartMenu.Button_2.Button2 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height + screenHeight / 8 * 2.5f),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                Sprites.Sprites.Button2.StartMenu.Frame1
            );

            Objects.StartMenu.Button_3.Button1 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                Sprites.Sprites.Button.StartMenu.Frame1
            );
            Objects.StartMenu.Button_3.Button2 = new Objects.Object(
                new Vector2(screenWidth / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Width / 2 * 3.5f, screenHeight / 2 - Sprites.Sprites.Button.StartMenu.Frame1.texture.Height - screenHeight / 8),
                0f,
                3.5f,
                new Rectangle(0,0,screenHeight,screenWidth),
                Sprites.Sprites.Button2.StartMenu.Frame1
            );

            MediaPlayer.Play(Songs.StartMenuBackgroundMusic);
            MediaPlayer.IsRepeating = true; // Для повторення музики
        }
    }
}