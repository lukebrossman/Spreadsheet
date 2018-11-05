using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class NumericalNode : ExpNodeBase
    {
        public NumericalNode(string val) : base(val)
        {
        }
        public override double Evaluate()
        {
            return Convert.ToDouble(value);
        }
    }
}
