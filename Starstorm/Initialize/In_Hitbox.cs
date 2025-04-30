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
using Starstorm.Logic.Hitboxes;

namespace Starstorm.Initialize{
    class Initialize_Hitbox{
        public static void InitializeStartMenu(){
            Hitboxes.StartMenu.Button.Button1 = new Rectangle(
                (int)StartMenu.Button.Button1.position.X, 
                (int)StartMenu.Button.Button1.position.Y, 
                Sprites.Sprites.Button.StartMenu.Frame1.texture.Width * (int)StartMenu.Button.Button1.scale, 
                Sprites.Sprites.Button.StartMenu.Frame1.texture.Height * (int)StartMenu.Button.Button1.scale
            );
            Hitboxes.StartMenu.Button.Button2 = new Rectangle(
                (int)StartMenu.Button_2.Button1.position.X, 
                (int)StartMenu.Button_2.Button1.position.Y, 
                Sprites.Sprites.Button.StartMenu.Frame1.texture.Width * (int)StartMenu.Button_2.Button1.scale, 
                Sprites.Sprites.Button.StartMenu.Frame1.texture.Height * (int)StartMenu.Button_2.Button1.scale
            );
        }
    }
}