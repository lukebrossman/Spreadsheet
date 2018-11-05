using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class StdCell : CellBase
    {
        public StdCell(int column, int row) : base(column, row)
        {
            RowIndex = row;
            ColumnIndex = column;
        }
    }
}
