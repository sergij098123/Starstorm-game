using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace Starstorm.Items
{
    public class Food{
        public string Name;
        public int Heal;
        public int Price;
        public string Description;
        public Texture2D Texture;
        public Food(string name, int heal, int price, string description, Texture2D texture)
        {
            Name = name;
            Heal = heal;
            Price = price;
            Description = description;
            Texture = texture;
        }
        public void Eat()
        {

            Console.WriteLine("You ate " + Name);
        }
        public Food testFood = new("Test Food", 10, 10, "This is a test food", null);
    }
}