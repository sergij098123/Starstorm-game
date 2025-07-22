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

namespace Spritesheet
{
    public class Spritesheet
    {
        public static SpriteBatch spriteBatch;
        static public Texture2D spriteSheet;
        public Vector2 position;
        static public int frameWidth;
        static public int frameHeight;
        static public int frameCount;
        static public int currentFrame = 0;
        static public float timer;
        static public float frameTime;
        public int row; // якщо анімація не в першому рядку
        private float Size = 1f;
        private SpriteEffects Effect = SpriteEffects.None;
        public Spritesheet(Texture2D texture, Vector2 pos, int frameW, int frameH, int frameC, int r, float frameT = 0.5f, float sz = 1f, SpriteEffects ef = SpriteEffects.None)
        {
            spriteSheet = texture;
            position = pos;
            frameWidth = frameW;
            frameHeight = frameH;
            frameCount = frameC;
            frameTime = 1f / frameT; // час на кадр
            row = r; // рядок анімації
            Size = sz;
            Effect = ef;
        }
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = 0f;
            }

            Rectangle sourceRect = new Rectangle(currentFrame * frameWidth, row * frameHeight, frameWidth, frameHeight);
        }
        public void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            _spriteBatch.Draw(spriteSheet, position, new Rectangle(currentFrame * frameWidth, row * frameHeight, frameWidth, frameHeight), Color.White, 0, Vector2.Zero, Size, Effect, 0);
            _spriteBatch.End();
        }
        public int GetRow()
        {
            return row;
        }
        public void SetRow(int r)
        {
            row = r;
        }
        public int GetCount()
        {
            return frameCount;
        }
        public void SetCount(int c)
        {
            frameCount = c;
        }
        public void SetEffect(SpriteEffects ef)
        {
            Effect = ef;
        }
        public void SetCurrent(int c)
        {
            currentFrame = c;
        }
        public int GetCurrent()
        {
            return currentFrame;
        }
        public float GetSize()
        {
            return Size;
        }
        public int GetWidth()
        {
            return frameWidth;
        }
        public int GetHeight()
        {
            return frameHeight;
        }
    }
}