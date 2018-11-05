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

        public static ExpNodeBase CreateExpTree(string expression,ref Dictionary<string, List<VariableNode>> Variables)
        {
            Regex expRegex = new Regex(@"([A-Za-z]+[\d]*|[\+-/*\(\)]{1}|[\d]*\.?[\d]+)");
            MatchCollection matches = expRegex.Matches(expression);
            return ExpressionToTree(matches,ref Variables);

        }

        private static ExpNodeBase ExpressionToTree(MatchCollection matches,ref Dictionary<string, List<VariableNode>> Variables)
        {
            Stack<ExpNodeBase> nodestack = new Stack<ExpNodeBase>{ };
            var expressionList = ShuntingYard(matches);
            OperatorNode root = null;
            foreach(var value in expressionList)
            {
                if (IsOperand(value))
                {
                    nodestack.Push(MakeLeaf(value, ref Variables));
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

        private static ExpNodeBase MakeLeaf(string val, ref Dictionary<string, List<VariableNode>> Variables)
        {
            ExpNodeBase newNode;
            if (val[0] >= '0' && val[0] <= '9')
            {
                newNode = new NumericalNode(val);
            }
            else
            {
                newNode = new VariableNode(val);
                if (Variables.ContainsKey(val))
                {
                    Variables[val].Add((VariableNode)newNode);
                }
                else
                {
                    Variables.Add(val, new List<VariableNode> { (VariableNode)newNode });
                }
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
