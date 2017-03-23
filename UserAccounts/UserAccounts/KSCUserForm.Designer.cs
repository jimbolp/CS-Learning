namespace UserAccounts
{
    partial class KSCUserForm
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
            this.kscUserTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kscUserTable)).BeginInit();
            this.SuspendLayout();
            // 
            // kscUserTable
            // 
            this.kscUserTable.AllowUserToAddRows = false;
            this.kscUserTable.AllowUserToDeleteRows = false;
            this.kscUserTable.AllowUserToOrderColumns = true;
            this.kscUserTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kscUserTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kscUserTable.Location = new System.Drawing.Point(12, 12);
            this.kscUserTable.Name = "kscUserTable";
            this.kscUserTable.Size = new System.Drawing.Size(851, 705);
            this.kscUserTable.TabIndex = 0;
            // 
            // KSCUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.kscUserTable);
            this.Name = "KSCUserForm";
            this.Text = "KSCUserForm";
            this.Load += new System.EventHandler(this.KSCUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kscUserTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView kscUserTable;
    }
}