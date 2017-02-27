namespace PrintersData
{
    partial class AddPrinterModel
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
            this.printerModelTextBx = new System.Windows.Forms.TextBox();
            this.printerModelLabel = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.addPrinterModelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printerModelTextBx
            // 
            this.printerModelTextBx.Location = new System.Drawing.Point(33, 75);
            this.printerModelTextBx.Name = "printerModelTextBx";
            this.printerModelTextBx.Size = new System.Drawing.Size(181, 20);
            this.printerModelTextBx.TabIndex = 0;
            // 
            // printerModelLabel
            // 
            this.printerModelLabel.AutoSize = true;
            this.printerModelLabel.Location = new System.Drawing.Point(30, 48);
            this.printerModelLabel.Name = "printerModelLabel";
            this.printerModelLabel.Size = new System.Drawing.Size(86, 13);
            this.printerModelLabel.TabIndex = 1;
            this.printerModelLabel.Text = "Модел Принтер";
            // 
            // labelResult
            // 
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(0, 169);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(284, 92);
            this.labelResult.TabIndex = 2;
            // 
            // addPrinterModelBtn
            // 
            this.addPrinterModelBtn.Location = new System.Drawing.Point(33, 118);
            this.addPrinterModelBtn.Name = "addPrinterModelBtn";
            this.addPrinterModelBtn.Size = new System.Drawing.Size(181, 23);
            this.addPrinterModelBtn.TabIndex = 3;
            this.addPrinterModelBtn.Text = "Добави";
            this.addPrinterModelBtn.UseVisualStyleBackColor = true;
            this.addPrinterModelBtn.Click += new System.EventHandler(this.addPrinterModelBtn_Click);
            // 
            // AddPrinterModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addPrinterModelBtn);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.printerModelLabel);
            this.Controls.Add(this.printerModelTextBx);
            this.Name = "AddPrinterModel";
            this.Text = "AddPrinterModel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox printerModelTextBx;
        private System.Windows.Forms.Label printerModelLabel;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button addPrinterModelBtn;
    }
}