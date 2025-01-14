using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starstorm.print
{
    public class Print()
    {
        public static void line(int Width, string symb)
        {
            for (var i = 0; i < Width; i++)
                Console.Write(symb);
        }
        public static void area(byte Width, int Heigth)
        {
            for (var i = 0; i < Width; i++)
            {
                for (int j = 0; j < Heigth; j++)
                {
                    Console.Write("█");
                }
            }
        }
        public static void dialoge(string text, string speaker)
        {
            var ScrWidth = Console.WindowWidth;
            switch (speaker)
            {
                case "zenon":
                    Console.ForegroundColor = ConsoleColor.Green;

                    line(ScrWidth, "═");
                    Console.WriteLine("->" + text);

                    break;

                case "radio":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    line(ScrWidth, "═");
                    Console.WriteLine(" *" + text);

                    break;
                case "unknown":
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    line(ScrWidth, "═");
                    Console.WriteLine("-?" + text);

                    break;
                case "game":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Print.line(ScrWidth, "═");
                    Console.WriteLine("→" + text);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;

                    line(ScrWidth, "═");
                    Console.WriteLine("--" + text);
                    break;
            }
            line(ScrWidth, "═");

            Console.ReadKey(true);
            Console.WriteLine("");
            Console.ResetColor();
        }
        public static void action(string text){
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Console.ReadKey(true);

            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}
