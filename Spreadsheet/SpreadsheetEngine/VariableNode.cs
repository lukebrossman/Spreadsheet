using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class VariableNode : ExpNodeBase , INotifyPropertyChanged
    {
        public double varValue { private get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public VariableNode(string val) : base(val)
        {
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override double Evaluate()
        {
            OnPropertyChanged("value");
            return varValue;
        }
    }
}
