using System;
using Starstorm.print;
using Starstorm.minigames;
using Starstorm.console;
using Starstorm.text;
using Starstorm.Shops;
using Starstorm.selects;
using Starstorm.parts;
using System.ComponentModel;
using Starstorm.Items;

namespace Starstorm.statistic{
    public static class Stat{
        public class Enemy{
            public static int hp(string name){
                switch(name){
                    case "test":
                        return Player.HP / 2;
                    default:
                        Console.WriteLine("SyntaxCheck error: wrong ID");
                        return -1;
                    }
            }
            public static int damage(string name){
                switch(name){
                    case "test":
                        return Player.Weapon.Damage / 2;
                    default:
                        Console.WriteLine("SyntaxCheck error: wrong ID");
                        return -1;
                    }
            }
        }
        static public class Player{
        static public int Money = 10;
        static public class Weapon{
            static public string Name = "";
            static public int Damage = 0;
        }
        static public class Armor{
            static public string Name = "";
            static public double Protection = 0;
        }
        public const string Name = "Zenon";
        public const string Surname = "Helx";
        public const int HP = 20;
    }
    }
}