using System;
using Starstorm.Inventory;

namespace Starstorm.Shops
{
    static public class Shop
    {
        public static class testShop{
            public static void GUI(){
                Console.WriteLine("Welcome to the test shop!");
                Console.WriteLine("1. Buy Item");
                Console.WriteLine("2. Sell Item");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You chose to buy an item.");
                        
                        break;
                    case "2":
                        Console.WriteLine("You chose to sell an item.");
                        Console.WriteLine("Inter item name:");
                        int i = 0;
                        foreach (var item in Inv.Items)
                        {
                            i++;
                            Console.WriteLine($"{i}. {item.Name}");
                        }
                        string itemChoice = Console.ReadLine();
                        if (int.TryParse(itemChoice, out int itemIndex))
                        {
                            if (itemIndex > 0 && itemIndex <= Inv.Items.Count)
                            {
                                Inv.Items.RemoveAt(itemIndex - 1);
                                Console.WriteLine("Item sold.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid item index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid item index.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Exiting shop.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}