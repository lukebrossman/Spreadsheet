namespace Spreadsheet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.demoBttn = new System.Windows.Forms.Button();
            this.editCellTextBox = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(778, 438);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateCellContents);
            // 
            // demoBttn
            // 
            this.demoBttn.Location = new System.Drawing.Point(585, 5);
            this.demoBttn.Name = "demoBttn";
            this.demoBttn.Size = new System.Drawing.Size(75, 23);
            this.demoBttn.TabIndex = 1;
            this.demoBttn.Text = "Demo";
            this.demoBttn.UseVisualStyleBackColor = true;
            this.demoBttn.Click += new System.EventHandler(this.demoBttn_Click);
            // 
            // editCellTextBox
            // 
            this.editCellTextBox.Location = new System.Drawing.Point(323, 8);
            this.editCellTextBox.Name = "editCellTextBox";
            this.editCellTextBox.Size = new System.Drawing.Size(230, 20);
            this.editCellTextBox.TabIndex = 2;
            this.editCellTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editCellTextBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 485);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.editCellTextBox);
            this.Controls.Add(this.demoBttn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button demoBttn;
        private System.Windows.Forms.TextBox editCellTextBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

