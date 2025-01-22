using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Starstorm.Sprites
{
    public class Sprite{
        public Texture2D texture;
        //public Vector2 position;
        //public float Rotation;
        //public float scale;
        public Color Color;
        //public Rectangle rectangle;
        public SpriteEffects effect;
        public Sprite(Texture2D texture, Color color, SpriteEffects effect){
            this.texture = texture;
            //this.position = position;
            //this.scale = scale;
            this.Color = color;
            //this.rectangle = rectangle;
            this.effect = effect;
            //this.Rotation = rotation;
        }
    }
}