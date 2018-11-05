using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321
{
    public class SpreadSheet
    {
        public int ColumnCount { get; private set; }
        public int RowCount { get; private set; }
        public CellBase[,] Cells { get; private set; }

        public event PropertyChangedEventHandler CellPropertyChanged;
        public SpreadSheet(int columns, int rows)
        {
            Cells = new CellBase[columns , rows];
            for(int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column ++)
                {
                    Cells[column , row] = new StdCell(column, row);
                    Cells[column , row].PropertyChanged += Spreadsheet_PropertyChanged;
                }
            }
            ColumnCount = columns;
            RowCount = rows;
        }

        public CellBase GetCell (int column, int row)
        {
            return Cells[column , row];
        }
        private void Spreadsheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var currentCell = (CellBase)sender;
            var tempString = CalculateValue(currentCell.Text);
            currentCell.Value = tempString;
            CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
        }

        private string CalculateValue(string text)
        {
            if (text[0] == '=')
            {
                var rx = new Regex(@"\b[A-Z]{1}[0-9]+");
                MatchCollection matches = rx.Matches(text);
                CellBase newCell = GetAssignmentCell(matches[0].ToString());
                return newCell.Value; 
            }
            else
            {
                return text;
            }
        }

        public void Demo()
        {
            var rand = new Random();
            for( int i = 0; i < 50; i++)
            {
                Cells[rand.Next(0, ColumnCount), rand.Next(0, RowCount)].Text = "Hello World!";
            }
            for (int i = 0; i < 50; i++)
            {
                Cells[1, i].Text = $"This is cell B{i + 1}";
            }
            for (int i = 0; i < 50; i++)
            {
                Cells[0, i].Text = $"= B{i+1}";
            }
        }

        private CellBase GetAssignmentCell(string cellName)
        {
            int column = cellName[0]- 65, row = 0;
            Int32.TryParse(cellName.Remove(0, 1), out row);
            return GetCell(column, row - 1);
        }
    }
}
