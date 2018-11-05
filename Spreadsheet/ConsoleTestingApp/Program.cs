using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpts321;

namespace ConsoleTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "A1+B1-C2";
            int option;
            (string, double) editVariable;
            ExpTree expTree = new ExpTree( expression);

            while ((option = Menu.DisplayOptions()) != 4)
            {
                switch (option)
                {
                    case 1:
                        expression = Menu.GetUserExpressionString();
                        expTree = new ExpTree(expression);
                        break;

                    case 2:
                        editVariable = Menu.GetUserEditedVariable();
                        expTree.SetVar(editVariable.Item1, editVariable.Item2);
                        break;

                    case 3:
                        Console.Write($"{expression} = {expTree.Eval()}\n");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
