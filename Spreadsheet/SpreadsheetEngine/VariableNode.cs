using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class VariableNode : ExpNodeBase
    {
        public double varValue { private get; set; }
        public VariableNode(string val, double num = 0.0) : base(val)
        {
            varValue = num;
        }

        public override double Evaluate()
        {
            return varValue;
        }
    }
}
