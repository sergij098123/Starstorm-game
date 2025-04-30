using System;
using System.Threading;
using Starstorm.print;
using Starstorm.minigames;
using Starstorm.console;
using Starstorm.text;
using Starstorm.Shops;
using System.Security.Cryptography.X509Certificates;
namespace Starstorm.selects{
    public static class Select1{
        public static bool choose = true;
        public static void main(){
            string input;
            Console.WriteLine("1.Так\n2.Ні");
            while (choose){
                input = Console.ReadLine();
                if(input == "1"){
                    Select1.choose = false;
                    break;
                } 
                else if(input == "2"){
                    Select1.choose = true;

                    Print.dialoge(Text.game(1), "game");
                    Print.dialoge(Text.game(2), "game");
                    Console.Beep();
                    Thread.Sleep(1000);
                }
                else {
                    Print.dialoge("Що ти сказав? Повтори.", "unknown");
                }
            }
            Print.dialoge(Text.zenon(12), "zenon");
            Print.action(Text.action(16));
            Print.dialoge(Text.radio(11), "radio");
            Print.action(Text.action(17));
            Print.dialoge(Text.unknown(5), "unknown");
            Print.action(Text.action(18));
        }
    }
}