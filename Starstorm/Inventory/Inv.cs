using System;
using System.Collections.Generic;
using Starstorm.Items;
#pragma warning disable CS8601

namespace Starstorm.Inventory{
    class Inv{
        public string Name { get; set; } = string.Empty; // Назва предмета
        public int Damage { get; set; } = 0; // Стат для предметів типу "зброя"
        public double Protection { get; set; } = 0.0; // Стат для предметів типу "захист"
        public int Repair { get; set; } = 0; // Стат для предметів типу "ремонт"

        public static List<Item> Items = new List<Item>();
        public static void AddItem(Item item){
            if (Items.Count < 10){
                Items.Add(item);
            } else {
                Console.WriteLine("Inventory is full");
            }
        }
        public static void RemoveItem(Item item){
            if(Items.Contains(item)){
                Items.Remove(item);
            } else {
                Console.WriteLine("Item not found");
            }
        }
        public static void ShowItems(){
            Console.WriteLine("Items:");
            foreach (var item in Items){
                Console.WriteLine(item.Name);
            }
        }
        public static void GUI(){ // by copilot fully
            Console.WriteLine("Inventory:");
            Console.WriteLine("1. Show items");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");
            string choose = Console.ReadLine();
            switch(choose){
                case "1":
                    ShowItems();
                    break;
                case "2":
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter item type (damage, protection, repair): ");
                    string type = Console.ReadLine();
                    switch (type){
                        case "damage":
                            Console.Write("Enter item damage: ");
                            int damage = Convert.ToInt32(Console.ReadLine());
                            AddItem(new Item { Name = name, Damage = damage});
                            break;
                        case "protection":
                            Console.Write("Enter item protection: ");
                            double protection = Convert.ToDouble(Console.ReadLine());
                            AddItem(new Item { Name = name, Protection = protection});
                            break;
                        case "repair":
                            Console.Write("Enter item repair: ");
                            int repair = Convert.ToInt32(Console.ReadLine());
                            AddItem(new Item { Name = name, Repair = repair});
                            break;
                        default:
                            Console.WriteLine("Wrong type");
                            break;
                    }
                    break;
                case "3":
                    Console.Write("Enter item name: ");
                    string _name = Console.ReadLine();
                    RemoveItem(new Item { Name = _name });
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Wrong choose");
                    break;
            }
        }
    }
}