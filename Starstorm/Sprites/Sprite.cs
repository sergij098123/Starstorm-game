using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Starstorm.Sprites
{
    public class Sprite{
        public Texture2D texture;
        public Vector2 position;
        public float scale;
        public Color Color;
        public Sprite(Texture2D texture, Vector2 position, float scale, Color color){
            this.texture = texture;
            this.position = position;
            this.scale = scale;
            this.Color = Color.White;
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture: texture,      // Текстура
                position: position,                 // Позиція
                sourceRectangle: null,              // Вся текстура
                color: Color,                       // Колір
                rotation: 0f,                       // Кут обертання
                origin: Vector2.Zero,               // Точка походження
                scale: scale,                       // Масштаб
                effects: SpriteEffects.None,        // Без ефектів
                layerDepth: 0f                      // Глибина шару
            );                      
        }
    }
}