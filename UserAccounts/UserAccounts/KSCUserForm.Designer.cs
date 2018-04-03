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
            this.btn_EditKSCAccount = new System.Windows.Forms.Button();
            this.btn_newKSCAccount = new System.Windows.Forms.Button();
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
            this.kscUserTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.kscUserTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kscUserTable.GridColor = System.Drawing.SystemColors.Control;
            this.kscUserTable.Location = new System.Drawing.Point(12, 12);
            this.kscUserTable.Name = "kscUserTable";
            this.kscUserTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.kscUserTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kscUserTable.Size = new System.Drawing.Size(851, 705);
            this.kscUserTable.TabIndex = 0;
            // 
            // btn_EditKSCAccount
            // 
            this.btn_EditKSCAccount.Location = new System.Drawing.Point(869, 30);
            this.btn_EditKSCAccount.Name = "btn_EditKSCAccount";
            this.btn_EditKSCAccount.Size = new System.Drawing.Size(127, 23);
            this.btn_EditKSCAccount.TabIndex = 1;
            this.btn_EditKSCAccount.Text = "Редактирай";
            this.btn_EditKSCAccount.UseVisualStyleBackColor = true;
            this.btn_EditKSCAccount.Click += new System.EventHandler(this.btn_EditKSCAccount_Click);
            // 
            // btn_newKSCAccount
            // 
            this.btn_newKSCAccount.Location = new System.Drawing.Point(869, 59);
            this.btn_newKSCAccount.Name = "btn_newKSCAccount";
            this.btn_newKSCAccount.Size = new System.Drawing.Size(127, 23);
            this.btn_newKSCAccount.TabIndex = 2;
            this.btn_newKSCAccount.Text = "Нов Акаунт";
            this.btn_newKSCAccount.UseVisualStyleBackColor = true;
            this.btn_newKSCAccount.Click += new System.EventHandler(this.btn_newKSCAccount_Click);
            // 
            // KSCUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btn_newKSCAccount);
            this.Controls.Add(this.btn_EditKSCAccount);
            this.Controls.Add(this.kscUserTable);
            this.Name = "KSCUserForm";
            this.Text = "KSCUserForm";
            this.Load += new System.EventHandler(this.KSCUserForm_Load);
            this.Shown += new System.EventHandler(this.KSCUserForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kscUserTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView kscUserTable;
        private System.Windows.Forms.Button btn_EditKSCAccount;
        private System.Windows.Forms.Button btn_newKSCAccount;
    }
}