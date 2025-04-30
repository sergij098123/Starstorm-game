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
            Test.BG.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public static void Update(){
            
        }
        public static void Initialize(){
            BG_sprite.texture = StartMenu.Background.Sprite.texture;
            BG_sprite.Color = Color.White;
            Test.BG = new Objects.Object(new Vector2(0, 0), 0f, 1f,new Rectangle(0, 0, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height), BG_sprite);
        }
        public static Sprite.Sprite BG_sprite = Sprites.Sprites.Button.StartMenu.Frame1;
    }
}