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
using Starstorm;

namespace Starstorm.Draw{
    class TestPlace
    {
        public float Speed = 4f;
        public void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Test.BG.Draw(_spriteBatch);
            Charapter.Draw(_spriteBatch, screenWidth, screenHeight);
            //((Objects.Object)Test.Character).Draw(_spriteBatch);
        }
        public void Update(GameTime gameTime, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Var.Player.direction = 1;
                Charapter.SetRow(3);
                Charapter.SetEffect(SpriteEffects.None);
                if (Charapter.position.Y > Var.StartMenu.Screen.height * 0.75)
                    Var.Test.PlayerShift.Y -= Speed;
                else
                    Charapter.position.Y += Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Var.Player.direction = 0;
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Charapter.SetRow(5);
                Charapter.SetEffect(SpriteEffects.None);
                if (Charapter.position.Y < Var.StartMenu.Screen.height * 0.25)
                    Var.Test.PlayerShift.Y += Speed;
                else
                    Charapter.position.Y -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Var.Player.direction = 2;
                Charapter.SetRow(4);
                Charapter.SetEffect(SpriteEffects.FlipHorizontally);
                if (Charapter.position.X < screenWidth * 0.25)
                    Var.Test.PlayerShift.X += Speed;
                else
                    Charapter.position.X -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Var.Player.direction = 3;
                Charapter.SetRow(4);
                Charapter.SetEffect(SpriteEffects.None);
                if (Charapter.position.X > Var.StartMenu.Screen.width * 0.75)
                    Var.Test.PlayerShift.X -= Speed;
                else
                    Charapter.position.X += Speed;
            }
            else
            {
                if (Var.Player.isMoving)
                    Charapter.SetCurrent(1);
                Var.Player.isMoving = false;
                Charapter.SetCount(2);
                if (Var.Player.direction == 0)
                {
                    Charapter.SetRow(2);
                    Charapter.SetEffect(SpriteEffects.None);
                }
                else if (Var.Player.direction == 1)
                {
                    Charapter.SetRow(0);
                    Charapter.SetEffect(SpriteEffects.None);
                }
                else if (Var.Player.direction == 2)
                {
                    Charapter.SetRow(1);
                    Charapter.SetEffect(SpriteEffects.FlipHorizontally);
                }
                else if (Var.Player.direction == 3)
                {
                    Charapter.SetRow(1);
                    Charapter.SetEffect(SpriteEffects.None);
                }
            }
            ShiftX = Var.Test.PlayerShift.X;
            ShiftY = Var.Test.PlayerShift.Y;
            Test.BG.position.X = ShiftX;
            Test.BG.position.Y = ShiftY;
            Charapter.Update(gameTime);
        }
        public void Initialize(ContentManager Content, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            Charapter_spritesheet = Content.Load<Texture2D>("Character_spritesheet");
            Charapter = new Spritesheet.Spritesheet(Charapter_spritesheet, new Vector2(screenWidth /2, screenHeight /2), 32, 32, 3, 5, 2.5f, 3f, SpriteEffects.None);
            BG_sprite = new Sprite.Sprite(StartMenu.BackgroundSprite.texture, Color.White, SpriteEffects.None); //new Color(5, 6, 8)
            Test.BG = new Objects.Object(new Vector2(0, 0), 0f, screenWidth / BG_sprite.texture.Width, new Rectangle(0, 0, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height), BG_sprite);
            //Test.Character = new Objects.Object(new Vector2(Var.StartMenu.Screen.width / 2, screenHeight / 2), 0f, 2f, new Rectangle(0, 0, screenWidth, screenHeight), Sprites.Sprites.Button.StartMenu.Frame1);//new Sprite.Sprite(new Texture2D(GraphicsDevice, 100, 100), Color.White, SpriteEffects.None
        }
        public Sprite.Sprite BG_sprite = Sprites.Sprites.Button.StartMenu.Frame1;
        public Texture2D Charapter_spritesheet;
        //0 - stands to screen, 1 - stands to right, 2 - stands to top, 3 - walk down, 4 - walk rigth, 5 - walk top
        public Spritesheet.Spritesheet Charapter;
        static float ShiftX;
        static float ShiftY;
    }
}