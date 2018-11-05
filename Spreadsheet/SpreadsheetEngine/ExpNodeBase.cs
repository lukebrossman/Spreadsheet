using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public abstract class ExpNodeBase
    {
        public string value { get; protected set; }

        public ExpNodeBase(string val)
        {
            value = val;
        }

        public abstract double Evaluate();
        
    }
}
