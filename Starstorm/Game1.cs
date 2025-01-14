using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Logic;

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

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }
    int test_pos_x = 0;
    int test_pos_y = 0;
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        if (GameLogic.IsPressed(Keys.W))
            test_pos_y -= 2;
        if (GameLogic.IsPressed(Keys.S))
            test_pos_y += 2;
        if (GameLogic.IsPressed(Keys.A))
            test_pos_x -= 2;
        if (GameLogic.IsPressed(Keys.D))
            test_pos_x += 2;
        base.Update(gameTime);
    }
    public Texture2D _test;
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _test = Content.Load<Texture2D>("image");
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_test, new Vector2(test_pos_x, test_pos_y), Color.White);
        _spriteBatch.End();
    }
}
