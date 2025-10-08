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
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            Test.BG.Draw(_spriteBatch);
            Ship.Draw(_spriteBatch);
            Charapter.Draw(_spriteBatch, screenWidth, screenHeight);
            ((Objects.Object)Placeholder.pc1).Draw(_spriteBatch);
            ((Objects.Object)Placeholder.pc2).Draw(_spriteBatch);
            ((Objects.Object)Placeholder.pc3).Draw(_spriteBatch);
            ((Objects.Object)Placeholder.pc4).Draw(_spriteBatch);
            ((Objects.Object)Placeholder.pc5).Draw(_spriteBatch);
            _spriteBatch.End();    
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
                else if (IsColision)
                    Charapter.position.Y += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Var.Player.direction = 0;
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Charapter.SetRow(5);
                Charapter.SetEffect(SpriteEffects.None);
                if (Charapter.position.Y < Var.StartMenu.Screen.height * 0.25)
                    Var.Test.PlayerShift.Y += Speed;
                else if (IsColision)
                    Charapter.position.Y -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Var.Player.direction = 2;
                Charapter.SetRow(4);
                Charapter.SetEffect(SpriteEffects.FlipHorizontally);
                if (Charapter.position.X < screenWidth * 0.25)
                    Var.Test.PlayerShift.X += Speed;
                else if (IsColision)
                    Charapter.position.X -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Var.Player.isMoving = true;
                Charapter.SetCount(4);
                Var.Player.direction = 3;
                Charapter.SetRow(4);
                Charapter.SetEffect(SpriteEffects.None);
                if (Charapter.position.X > Var.StartMenu.Screen.width * 0.75)
                    Var.Test.PlayerShift.X -= Speed;
                else if (IsColision)
                    Charapter.position.X += Speed;
            }
            if (!Var.Player.isMoving)
            {
                Charapter.SetCount(2);
                Charapter.SetCurrent(1);
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
            Var.Player.isMoving = false;
            ShiftX = Var.Test.PlayerShift.X;
            ShiftY = Var.Test.PlayerShift.Y;

            Test.BG.position.X = ShiftX;
            Test.BG.position.Y = ShiftY;

            Ship.position.X = ShiftX;
            Ship.position.Y = ShiftY + screenHeight / 5;

            Hitbox.TestPLace.Ship.X = (int)Ship.position.X;
            Hitbox.TestPLace.Ship.Y = (int)Ship.position.Y;
            Hitbox.TestPLace.Ship.Width = (int)(Ship_sprite.texture.Width * Ship.scale);
            Hitbox.TestPLace.Ship.Height = (int)(Ship_sprite.texture.Height * Ship.scale);

            Var.Player.Hitbox = new Rectangle((int)Charapter.position.X, (int)Charapter.position.Y, Charapter.GetWidth(), Charapter.GetHeight());
            if (Var.Player.Hitbox.Intersects(Ship.rectangle))
            {
                IsColision = true;
            }
            else
            {
                IsColision = false;
            }

            Charapter.Update(gameTime);
        }
        public void Initialize(ContentManager Content, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice)
        {
            Ship_sprite = new Sprite.Sprite(Content.Load<Texture2D>("ship_test"), Color.White, SpriteEffects.None);
            Ship = new Objects.Object(new Vector2(0, 0), 0f, 2f, Ship_sprite, new Rectangle(0, 0, screenWidth, screenHeight));
            Charapter_spritesheet = Content.Load<Texture2D>("Character_spritesheet");
            Charapter = new Spritesheet.Spritesheet(Charapter_spritesheet, new Vector2(screenWidth / 2, screenHeight / 2), 32, 32, 3, 5, 2.5f, 3f, SpriteEffects.None);
            BG_sprite = new Sprite.Sprite(StartMenu.BackgroundSprite.texture, Color.White, SpriteEffects.None); //new Color(5, 6, 8)

            Sprites.Sprites.Placeholder.pc1 = new Sprite.Sprite(Content.Load<Texture2D>("pc1"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Placeholder.pc2 = new Sprite.Sprite(Content.Load<Texture2D>("pc2"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Placeholder.pc3 = new Sprite.Sprite(Content.Load<Texture2D>("pc3"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Placeholder.pc4 = new Sprite.Sprite(Content.Load<Texture2D>("pc4"), Color.White, SpriteEffects.None);
            Sprites.Sprites.Placeholder.pc5 = new Sprite.Sprite(Content.Load<Texture2D>("pc5"), Color.White, SpriteEffects.None);

            Placeholder.pc1 = new Objects.Object(new Vector2(0, 0), 0f, 1.5f, Sprites.Sprites.Placeholder.pc1, new Rectangle(0, 0, screenWidth, screenHeight));
            Placeholder.pc2 = new Objects.Object(new Vector2(0, 0), 0f, 1.5f, (Sprite.Sprite)Sprites.Sprites.Placeholder.pc2);
            Placeholder.pc3 = new Objects.Object(new Vector2(0, 0), 0f, 1.5f, (Sprite.Sprite)Sprites.Sprites.Placeholder.pc3);
            Placeholder.pc4 = new Objects.Object(new Vector2(0, 0), 0f, 1.5f, (Sprite.Sprite)Sprites.Sprites.Placeholder.pc4);
            Placeholder.pc5 = new Objects.Object(new Vector2(0, 0), 0f, 1.5f, (Sprite.Sprite)Sprites.Sprites.Placeholder.pc5);

            Test.BG = new Objects.Object(new Vector2(0, 0), 0f, screenWidth / BG_sprite.texture.Width, BG_sprite, new Rectangle(0, 0, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height));
            //Test.Character = new Objects.Object(new Vector2(Var.StartMenu.Screen.width / 2, screenHeight / 2), 0f, 2f, new Rectangle(0, 0, screenWidth, screenHeight), Sprites.Sprites.Button.StartMenu.Frame1);//new Sprite.Sprite(new Texture2D(GraphicsDevice, 100, 100), Color.White, SpriteEffects.None
            Console.WriteLine($"pc1 texture size: {Sprites.Sprites.Placeholder.pc1.texture.Width}x{Sprites.Sprites.Placeholder.pc1.texture.Height}");
        }
        public Sprite.Sprite BG_sprite = Sprites.Sprites.Button.StartMenu.Frame1;
        public Sprite.Sprite Ship_sprite = null!;
        public Objects.Object Ship = null!;
        public Texture2D Charapter_spritesheet = null!;
        //0 - stands to screen, 1 - stands to right, 2 - stands to top, 3 - walk down, 4 - walk rigth, 5 - walk top
        public Spritesheet.Spritesheet Charapter = null!;
        static float ShiftX;
        static float ShiftY;
        bool IsColision = false;
    }
}