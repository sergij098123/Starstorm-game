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
    class TestPlace{
        public static void Draw(SpriteBatch _spriteBatch, int screenWidth, int screenHeight, GraphicsDevice GraphicsDevice){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            //making grass or like it
            int[,] matrix = {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            };
            for (int i = 0; i < matrix.GetLength(0); i++){
                for (int j = 0; j < matrix.GetLength(1); j++){
                    if (matrix[i,j] == 1){
                        _spriteBatch.Draw(StartMenu.BackgroundSprite.texture, new Vector2(j * 50, i * 50), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            _spriteBatch.End();
        }
        public static void Update(){
            
        }
    }
}