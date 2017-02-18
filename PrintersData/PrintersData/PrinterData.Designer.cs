namespace PrintersData
{
    partial class PrinterData
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
            this.addPrinterButton = new System.Windows.Forms.Button();
            this.editPrinterButton = new System.Windows.Forms.Button();
            this.addPrinterModelButton = new System.Windows.Forms.Button();
            this.listBranches = new System.Windows.Forms.ComboBox();
            this.branchLabel = new System.Windows.Forms.Label();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new PrintersData.CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addPrinterButton
            // 
            this.addPrinterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPrinterButton.Location = new System.Drawing.Point(818, 72);
            this.addPrinterButton.Name = "addPrinterButton";
            this.addPrinterButton.Padding = new System.Windows.Forms.Padding(5);
            this.addPrinterButton.Size = new System.Drawing.Size(129, 44);
            this.addPrinterButton.TabIndex = 1;
            this.addPrinterButton.Text = "Добави Принтер";
            this.addPrinterButton.UseVisualStyleBackColor = true;
            this.addPrinterButton.Click += new System.EventHandler(this.addPrinterButton_Click);
            // 
            // editPrinterButton
            // 
            this.editPrinterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editPrinterButton.Location = new System.Drawing.Point(818, 172);
            this.editPrinterButton.Name = "editPrinterButton";
            this.editPrinterButton.Padding = new System.Windows.Forms.Padding(5);
            this.editPrinterButton.Size = new System.Drawing.Size(129, 44);
            this.editPrinterButton.TabIndex = 2;
            this.editPrinterButton.Text = "Редактирай принтер";
            this.editPrinterButton.UseVisualStyleBackColor = true;
            this.editPrinterButton.Click += new System.EventHandler(this.editPrinterButton_Click);
            // 
            // addPrinterModelButton
            // 
            this.addPrinterModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPrinterModelButton.Location = new System.Drawing.Point(818, 122);
            this.addPrinterModelButton.Name = "addPrinterModelButton";
            this.addPrinterModelButton.Padding = new System.Windows.Forms.Padding(5);
            this.addPrinterModelButton.Size = new System.Drawing.Size(129, 44);
            this.addPrinterModelButton.TabIndex = 4;
            this.addPrinterModelButton.Text = "Добави модел принтер";
            this.addPrinterModelButton.UseVisualStyleBackColor = true;
            this.addPrinterModelButton.Click += new System.EventHandler(this.addPrinterModelButton_Click);
            // 
            // listBranches
            // 
            this.listBranches.FormattingEnabled = true;
            this.listBranches.Location = new System.Drawing.Point(24, 42);
            this.listBranches.Name = "listBranches";
            this.listBranches.Size = new System.Drawing.Size(257, 21);
            this.listBranches.TabIndex = 5;
            this.listBranches.SelectedIndexChanged += new System.EventHandler(this.listBranches_SelectedIndexChanged);
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Location = new System.Drawing.Point(24, 23);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(38, 13);
            this.branchLabel.TabIndex = 6;
            this.branchLabel.Text = "Склад";
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(332, 46);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(161, 17);
            this.activeCheckBox.TabIndex = 7;
            this.activeCheckBox.Text = "Само активните принтери ";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            this.activeCheckBox.CheckedChanged += new System.EventHandler(this.ActiveCheckBox_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.Location = new System.Drawing.Point(24, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(788, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // PrinterData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(959, 621);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.branchLabel);
            this.Controls.Add(this.listBranches);
            this.Controls.Add(this.addPrinterModelButton);
            this.Controls.Add(this.editPrinterButton);
            this.Controls.Add(this.addPrinterButton);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Name = "PrinterData";
            this.Text = "PrintersData";
            this.Load += new System.EventHandler(this.ShowPrinters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGridView dataGridView1;
        private System.Windows.Forms.Button addPrinterButton;
        private System.Windows.Forms.Button editPrinterButton;
        private System.Windows.Forms.Button addPrinterModelButton;
        private System.Windows.Forms.ComboBox listBranches;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.CheckBox activeCheckBox;
    }
}