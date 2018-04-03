namespace CustomerReturns
{
    partial class CustomerReturns
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
            this.InvoiceNoLabel = new System.Windows.Forms.Label();
            this.InvoiceDateLabel = new System.Windows.Forms.Label();
            this.branchLabel = new System.Windows.Forms.Label();
            this.invoiceNoTextBox = new System.Windows.Forms.TextBox();
            this.invoiceDateTextBox = new System.Windows.Forms.TextBox();
            this.branchTextBox = new System.Windows.Forms.TextBox();
            this.buttonResult = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.nextInvoiceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InvoiceNoLabel
            // 
            this.InvoiceNoLabel.AutoSize = true;
            this.InvoiceNoLabel.Location = new System.Drawing.Point(12, 11);
            this.InvoiceNoLabel.Name = "InvoiceNoLabel";
            this.InvoiceNoLabel.Size = new System.Drawing.Size(87, 13);
            this.InvoiceNoLabel.TabIndex = 8;
            this.InvoiceNoLabel.Text = "Фактура номер";
            // 
            // InvoiceDateLabel
            // 
            this.InvoiceDateLabel.AutoSize = true;
            this.InvoiceDateLabel.Location = new System.Drawing.Point(150, 11);
            this.InvoiceDateLabel.Name = "InvoiceDateLabel";
            this.InvoiceDateLabel.Size = new System.Drawing.Size(33, 13);
            this.InvoiceDateLabel.TabIndex = 9;
            this.InvoiceDateLabel.Text = "Дата";
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Location = new System.Drawing.Point(357, 11);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(48, 13);
            this.branchLabel.TabIndex = 11;
            this.branchLabel.Text = "Филиал";
            // 
            // invoiceNoTextBox
            // 
            this.invoiceNoTextBox.Location = new System.Drawing.Point(12, 27);
            this.invoiceNoTextBox.Name = "invoiceNoTextBox";
            this.invoiceNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.invoiceNoTextBox.TabIndex = 0;
            this.invoiceNoTextBox.TextChanged += new System.EventHandler(this.invoiceNoTextBox_TextChanged);
            // 
            // invoiceDateTextBox
            // 
            this.invoiceDateTextBox.Location = new System.Drawing.Point(118, 27);
            this.invoiceDateTextBox.Name = "invoiceDateTextBox";
            this.invoiceDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.invoiceDateTextBox.TabIndex = 1;
            // 
            // branchTextBox
            // 
            this.branchTextBox.Location = new System.Drawing.Point(330, 27);
            this.branchTextBox.Name = "branchTextBox";
            this.branchTextBox.Size = new System.Drawing.Size(100, 20);
            this.branchTextBox.TabIndex = 3;
            // 
            // buttonResult
            // 
            this.buttonResult.Location = new System.Drawing.Point(153, 62);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(141, 23);
            this.buttonResult.TabIndex = 5;
            this.buttonResult.Text = "Генерирай формат";
            this.buttonResult.UseVisualStyleBackColor = true;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.Location = new System.Drawing.Point(0, 146);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(443, 143);
            this.labelResult.TabIndex = 7;
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(235, 11);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(78, 13);
            this.customerLabel.TabIndex = 10;
            this.customerLabel.Text = "Клиент номер";
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(224, 27);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerTextBox.TabIndex = 2;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(300, 62);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(130, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Ново въвеждане";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // nextInvoiceButton
            // 
            this.nextInvoiceButton.Location = new System.Drawing.Point(12, 62);
            this.nextInvoiceButton.Name = "nextInvoiceButton";
            this.nextInvoiceButton.Size = new System.Drawing.Size(135, 23);
            this.nextInvoiceButton.TabIndex = 4;
            this.nextInvoiceButton.Text = "Следваща фактура";
            this.nextInvoiceButton.UseVisualStyleBackColor = true;
            this.nextInvoiceButton.Click += new System.EventHandler(this.nextInvoiceButton_Click);
            // 
            // CustomerReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 289);
            this.Controls.Add(this.nextInvoiceButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.branchTextBox);
            this.Controls.Add(this.invoiceDateTextBox);
            this.Controls.Add(this.invoiceNoTextBox);
            this.Controls.Add(this.branchLabel);
            this.Controls.Add(this.InvoiceDateLabel);
            this.Controls.Add(this.InvoiceNoLabel);
            this.Name = "CustomerReturns";
            this.Text = "Generate Mail Format";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InvoiceNoLabel;
        private System.Windows.Forms.Label InvoiceDateLabel;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.TextBox invoiceNoTextBox;
        private System.Windows.Forms.TextBox invoiceDateTextBox;
        private System.Windows.Forms.TextBox branchTextBox;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button nextInvoiceButton;
    }
}

