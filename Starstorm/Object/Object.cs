using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Starstorm.Sprite;
using System.Runtime.CompilerServices;

namespace Starstorm.Objects{
    public class Object
    {
        public Sprite.Sprite Sprite;
        public Vector2 position;
        public float Rotation;
        public float scale;
        public Rectangle rectangle;
        public Object(Vector2 position, float rotation, float scale, Rectangle rectangle, Sprite.Sprite sprite)
        {
            this.Sprite = sprite;
            this.position = position;
            this.scale = scale;
            this.rectangle = rectangle;
            this.Rotation = rotation;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(texture: Sprite.texture,   // Текстура
                position: position,                     // Позиція
                sourceRectangle: rectangle,             // Вся текстура
                color: Sprite.Color,                    // Колір
                rotation: Rotation,                     // Кут обертання
                origin: Vector2.Zero,                   // Точка походження
                scale: scale,                           // Масштаб
                effects: Sprite.effect,                 // Без ефектів
                layerDepth: 0f                          // Глибина шару
            );
            spriteBatch.End();                  
        }
        public Object Get()
        {
            return new Object(
                this.position,
                this.Rotation,
                this.scale,
                this.rectangle,
                this.Sprite
            );
        }
    }
}