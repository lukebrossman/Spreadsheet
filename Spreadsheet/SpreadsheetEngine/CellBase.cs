using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cpts321
{
    public abstract class CellBase : INotifyPropertyChanged
    {
        private string mText;
        public int RowIndex { get; protected set; }

        public int ColumnIndex { get; protected set; }

        public string Text
        {
            get { return mText; }
            set
            {
                if (value != Text)
                {
                    mText = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string Value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void TriggerOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Text");
        }

        public CellBase(int column, int row)
        {
            RowIndex = row;
            ColumnIndex = column;
        }
    }
}
