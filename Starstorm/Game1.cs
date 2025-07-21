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
using Starstorm.Update;
using System.Diagnostics;

namespace Starstorm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void LoadContent()
    {
        TestPlace = new Starstorm.Draw.TestPlace();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    private Starstorm.Draw.TestPlace TestPlace;
    protected override void Initialize()
    {
        var Game1Initialize = new Game1Initialize();
        _graphics.IsFullScreen = true;

        Font.Fifaks24 = Content.Load<SpriteFont>("Fifaks24.Font");
        Font.Fifaks36 = Content.Load<SpriteFont>("Fifaks36.Font");
        Font.Fifaks92 = Content.Load<SpriteFont>("Fifaks92.Font");
        Font.Fifaks144 = Content.Load<SpriteFont>("Fifaks144.Font");
        Font.Fifaks_variant = Font.Fifaks92;

        Var.StartMenu.Position.MainMenu_Text_1 = new Vector2(Var.StartMenu.Screen.width / 2 - Font.Fifaks_variant.MeasureString("Starstorm").X / 2, Var.StartMenu.Screen.height / 2 - Font.Fifaks_variant.MeasureString("Starstorm").Y / 2 - Var.StartMenu.Screen.height / 4);
        Sprites.Sprites.Button.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F1"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F2"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button2.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F1"), Color.White, SpriteEffects.None);
        Sprites.Sprites.Button2.StartMenu.Frame2 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button2.F2"), Color.White, SpriteEffects.None);
        base.Initialize();
        Window.AllowUserResizing = true;

        Game1Initialize.Main(this.Services, _graphics.GraphicsDevice, _spriteBatch);
        Initialize_Hitbox.InitializeStartMenu();

        StartMenu.Background.scale = GraphicsDevice.Adapter.CurrentDisplayMode.Width / StartMenu.BackgroundSprite.texture.Width;

        TestPlace.Initialize(Content, GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height, GraphicsDevice);
        //Sprites.Sprites.Button.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F1"), Color.White, SpriteEffects.None);
    }
    private bool _isFullscreen = false; // Чи включено повноекранний режим
    private bool _isF11Pressed = false; // Чи зафіксовано натискання F11
    protected override void Update(GameTime gameTime)
    {
        Var.GameTime = gameTime;
        KeyboardState keyboardState = Keyboard.GetState();

        if (Var.isExit)
            Exit();
        if (Keyboard.GetState().IsKeyDown(Keys.T))
        {
            Var.scene = "Test";
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            Var.scene = "StartMenu";
        }
        switch (Var.scene)
        {
            case "StartMenu":
                StartMenuST.Update();
                break;
            case "Test":
                TestPlace.Update(gameTime, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height, GraphicsDevice);
                break;
            default:
                Console.WriteLine("Error: Scene not found");
                break;
        }
        STUpdate.Update(_isF11Pressed, _isFullscreen, GraphicsDevice, _graphics, Content, Window, keyboardState);
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        switch(Var.scene){
            case "StartMenu":
                StartMenuST.Draw(_spriteBatch, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height, Var.StartMenu.Position.MainMenu_Text_1, GraphicsDevice);
                break;
            case "Test":
                TestPlace.Draw(_spriteBatch, Var.StartMenu.Screen.width, Var.StartMenu.Screen.height, GraphicsDevice);
                break;
            default:
                Console.WriteLine("Error: Scene not found");
                break;
        }
        base.Draw(gameTime);
    }
}