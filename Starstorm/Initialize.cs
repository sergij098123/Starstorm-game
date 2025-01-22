using Microsoft.Xna.Framework;
using Starstorm;
using Starstorm.Sound;
using Microsoft.Xna.Framework.Audio;
using Starstorm.Sprites;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Starstorm.Objects;

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

            // Завантаження музики та створення об'єкта StartMenu
            var Songs = new Songs(Content, serviceProvider);

            StartMenu.BackgroundSprite = new Sprite(Content.Load<Texture2D>("Start.BG.Image"), Color.White, SpriteEffects.None);
            StartMenu.Background = new Starstorm.Objects.Object(
                new Vector2(0, 0),
                //new Vector2(
                //    (GraphicsDevice.Viewport.Width - StartMenu.BackgroundSprite.texture.Width) / 2,
                //    (GraphicsDevice.Viewport.Height - StartMenu.BackgroundSprite.texture.Height) / 2
                //),
                0f,
                GraphicsDevice.Viewport.Width / StartMenu.BackgroundSprite.texture.Width,    
                new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), 
                StartMenu.BackgroundSprite
            );

            MediaPlayer.Play(Songs.StartMenuBackgroundMusic);
            MediaPlayer.IsRepeating = true; // Для повторення музики
        }
    }
}