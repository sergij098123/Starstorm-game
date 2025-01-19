using System;
using Starstorm.print;
using Starstorm.minigames;
using Starstorm.console;
using Starstorm.text;
using Starstorm.Shops;
using Starstorm.selects;
using Starstorm.parts;
using Starstorm.figth;
using Starstorm.Inventory;
using Starstorm.statistic;
using Starstorm.Items; // Імпортування інших файлів
#pragma warning disable CS8601
// Я використувую такі плагіни:
// Better Comments
// git Graph

namespace Starstorm.Old
{
    static class notProgram
    {
        public static void NotMain() 
        {   
            ////Console.OutputEncoding = System.Text.Encoding.UTF8; // Ставлення кодування на utf 8

            var items = Item.Items(); // Створення предметів
            Stat.Player.Weapon.Name = items[0].Name;
            Stat.Player.Weapon.Damage = items[0].Damage; // Встановлення початкової зброї
            Stat.Player.Armor.Name = items[1].Name;
            Stat.Player.Armor.Protection = items[1].Protection; // Встановлення початкової броні

            Console.WriteLine("Click to start:");
            Console.ReadLine();
            MyConsole.ClearLine(2);

            
            
            Part1.main();
            Print.dialoge(" ×The end of game× ", "game"); // * Кінец гри
        }
    }
}