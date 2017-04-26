namespace Dixel_Sensors
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.startWorking = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.combineFiles = new System.Windows.Forms.Button();
            this.printCheckBox = new System.Windows.Forms.CheckBox();
            this.graphicsCheckBox = new System.Windows.Forms.CheckBox();
            this.tempsCheckBox = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.AllowDrop = true;
            this.filePathTextBox.Location = new System.Drawing.Point(45, 35);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(210, 20);
            this.filePathTextBox.TabIndex = 0;
            this.filePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.filePathTextBox_DragDrop);
            this.filePathTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.filePathTextBox_DragOver);
            // 
            // startWorking
            // 
            this.startWorking.Location = new System.Drawing.Point(45, 159);
            this.startWorking.Name = "startWorking";
            this.startWorking.Size = new System.Drawing.Size(75, 23);
            this.startWorking.TabIndex = 1;
            this.startWorking.Text = "Start";
            this.startWorking.UseVisualStyleBackColor = true;
            this.startWorking.Click += new System.EventHandler(this.startWorking_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoEllipsis = true;
            this.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultLabel.Location = new System.Drawing.Point(0, 212);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(348, 132);
            this.resultLabel.TabIndex = 2;
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.Location = new System.Drawing.Point(12, 159);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(0, 13);
            this.sheetNameLabel.TabIndex = 3;
            // 
            // combineFiles
            // 
            this.combineFiles.Enabled = false;
            this.combineFiles.Location = new System.Drawing.Point(180, 159);
            this.combineFiles.Name = "combineFiles";
            this.combineFiles.Size = new System.Drawing.Size(75, 23);
            this.combineFiles.TabIndex = 4;
            this.combineFiles.Text = "button1";
            this.combineFiles.UseVisualStyleBackColor = true;
            this.combineFiles.Visible = false;
            this.combineFiles.Click += new System.EventHandler(this.combineFiles_Click);
            // 
            // printCheckBox
            // 
            this.printCheckBox.AutoSize = true;
            this.printCheckBox.Enabled = false;
            this.printCheckBox.Location = new System.Drawing.Point(45, 107);
            this.printCheckBox.Name = "printCheckBox";
            this.printCheckBox.Size = new System.Drawing.Size(138, 17);
            this.printCheckBox.TabIndex = 5;
            this.printCheckBox.Text = "Принтирай графиките";
            this.printCheckBox.UseVisualStyleBackColor = true;
            // 
            // graphicsCheckBox
            // 
            this.graphicsCheckBox.AutoSize = true;
            this.graphicsCheckBox.Location = new System.Drawing.Point(45, 84);
            this.graphicsCheckBox.Name = "graphicsCheckBox";
            this.graphicsCheckBox.Size = new System.Drawing.Size(143, 17);
            this.graphicsCheckBox.TabIndex = 6;
            this.graphicsCheckBox.Text = "Създаване на графики";
            this.graphicsCheckBox.UseVisualStyleBackColor = true;
            this.graphicsCheckBox.CheckedChanged += new System.EventHandler(this.graphicsCheckBox_CheckedChanged);
            // 
            // tempsCheckBox
            // 
            this.tempsCheckBox.AutoSize = true;
            this.tempsCheckBox.Location = new System.Drawing.Point(45, 61);
            this.tempsCheckBox.Name = "tempsCheckBox";
            this.tempsCheckBox.Size = new System.Drawing.Size(180, 17);
            this.tempsCheckBox.TabIndex = 7;
            this.tempsCheckBox.Text = "Преработване на стойностите";
            this.tempsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 130);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(185, 130);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 344);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tempsCheckBox);
            this.Controls.Add(this.graphicsCheckBox);
            this.Controls.Add(this.printCheckBox);
            this.Controls.Add(this.combineFiles);
            this.Controls.Add(this.sheetNameLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.startWorking);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Temps Change";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button startWorking;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.Button combineFiles;
        private System.Windows.Forms.CheckBox printCheckBox;
        private System.Windows.Forms.CheckBox graphicsCheckBox;
        private System.Windows.Forms.CheckBox tempsCheckBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}

