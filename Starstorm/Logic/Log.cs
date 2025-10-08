using Starstorm;
using Starstorm.Variables;

namespace Starstorm.LogF3
{
    public class Log
    {
        public static void Print(string message)
        {
            Var.Test.LogText = message + "\n" + Var.Test.LogText;
            //Console.WriteLine(message);
        }
        public void Main()
        {
            Show();

        }
        public void Show()
        {
            Var.Test.IsLogShow = !Var.Test.IsLogShow;
        }
    }
}