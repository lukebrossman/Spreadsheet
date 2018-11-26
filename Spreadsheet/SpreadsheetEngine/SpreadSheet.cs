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
        private CellBase currentCell;
        private ExpNodeBase expression { get; set; }
        public Dictionary<string, double> CellValues { get; private set; }
        public int ColumnCount { get; private set; }
        public int RowCount { get; private set; }
        public CellBase[,] Cells { get; private set; }

        public event PropertyChangedEventHandler CellPropertyChanged;
        public SpreadSheet(int columns, int rows)
        {
            CellValues = new Dictionary<string, double> { };
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
            try
            {
                currentCell = (CellBase)sender;
                var tempString = CalculateValue(currentCell.Text);
                var key = CoordToCellName(currentCell.ColumnIndex, currentCell.RowIndex);
                try
                {
                    if (CellValues.ContainsKey(key))
                    {
                        CellValues[key] = Convert.ToDouble(tempString);
                    }
                    else
                    {
                    
                        CellValues.Add(key, Convert.ToDouble(tempString));
                    }
                }
                catch { }
                currentCell.Value = tempString;
                CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
            }
            catch { }
        }

        private string CalculateValue(string text)
        {
            string result;
            if (text[0] == '=')
            {
                ResetCurrentCellSubscription();
                expression = ExpTreeFactory.CreateExpTree(text, this);
                result = expression.Evaluate().ToString();
            }
            else
            {
                result = text;
            }
            return result;
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
            char firstLetter = cellName[0];
            int column = firstLetter - 65, row = 0;
            Int32.TryParse(cellName.Remove(0, 1), out row);
            return GetCell(column, row - 1);
        }

        private string CoordToCellName(int x, int y)
        {
            char letter = (char)(x + 65);
            string result = letter + (y + 1).ToString();
            return result;
        }

        public void LookUpCellValue(object sender, PropertyChangedEventArgs e)
        {
            var variable = (VariableNode)sender;
            string cellName = variable.value.ToUpper();
            if (CellValues.ContainsKey(cellName))
            {
                variable.varValue = CellValues[cellName];
                GetAssignmentCell(cellName).PropertyChanged += currentCell.TriggerOnPropertyChanged;
            }
            else
            {
                throw new Exception("Cell unnassigned");
            }
        }

        private void ResetCurrentCellSubscription()
        {
            currentCell.ClearSubscriptions();
            currentCell.PropertyChanged += Spreadsheet_PropertyChanged;
        }
    }
}
