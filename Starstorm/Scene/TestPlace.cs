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
            GraphicsDevice.Clear(Color.BlueViolet);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            _spriteBatch.End();
        }
        public static void Update(){
            Console.WriteLine("TestPlace");
        }
    }
}