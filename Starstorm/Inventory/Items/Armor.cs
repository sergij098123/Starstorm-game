using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using Starstorm.statistic;
using Starstorm.Items;

namespace Starstorm.Items
{
    public class Armor{
        public string Name;
        public int ArmorValue;
        public int Price;
        public string Description;
        public Texture2D Texture;
        public Armor(string name, int armorValue, int price, string description, Texture2D texture)
        {
            Name = name;
            ArmorValue = armorValue;
            Price = price;
            Description = description;
            Texture = texture;
        }
        public void Wear()
        {
            
            Console.WriteLine("You wear " + Name);
        }
        public Armor testArmor = new("Test armor", 10, 10, "This is a test armor", null);
    }
}