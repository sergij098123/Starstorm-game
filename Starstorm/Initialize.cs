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

namespace Starstorm.Initialize
{
    public class Game1Initialize
    {
        private ContentManager Content;
        private GraphicsDevice GraphicsDevice;

        // Метод для ініціалізації з GraphicsDevice
        public void Main(IServiceProvider serviceProvider, GraphicsDevice graphicsDevice)
        {
            // Ініціалізуємо GraphicsDevice
            GraphicsDevice = graphicsDevice;

            // Ініціалізація ContentManager
            Content = new ContentManager(serviceProvider, "Content");
            Content.RootDirectory = "Content";

            // Завантаження музики та створення об'єкта StartMenu
            var Songs = new Songs(Content, serviceProvider);

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
            );

            Sprites.Sprites.Button.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F1"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Button.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F2"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Button2.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F1"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Button2.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F2"), Color.White, SpriteEffects.None);

            Objects.StartMenu.Button.Button1 = new Objects.Object(
                new Vector2(0, 0),
                0f,
                5f,
                new Rectangle(0, 0, 0, 0),
                Sprites.Sprites.Button.StartMenu.Frame1
            );
            Objects.StartMenu.Button.Button2 = new Objects.Object(
                new Vector2(0, 0),
                0f,
                5f,
                new Rectangle(0, 0, 0, 0),
                Sprites.Sprites.Button.StartMenu.Frame2
            );

            Font.Fifaks24 = Content.Load<SpriteFont>("Fifaks24.Font");
            Font.Fifaks92 = Content.Load<SpriteFont>("Fifaks92.Font");
            Font.Fifaks144 = Content.Load<SpriteFont>("Fifaks144.Font");

            MediaPlayer.Play(Songs.StartMenuBackgroundMusic);
            MediaPlayer.IsRepeating = true; // Для повторення музики
        }
    }
}