using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Cpts321
{
    public class OperatorNode : ExpNodeBase
    {
        private MethodInfo function;

        private Operations operations = new Operations();
        public ExpNodeBase leftChild { get; set; }

        public ExpNodeBase rightChild { get; set; }

        public OperatorNode(string val) : base(val)
        {
            function = operations.GetOperation(val);
        }

        public  override double Evaluate()
        { 
            return (double)function.Invoke(operations, new object[]{ leftChild.Evaluate(), rightChild.Evaluate() }); 
           
        }
    }
}
