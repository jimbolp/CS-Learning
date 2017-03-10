namespace UserAccounts
{
    partial class ShowUsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowUsersForm));
            this.listBoxBranches = new System.Windows.Forms.ListBox();
            this.groupFilters = new System.Windows.Forms.GroupBox();
            this.chckBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.btn_FilterPos = new System.Windows.Forms.Button();
            this.listBoxPositions = new System.Windows.Forms.ListBox();
            this.btn_KSCAccount = new System.Windows.Forms.Button();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_Customize = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userDBTable = new UserAccounts.CustomDataGridView();
            this.groupFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxBranches
            // 
            this.listBoxBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxBranches.FormattingEnabled = true;
            this.listBoxBranches.Location = new System.Drawing.Point(6, 19);
            this.listBoxBranches.Name = "listBoxBranches";
            this.listBoxBranches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxBranches.Size = new System.Drawing.Size(155, 95);
            this.listBoxBranches.TabIndex = 10;
            this.listBoxBranches.SelectedIndexChanged += new System.EventHandler(this.listBoxBranches_SelectedIndexChanged);
            // 
            // groupFilters
            // 
            this.groupFilters.Controls.Add(this.groupBox2);
            this.groupFilters.Controls.Add(this.groupBox1);
            this.groupFilters.Controls.Add(this.btn_KSCAccount);
            this.groupFilters.Controls.Add(this.btn_EditUser);
            this.groupFilters.Controls.Add(this.btn_AddUser);
            this.groupFilters.Controls.Add(this.btn_Customize);
            this.groupFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupFilters.Location = new System.Drawing.Point(810, 0);
            this.groupFilters.Name = "groupFilters";
            this.groupFilters.Size = new System.Drawing.Size(198, 730);
            this.groupFilters.TabIndex = 3;
            this.groupFilters.TabStop = false;
            this.groupFilters.Text = "Filter";
            // 
            // chckBoxSelectAll
            // 
            this.chckBoxSelectAll.AutoSize = true;
            this.chckBoxSelectAll.Checked = true;
            this.chckBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBoxSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chckBoxSelectAll.Location = new System.Drawing.Point(6, 19);
            this.chckBoxSelectAll.Name = "chckBoxSelectAll";
            this.chckBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chckBoxSelectAll.TabIndex = 9;
            this.chckBoxSelectAll.Text = "Select All";
            this.chckBoxSelectAll.UseVisualStyleBackColor = true;
            this.chckBoxSelectAll.CheckedChanged += new System.EventHandler(this.chckBoxSelectAll_CheckedChanged);
            // 
            // btn_FilterPos
            // 
            this.btn_FilterPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_FilterPos.Location = new System.Drawing.Point(1, 143);
            this.btn_FilterPos.Name = "btn_FilterPos";
            this.btn_FilterPos.Size = new System.Drawing.Size(169, 23);
            this.btn_FilterPos.TabIndex = 8;
            this.btn_FilterPos.Text = "Филтрирай";
            this.btn_FilterPos.UseVisualStyleBackColor = true;
            this.btn_FilterPos.Click += new System.EventHandler(this.btn_FilterPos_Click);
            // 
            // listBoxPositions
            // 
            this.listBoxPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPositions.FormattingEnabled = true;
            this.listBoxPositions.Location = new System.Drawing.Point(6, 42);
            this.listBoxPositions.Name = "listBoxPositions";
            this.listBoxPositions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPositions.Size = new System.Drawing.Size(155, 95);
            this.listBoxPositions.TabIndex = 7;
            this.listBoxPositions.SelectedIndexChanged += new System.EventHandler(this.listBoxPositions_SelectedIndexChanged);
            // 
            // btn_KSCAccount
            // 
            this.btn_KSCAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_KSCAccount.Location = new System.Drawing.Point(8, 415);
            this.btn_KSCAccount.Name = "btn_KSCAccount";
            this.btn_KSCAccount.Size = new System.Drawing.Size(169, 23);
            this.btn_KSCAccount.TabIndex = 6;
            this.btn_KSCAccount.Text = "KSC Акаунт";
            this.btn_KSCAccount.UseVisualStyleBackColor = true;
            this.btn_KSCAccount.Click += new System.EventHandler(this.btn_KSCAccount_Click);
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditUser.Location = new System.Drawing.Point(8, 386);
            this.btn_EditUser.Name = "btn_EditUser";
            this.btn_EditUser.Size = new System.Drawing.Size(169, 23);
            this.btn_EditUser.TabIndex = 5;
            this.btn_EditUser.Text = "Промени Потребител";
            this.btn_EditUser.UseVisualStyleBackColor = true;
            this.btn_EditUser.Click += new System.EventHandler(this.btn_EditUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddUser.Location = new System.Drawing.Point(8, 357);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(169, 23);
            this.btn_AddUser.TabIndex = 4;
            this.btn_AddUser.Text = "Добави Потребител";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_Customize
            // 
            this.btn_Customize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Customize.Location = new System.Drawing.Point(8, 328);
            this.btn_Customize.Name = "btn_Customize";
            this.btn_Customize.Size = new System.Drawing.Size(169, 23);
            this.btn_Customize.TabIndex = 3;
            this.btn_Customize.Text = "Customize";
            this.btn_Customize.UseVisualStyleBackColor = true;
            this.btn_Customize.Click += new System.EventHandler(this.btn_Customize_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chckBoxSelectAll);
            this.groupBox1.Controls.Add(this.listBoxPositions);
            this.groupBox1.Controls.Add(this.btn_FilterPos);
            this.groupBox1.Location = new System.Drawing.Point(7, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 177);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Длъжности";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxBranches);
            this.groupBox2.Location = new System.Drawing.Point(7, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 120);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Складове";
            // 
            // userDBTable
            // 
            this.userDBTable.AllowUserToAddRows = false;
            this.userDBTable.AllowUserToDeleteRows = false;
            this.userDBTable.AllowUserToOrderColumns = true;
            this.userDBTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userDBTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDBTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.userDBTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDBTable.GridColor = System.Drawing.SystemColors.Control;
            this.userDBTable.Location = new System.Drawing.Point(0, 0);
            this.userDBTable.Name = "userDBTable";
            this.userDBTable.ReadOnly = true;
            this.userDBTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userDBTable.Size = new System.Drawing.Size(804, 730);
            this.userDBTable.TabIndex = 1;
            this.userDBTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDBTable_CellDoubleClick);
            this.userDBTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDBTable_ColumnHeaderMouseClick);
            // 
            // ShowUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupFilters);
            this.Controls.Add(this.userDBTable);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "ShowUsersForm";
            this.Text = "Потребители";
            this.Load += new System.EventHandler(this.SearchUserForm_Load);
            this.VisibleChanged += new System.EventHandler(this.SearchUserForm_VisibleChanged);
            this.groupFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserAccounts.CustomDataGridView userDBTable;
        //private System.Windows.Forms.CheckedListBox listBoxBranches;
        private System.Windows.Forms.GroupBox groupFilters;
        private System.Windows.Forms.Button btn_Customize;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_EditUser;
        private System.Windows.Forms.Button btn_KSCAccount;
        private System.Windows.Forms.ListBox listBoxPositions;
        private System.Windows.Forms.Button btn_FilterPos;
        private System.Windows.Forms.CheckBox chckBoxSelectAll;
        private System.Windows.Forms.ListBox listBoxBranches;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}