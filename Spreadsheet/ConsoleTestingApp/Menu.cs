using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestingApp
{
    public static class Menu
    {
        public static int DisplayOptions()
        {
            Console.Write("1. Enter Expression\n2. Set a Variable\n3. Evaluate Expression\n4. Quit\n");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
        public static string GetUserExpressionString()
        {
            Console.Write("Enter an expression string: ");
            return Console.ReadLine();
        }

        public static (string, double) GetUserEditedVariable()
        {
            double value = 0.0;
            Console.Write("Enter the variable name: ");
            string variable = Console.ReadLine();
            Console.Write("Enter a new value: ");
            try
            {
                value = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.Write("Value not parsable to double, using default (0.0)\n");
            }
            return (variable, value);
        }
    }
}
