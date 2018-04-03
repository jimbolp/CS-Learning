namespace Control_Digit
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
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pznTextBox = new System.Windows.Forms.TextBox();
            this.pznLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(46, 32);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(99, 20);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(43, 16);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "ID ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(173, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "->";
            // 
            // pznTextBox
            // 
            this.pznTextBox.HideSelection = false;
            this.pznTextBox.Location = new System.Drawing.Point(220, 32);
            this.pznTextBox.MaxLength = 9999999;
            this.pznTextBox.Name = "pznTextBox";
            this.pznTextBox.ReadOnly = true;
            this.pznTextBox.Size = new System.Drawing.Size(99, 20);
            this.pznTextBox.TabIndex = 3;
            this.pznTextBox.TextChanged += new System.EventHandler(this.pznTextBox_TextChanged);
            // 
            // pznLabel
            // 
            this.pznLabel.AutoSize = true;
            this.pznLabel.Location = new System.Drawing.Point(217, 16);
            this.pznLabel.Name = "pznLabel";
            this.pznLabel.Size = new System.Drawing.Size(29, 13);
            this.pznLabel.TabIndex = 4;
            this.pznLabel.Text = "PZN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 99);
            this.Controls.Add(this.pznLabel);
            this.Controls.Add(this.pznTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pznTextBox;
        private System.Windows.Forms.Label pznLabel;
    }
}

