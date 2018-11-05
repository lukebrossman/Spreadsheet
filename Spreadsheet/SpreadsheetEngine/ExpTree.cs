using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cpts321
{
    public class ExpTree
    {
        private ExpNodeBase expRoot;
        private Dictionary<string, List<VariableNode>> Variables;
        public ExpTree(string expression)
        {
            Variables = new Dictionary<string, List<VariableNode>> { };
            expRoot = ExpTreeFactory.CreateExpTree(expression, ref Variables);
        }
        public void SetVar(string varName, double varValue)
        {
            try
            {
                foreach (var node in Variables[varName])
                {
                    node.varValue = varValue;
                }
            }
            catch
            {

            }
        }

        public double Eval()
        {
            return expRoot.Evaluate();
        }

    }
}
