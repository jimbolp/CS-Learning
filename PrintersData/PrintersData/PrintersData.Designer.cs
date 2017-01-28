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
            this.printerNameLabel = new System.Windows.Forms.Label();
            this.printerNameTextBox = new System.Windows.Forms.TextBox();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.IPAddresstextBox = new System.Windows.Forms.TextBox();
            this.printerModelLabel = new System.Windows.Forms.Label();
            this.listPrinterModels = new System.Windows.Forms.ComboBox();
            this.branchLabel = new System.Windows.Forms.Label();
            this.listBranches = new System.Windows.Forms.ComboBox();
            this.printIDLabel = new System.Windows.Forms.Label();
            this.printIDTextBox2 = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addPrinterButton = new System.Windows.Forms.Button();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printerNameLabel
            // 
            this.printerNameLabel.AutoSize = true;
            this.printerNameLabel.Location = new System.Drawing.Point(13, 31);
            this.printerNameLabel.Name = "printerNameLabel";
            this.printerNameLabel.Size = new System.Drawing.Size(65, 13);
            this.printerNameLabel.TabIndex = 0;
            this.printerNameLabel.Text = "Priner Name";
            // 
            // printerNameTextBox
            // 
            this.printerNameTextBox.Location = new System.Drawing.Point(13, 48);
            this.printerNameTextBox.Name = "printerNameTextBox";
            this.printerNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.printerNameTextBox.TabIndex = 1;
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Location = new System.Drawing.Point(13, 75);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.IPAddressLabel.TabIndex = 2;
            this.IPAddressLabel.Text = "IP Address";
            // 
            // IPAddresstextBox
            // 
            this.IPAddresstextBox.Location = new System.Drawing.Point(13, 92);
            this.IPAddresstextBox.Name = "IPAddresstextBox";
            this.IPAddresstextBox.Size = new System.Drawing.Size(150, 20);
            this.IPAddresstextBox.TabIndex = 3;
            // 
            // printerModelLabel
            // 
            this.printerModelLabel.AutoSize = true;
            this.printerModelLabel.Location = new System.Drawing.Point(10, 115);
            this.printerModelLabel.Name = "printerModelLabel";
            this.printerModelLabel.Size = new System.Drawing.Size(69, 13);
            this.printerModelLabel.TabIndex = 4;
            this.printerModelLabel.Text = "Printer Model";
            // 
            // listPrinterModels
            // 
            this.listPrinterModels.FormattingEnabled = true;
            this.listPrinterModels.Location = new System.Drawing.Point(12, 131);
            this.listPrinterModels.Name = "listPrinterModels";
            this.listPrinterModels.Size = new System.Drawing.Size(181, 21);
            this.listPrinterModels.TabIndex = 5;
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Location = new System.Drawing.Point(241, 30);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(41, 13);
            this.branchLabel.TabIndex = 6;
            this.branchLabel.Text = "Branch";
            // 
            // listBranches
            // 
            this.listBranches.FormattingEnabled = true;
            this.listBranches.Location = new System.Drawing.Point(244, 48);
            this.listBranches.Name = "listBranches";
            this.listBranches.Size = new System.Drawing.Size(151, 21);
            this.listBranches.TabIndex = 7;
            // 
            // printIDLabel
            // 
            this.printIDLabel.AutoSize = true;
            this.printIDLabel.Location = new System.Drawing.Point(12, 158);
            this.printIDLabel.Name = "printIDLabel";
            this.printIDLabel.Size = new System.Drawing.Size(42, 13);
            this.printIDLabel.TabIndex = 8;
            this.printIDLabel.Text = "Print ID";
            // 
            // printIDTextBox2
            // 
            this.printIDTextBox2.Location = new System.Drawing.Point(12, 175);
            this.printIDTextBox2.Name = "printIDTextBox2";
            this.printIDTextBox2.Size = new System.Drawing.Size(151, 20);
            this.printIDTextBox2.TabIndex = 9;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(244, 76);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "Descritption";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(244, 92);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(151, 20);
            this.descriptionTextBox.TabIndex = 11;
            // 
            // addPrinterButton
            // 
            this.addPrinterButton.Location = new System.Drawing.Point(12, 229);
            this.addPrinterButton.Name = "addPrinterButton";
            this.addPrinterButton.Size = new System.Drawing.Size(383, 23);
            this.addPrinterButton.TabIndex = 12;
            this.addPrinterButton.Text = "Add Printer";
            this.addPrinterButton.UseVisualStyleBackColor = true;
            this.addPrinterButton.Click += new System.EventHandler(this.addPrinterButton_Click);
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(244, 131);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckBox.TabIndex = 13;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(0, 322);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(623, 102);
            this.labelResult.TabIndex = 14;
            // 
            // PrintersData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 424);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.addPrinterButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.printIDTextBox2);
            this.Controls.Add(this.printIDLabel);
            this.Controls.Add(this.listBranches);
            this.Controls.Add(this.branchLabel);
            this.Controls.Add(this.listPrinterModels);
            this.Controls.Add(this.printerModelLabel);
            this.Controls.Add(this.IPAddresstextBox);
            this.Controls.Add(this.IPAddressLabel);
            this.Controls.Add(this.printerNameTextBox);
            this.Controls.Add(this.printerNameLabel);
            this.Name = "PrintersData";
            this.Text = "PrintersData";
            this.Load += new System.EventHandler(this.PrintersData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label printerNameLabel;
        private System.Windows.Forms.TextBox printerNameTextBox;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.TextBox IPAddresstextBox;
        private System.Windows.Forms.Label printerModelLabel;
        private System.Windows.Forms.ComboBox listPrinterModels;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.ComboBox listBranches;
        private System.Windows.Forms.Label printIDLabel;
        private System.Windows.Forms.TextBox printIDTextBox2;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button addPrinterButton;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Label labelResult;
    }
}

