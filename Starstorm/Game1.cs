using System.Collections.Generic;
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
using Starstorm.LogF3;
using System.Diagnostics;
using System.IO;

namespace Starstorm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics = null!;
    private SpriteBatch _spriteBatch = null!;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void LoadContent()
    {
        TestPlace = new TestPlace();
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
        Hitbox.InitializeStartMenu();

        StartMenu.Background.scale = GraphicsDevice.Adapter.CurrentDisplayMode.Width / StartMenu.BackgroundSprite.texture.Width;

        TestPlace.Initialize(Content, GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height, GraphicsDevice);
        Log.Print("Sucessfully initialized base of a game");
        //Sprites.Sprites.Button.StartMenu.Frame1 = new Sprite.Sprite(Content.Load<Texture2D>("Start.Button.F1"), Color.White, SpriteEffects.None);
    }
    private bool _isFullscreen = false; // Чи включено повноекранний режим
    private bool _isF11Pressed = false; // Чи зафіксовано натискання F11
    private bool _f11PrevState = false; // Попередній стан клавіші F11
    private int _isF3Pressed = 50; // Чи зафіксовано натискання F3
    private KeyboardState _key;
    private bool _isShiftPressed = false;
    protected override void Update(GameTime gameTime)
    {
        Var.GameTime = gameTime;
        _key = Keyboard.GetState();

        if (Var.isExit)
            Exit();
#if DEBUG
        foreach (var key in _key.GetPressedKeys())
        {
            switch (key)
            {
                case Keys.LeftShift:
                    _isShiftPressed = true;
                    break;
                case Keys.T:
                    Var.scene = "Test";
                    break;
                case Keys.S:
                    Var.scene = "StartMenu";
                    break;
                case Keys.F3:
                    if (_isF3Pressed > 0)
                    {
                        _isF3Pressed -= 1;
                        break;
                    }
                    new Log().Main();
                    if (_isShiftPressed) Var.Test.LogText = "";
                    _isF3Pressed = 2;
                    break;
            }
        }
#endif
        bool f11Current = _key.IsKeyDown(Keys.F11);
        if (f11Current && !_f11PrevState)
        {
            _isFullscreen = !_isFullscreen;
            _graphics.IsFullScreen = _isFullscreen;
            _graphics.ApplyChanges();
        }
        _f11PrevState = f11Current;

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
        STUpdate.Update(_isF11Pressed, _isFullscreen, GraphicsDevice, _graphics, Content, Window, _key);

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
                break;
        }
        _spriteBatch.Begin();
        if (Var.Test.IsLogShow)
            _spriteBatch.DrawString(Font.Fifaks24, Var.Test.LogText, new Vector2(10, 10), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}