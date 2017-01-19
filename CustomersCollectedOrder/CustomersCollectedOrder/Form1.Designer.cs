namespace CustomersCollectedOrder
{
    partial class CustomersCollectedOrders
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
            this.customerNoTextBox = new System.Windows.Forms.TextBox();
            this.customerIDF = new System.Windows.Forms.Label();
            this.routeTextBox = new System.Windows.Forms.TextBox();
            this.customerRoute = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.buttonResult = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerNoTextBox
            // 
            this.customerNoTextBox.Location = new System.Drawing.Point(12, 59);
            this.customerNoTextBox.Name = "customerNoTextBox";
            this.customerNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerNoTextBox.TabIndex = 0;
            this.customerNoTextBox.TextChanged += new System.EventHandler(this.customerNoTextBox_TextChanged);
            // 
            // customerIDF
            // 
            this.customerIDF.AutoSize = true;
            this.customerIDF.Location = new System.Drawing.Point(9, 27);
            this.customerIDF.Name = "customerIDF";
            this.customerIDF.Size = new System.Drawing.Size(96, 13);
            this.customerIDF.TabIndex = 0;
            this.customerIDF.Text = "Клиентски номер";
            // 
            // routeTextBox
            // 
            this.routeTextBox.Location = new System.Drawing.Point(120, 59);
            this.routeTextBox.Name = "routeTextBox";
            this.routeTextBox.Size = new System.Drawing.Size(100, 20);
            this.routeTextBox.TabIndex = 1;
            this.routeTextBox.TextChanged += new System.EventHandler(this.routeTextBox_TextChanged);
            // 
            // customerRoute
            // 
            this.customerRoute.AutoSize = true;
            this.customerRoute.Location = new System.Drawing.Point(143, 27);
            this.customerRoute.Name = "customerRoute";
            this.customerRoute.Size = new System.Drawing.Size(52, 13);
            this.customerRoute.TabIndex = 1;
            this.customerRoute.Text = "Маршрут";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(117, 131);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(78, 13);
            this.time.TabIndex = 5;
            this.time.Text = "Време в SK16";
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.Location = new System.Drawing.Point(15, 159);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(323, 79);
            this.labelResult.TabIndex = 5;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(226, 59);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox.TabIndex = 2;
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            this.timeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timeTextBox_KeyDown);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(244, 27);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(62, 13);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "Време/час";
            // 
            // buttonResult
            // 
            this.buttonResult.Location = new System.Drawing.Point(15, 103);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(145, 25);
            this.buttonResult.TabIndex = 3;
            this.buttonResult.Text = "Изчисли време";
            this.buttonResult.UseVisualStyleBackColor = true;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(181, 103);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(145, 25);
            this.clear.TabIndex = 4;
            this.clear.Text = "Нов клиент";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // CustomersCollectedOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 264);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.time);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.customerRoute);
            this.Controls.Add(this.routeTextBox);
            this.Controls.Add(this.customerIDF);
            this.Controls.Add(this.customerNoTextBox);
            this.Name = "CustomersCollectedOrders";
            this.Text = "CustomersCollectedOrder";
            this.Load += new System.EventHandler(this.CustomersCollectedOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerNoTextBox;
        private System.Windows.Forms.Label customerIDF;
        private System.Windows.Forms.TextBox routeTextBox;
        private System.Windows.Forms.Label customerRoute;        
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button clear;
    }
}

