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
            this.startWorking.Location = new System.Drawing.Point(45, 94);
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
            this.resultLabel.Location = new System.Drawing.Point(0, 172);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(376, 121);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 293);
            this.Controls.Add(this.sheetNameLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.startWorking);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Temps Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button startWorking;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label sheetNameLabel;
    }
}

