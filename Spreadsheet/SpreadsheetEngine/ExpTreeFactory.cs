using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cpts321
{
    public static class ExpTreeFactory
    {
        private static SpreadSheet _sender;

        public static ExpNodeBase CreateExpTree(string expression, SpreadSheet sender)
        {
            _sender = sender;
            Regex expRegex = new Regex(@"([A-Za-z]+[\d]*|[\+-/*\(\)]{1}|[\d]*\.?[\d]+)");
            MatchCollection matches = expRegex.Matches(expression);
            var expressionList = ShuntingYard(matches);
            return ExpressionToTree(expressionList);

        }

        private static ExpNodeBase ExpressionToTree(Queue<string> expressionList)
        {
            Stack<ExpNodeBase> nodestack = new Stack<ExpNodeBase>{ };
            OperatorNode root = null;
            foreach(var value in expressionList)
            {
                if (IsOperand(value))
                {
                    nodestack.Push(MakeLeaf(value));
                }
                else
                {
                    root = new OperatorNode(value);
                    root.rightChild = nodestack.Pop();
                    root.leftChild = nodestack.Pop();
                    nodestack.Push(root);

                }
            }
            return root;
        }

        private static Queue<string> ShuntingYard(MatchCollection expression)
        {
            Queue<string> queue = new Queue<string> { };
            Stack<string> stack = new Stack<string> { };
            stack.Push("nothing");
            foreach (var token in expression)
            {
                if (token.ToString() == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (token.ToString() == "(")
                {
                    stack.Push(token.ToString());
                }
                else if (IsOperand(token.ToString()))
                {
                    queue.Enqueue(token.ToString());
                }
                else
                {
                    var precedence = Operations.GetPrecedence(token.ToString());
                    if (precedence >= Operations.GetPrecedence(stack.Peek()))
                    {
                        stack.Push(token.ToString());
                    }
                    else
                    {
                        while(precedence < Operations.GetPrecedence(stack.Peek()))
                        {
                            queue.Enqueue(stack.Pop());
                        }
                        stack.Push(token.ToString());
                    }
                }
            }
            while (stack.Count != 1)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        private static ExpNodeBase MakeLeaf(string val)
        {
            ExpNodeBase newNode;
            VariableNode varNode;
            if (val[0] >= '0' && val[0] <= '9')
            {
                newNode = new NumericalNode(val);
            }
            else
            {
                varNode = new VariableNode(val);
                varNode.PropertyChanged += _sender.LookUpCellValue;
                newNode = varNode;
            }
            return newNode;
        }

        private static bool IsOperand(string val)
        {
            return(val[0] >= '0' && val[0] <= '9'
                || val[0] >= 'a' && val[0] <= 'z' 
                || val[0] >= 'A' && val[0] <= 'Z');
        }
    }
}
