using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starstorm.console
{
    public static class MyConsole
    {
        public static void ClearLine(int Width)
        {
            Width = 100;
            for (int i = 0; i < Width; i++) {
                //Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Width));
            }
        }
		public static void Clear(int num)
		{
			for (int i = 0; i < num; i++)
			{
				Console.Write(new string(' ', num));
			}
		}
		public static void ProgressBar()
        {
            int barWidth = 50;
            for (int progress = 0; progress <= 100; progress = progress + 2)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) 
                {
                    Console.CursorLeft = 0; // Повертаємо курсор на початок рядка
                    int filledWidth = (progress * barWidth) / 100;

                    // Очищення рядка
                    Console.Write(new string(' ', barWidth + 10)); // Рядок + додаткове мiсце для вiдсоткiв
                    Console.CursorLeft = 0; // Повертаємося знову на початок

                    // Вибiр кольору залежно вiд прогресу
                    if (progress < 30)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (progress < 70)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    // Малюємо заповнену частину
                    Console.Write("[");
                    Console.Write(new string('█', filledWidth));

                    // Повертаємо колiр для порожньої частини
                    Console.ResetColor();
                    Console.Write(new string('▒', barWidth - filledWidth));
                    Console.Write($"] {progress}%");
                }
            }
        }
        public static void calibration(){
        Random random = new Random();

        int correctValue = random.Next(1, 20);  // Правильне значення для калiбрування
        int userInput;  // Введене значення

        // Гра
        while (true)
        {
            Console.WriteLine($"\nСистема перебуває в станi калiбрування.");
            Console.WriteLine("Для налаштування введiть число вiд 1 до 20.");

            Console.Write("Ваше введене значення: ");
            string input = Console.ReadLine();

            // Перевiрка введення
            if (!int.TryParse(input, out userInput) || userInput < 1 || userInput > 20)
            {
                Console.WriteLine("Некоректне введення! Введiть число вiд 1 до 20.");
                continue;
            }

            // Перевiрка на вiдповiднiсть
            if (userInput == correctValue)
            {
                Console.WriteLine("Чудово! Ви налаштували навiгацiйну систему правильно!");
                break;
            }
            else
            {
                // Вивести пiдказку, залежно вiд того, наскiльки близько до правильного значення
                int difference = Math.Abs(userInput - correctValue);
                if (difference <= 3)
                {
                    Console.WriteLine("Непогано, ви дуже близько до правильного значення!");
                }
                else
                {
                    Console.WriteLine("Це далеко вiд правильного значення. Спробуйте знову.");
                }
            }
        }
        }
    }
}
