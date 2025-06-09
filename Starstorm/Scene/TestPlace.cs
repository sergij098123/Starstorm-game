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
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace Starstorm.Draw{
    class TestPlace
    {
        public static void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            Test.BG.Draw(_spriteBatch);

            ((Objects.Object)Test.Character).Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public static void Update(GameTime gameTime, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (((Objects.Object)Test.Character).position.Y > Var.StartMenu.Screen.height * 0.75)
                    Test.BG.position.Y -= 10f;
                else
                    ((Objects.Object)Test.Character).position.Y += 10f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (((Objects.Object)Test.Character).position.Y < Var.StartMenu.Screen.height * 0.25)
                    Test.BG.position.Y += 10f;
                else
                    ((Objects.Object)Test.Character).position.Y -= 10f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (((Objects.Object)Test.Character).position.X < screenWidth * 0.25)
                    Test.BG.position.X += 10f;
                else
                    ((Objects.Object)Test.Character).position.X -= 10f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (((Objects.Object)Test.Character).position.X > Var.StartMenu.Screen.width * 0.75)
                    Test.BG.position.X -= 10f;
                else
                    ((Objects.Object)Test.Character).position.X += 10f;
            }
        }
        public static void Initialize(ContentManager Content, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            Charapter_spritesheet = Content.Load<Texture2D>("Character_spritesheet");
            Charapter = new Spritesheet.Spritesheet(Charapter_spritesheet, new Vector2(0, 0), 100, 100, 4, 0);
            BG_sprite = new Sprite.Sprite(StartMenu.BackgroundSprite.texture, Color.White, SpriteEffects.None); //new Color(5, 6, 8)
            Test.BG = new Objects.Object(new Vector2(0, 0), 0f, screenWidth / BG_sprite.texture.Width, new Rectangle(0, 0, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height), BG_sprite);
            Test.Character = new Objects.Object(new Vector2(Var.StartMenu.Screen.width / 2, screenHeight / 2), 0f, 2f, new Rectangle(0, 0, screenWidth, screenHeight), Sprites.Sprites.Button.StartMenu.Frame1);//new Sprite.Sprite(new Texture2D(GraphicsDevice, 100, 100), Color.White, SpriteEffects.None
        }
        public static Sprite.Sprite BG_sprite = Sprites.Sprites.Button.StartMenu.Frame1;
        public static Texture2D Charapter_spritesheet;
        public static Spritesheet.Spritesheet Charapter;
    }
}