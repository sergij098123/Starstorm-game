using System;

using Starstorm.print;
using Starstorm.minigames;
using Starstorm.console;
using Starstorm.text;
using Starstorm.Shops;
using Starstorm.selects;
using Starstorm.parts;
using Starstorm.statistic;
using Starstorm.random;

namespace Starstorm.figth{
    public static class Figth{
        public static void enemy(string name){
            var hp = Stat.Player.HP;
            var damage = Stat.Player.Weapon.Damage;
            var enemy_hp = Stat.Enemy.hp(name);
            var enemy_damage = Stat.Enemy.damage(name);
            var randomAtack = GRandom.random.Next(-1,1);
            bool run = false;
            int i = 0;
            byte spare = 0;
            string input;

            Console.WriteLine($"Характеристики {name}:\nHP: {enemy_hp}\nУрон: {enemy_damage}");



            while(true){
                Console.ReadKey();
                Console.Clear();
                if(hp <= 0 ){
                    Console.WriteLine("\nYou loose!");
                    break;
                }
                if(enemy_hp <= 0){
                    Console.WriteLine($"\nYou win\nYou earn {i} stardust");
                    Stat.Player.Money += i;
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                if(spare >= 100){
                    Console.WriteLine($"\nYou win\nYou earn {i} stardust");
                    Stat.Player.Money += i;
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                if(run){
                    Console.WriteLine("You runed away");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                Console.WriteLine("1.Атакувати\n2.Пощядити\n3.збіжати\n");
                input = Console.ReadLine();
                switch(input){
                    case "з":
                    case "3":
                        run = true;
                        break;
                    case "1":
                    case "a":
                    case "а":
                        enemy_hp -= damage + randomAtack;
                        Console.WriteLine($"Enemy HP: {enemy_hp}");
                        break;
                    case "2":
                    case "s":
                    case "п":
                    case "щ":
                        spare += 20;
                        Console.WriteLine($"Sparing: {spare}%");
                        break;
                    default: break;
                }

                randomAtack = GRandom.random.Next(-1,1);
                hp -= enemy_damage + randomAtack;
                Console.WriteLine($"HP: {hp}");
                randomAtack = GRandom.random.Next(-1,1);

                i++;
            }
        }
    }
}