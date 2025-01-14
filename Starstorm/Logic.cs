using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Starstorm.Logic;
public class GameLogic : Game
{
    public static bool IsPressed(Keys key)
    {
        if (Keyboard.GetState().IsKeyDown(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}