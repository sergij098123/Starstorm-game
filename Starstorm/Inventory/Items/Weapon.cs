using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Starstorm.Items;
using System;

namespace Starstorm.Items
{
    public class Weapon{
        public string Name;
        public int Damage;
        public int Price;
        public string Description;
        public Texture2D Texture;
        public Weapon(string name, int damage, int price, string description, Texture2D texture)
        {
            Name = name;
            Damage = damage;
            Price = price;
            Description = description;
            Texture = texture;
        }
        public void Wear()
        {

            Console.WriteLine("You wear " + Name);
        }
        public Weapon testWeapon = new("Test Weapon", 10, 10, "This is a test Weapon", null);
    }
}