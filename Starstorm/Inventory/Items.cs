using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starstorm.statistic;

namespace Starstorm.Items{
    class Item
    { //// ChatGPT
    public string Name { get; set; } = string.Empty; // Назва предмета
    public int Damage { get; set; } = 0; // Стат для предметів типу "зброя"
    public double Protection { get; set; } = 0.0; // Стат для предметів типу "захист"
    public int Repair { get; set; } = 0; // Стат для предметів типу "ремонт"

    // Метод створення предметів
    public static List<Item> Items()
    {
        return new List<Item>
        {
            new Item { Name = "Wrench", Damage = 2 },
            new Item { Name = "Cosmic Suit", Protection = 0.5 },
            new Item { Name = "First Aid Kit", Repair = 10 }
        };
    }
}

}