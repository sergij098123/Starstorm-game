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
    public class Stat{
        public class Player{
            static public int Money = 10;
            static public Weapon Weapon = Weapon.testWeapon;
            static public Armor Armor = Armor.testArmor;
            public const string Name = "Zenon";
            public const string Surname = "Helx";
            public int HP = 50;
        }
    }
}