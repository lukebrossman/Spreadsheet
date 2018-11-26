using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cpts321;

namespace Spreadsheet
{
    public partial class Form1 : Form
    {
        private SpreadSheet sheet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sheet = new SpreadSheet(26, 50);
            editCellTextBox.Enabled = false;
            sheet.CellPropertyChanged += Form1_CellPropertyChanged;
            InitDataGrid();
        }

        private void InitDataGrid()
        {
            int rowNumber = 1;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                string newString = $"{letter}";
                dataGridView1.Columns.Add(newString, newString);
            }
            dataGridView1.Rows.Add(50);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber++;
            }
        }

        private void Form1_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var changedCell = (CellBase)sender;
            dataGridView1.Rows[changedCell.RowIndex].Cells[changedCell.ColumnIndex].Value = changedCell.Value;
        }

        private void demoBttn_Click(object sender, EventArgs e)
        {
            sheet.Demo();
        }

        private void UpdateCellContents(object sender, EventArgs e)
        {

        }

        private void UpdateCellContents(object sender, DataGridViewCellEventArgs e)
        {
            editCellTextBox.Enabled = true;
            editCellTextBox.Text = sheet.Cells[dataGridView1.CurrentCell.ColumnIndex,
                    dataGridView1.CurrentCell.RowIndex].Text;
        }

        private void editCellTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sheet.Cells[dataGridView1.CurrentCell.ColumnIndex,
                    dataGridView1.CurrentCell.RowIndex].Text = editCellTextBox.Text; 
                editCellTextBox.Enabled = false;
                editCellTextBox.Clear();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
