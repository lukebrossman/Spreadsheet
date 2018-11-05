using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Cpts321
{
    public class Operations
    {
        public static List<string> precedence = new List<string> {"+-", "/*", "^" } ;
        public MethodInfo GetOperation(string value)
        {
            var delegatestring = "_" + ((int)value[0]).ToString();
            return this.GetType().GetMethod(delegatestring);
        }
        public static double _43(double num1, double num2) //addition
        {
            return num1 + num2;
        }

        public static double _42(double num1, double num2) //multiplication
        {
            return num1 * num2;
        }

        public static double _45(double num1, double num2) //subtraction
        {
            return num1 - num2;
        }

        public static double _47(double num1, double num2) //division
        {
            return num1 / num2;
        }

        public static int GetPrecedence(string op)
        {
            for(int i = 0; i < precedence.Count; i++)
            {
                if (precedence[i].Contains(op))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
