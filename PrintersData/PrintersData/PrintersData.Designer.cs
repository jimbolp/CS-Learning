namespace PrintersData
{
    partial class PrintersData
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
            this.addPrinterButton = new System.Windows.Forms.Button();
            this.editPrinterButton = new System.Windows.Forms.Button();
            this.deactivatePrinterButton = new System.Windows.Forms.Button();
            this.addPrinterModelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(912, 526);
            this.dataGridView1.TabIndex = 0;
            // 
            // addPrinterButton
            // 
            this.addPrinterButton.Location = new System.Drawing.Point(967, 33);
            this.addPrinterButton.Name = "addPrinterButton";
            this.addPrinterButton.Size = new System.Drawing.Size(129, 36);
            this.addPrinterButton.TabIndex = 1;
            this.addPrinterButton.Text = "Добави Принтер";
            this.addPrinterButton.UseVisualStyleBackColor = true;
            this.addPrinterButton.Click += new System.EventHandler(this.addPrinterButton_Click);
            // 
            // editPrinterButton
            // 
            this.editPrinterButton.Location = new System.Drawing.Point(967, 75);
            this.editPrinterButton.Name = "editPrinterButton";
            this.editPrinterButton.Size = new System.Drawing.Size(129, 36);
            this.editPrinterButton.TabIndex = 2;
            this.editPrinterButton.Text = "Редактирай принтер";
            this.editPrinterButton.UseVisualStyleBackColor = true;
            this.editPrinterButton.Click += new System.EventHandler(this.editPrinterButton_Click);
            // 
            // deactivatePrinterButton
            // 
            this.deactivatePrinterButton.Location = new System.Drawing.Point(967, 159);
            this.deactivatePrinterButton.Name = "deactivatePrinterButton";
            this.deactivatePrinterButton.Size = new System.Drawing.Size(129, 36);
            this.deactivatePrinterButton.TabIndex = 3;
            this.deactivatePrinterButton.Text = "Деактивирай принтер";
            this.deactivatePrinterButton.UseVisualStyleBackColor = true;
            this.deactivatePrinterButton.Click += new System.EventHandler(this.deactivatePrinterButton_Click);
            // 
            // addPrinterModelButton
            // 
            this.addPrinterModelButton.Location = new System.Drawing.Point(967, 117);
            this.addPrinterModelButton.Name = "addPrinterModelButton";
            this.addPrinterModelButton.Size = new System.Drawing.Size(129, 36);
            this.addPrinterModelButton.TabIndex = 4;
            this.addPrinterModelButton.Text = "Добави модел принтер";
            this.addPrinterModelButton.UseVisualStyleBackColor = true;
            this.addPrinterModelButton.Click += new System.EventHandler(this.addPrinterModelButton_Click);
            // 
            // PrintersData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1143, 561);
            this.Controls.Add(this.addPrinterModelButton);
            this.Controls.Add(this.deactivatePrinterButton);
            this.Controls.Add(this.editPrinterButton);
            this.Controls.Add(this.addPrinterButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PrintersData";
            this.Text = "PrintersData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowPrinters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addPrinterButton;
        private System.Windows.Forms.Button editPrinterButton;
        private System.Windows.Forms.Button deactivatePrinterButton;
        private System.Windows.Forms.Button addPrinterModelButton;
    }
}