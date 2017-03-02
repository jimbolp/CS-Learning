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
            this.chckBoxBranches = new System.Windows.Forms.CheckedListBox();
            this.groupFilters = new System.Windows.Forms.GroupBox();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_Customize = new System.Windows.Forms.Button();
            this.userDBTable = new UserAccounts.CustomDataGridView();
            this.groupFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).BeginInit();
            this.SuspendLayout();
            // 
            // chckBoxBranches
            // 
            this.chckBoxBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckBoxBranches.CheckOnClick = true;
            this.chckBoxBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chckBoxBranches.FormattingEnabled = true;
            this.chckBoxBranches.Location = new System.Drawing.Point(6, 19);
            this.chckBoxBranches.Name = "chckBoxBranches";
            this.chckBoxBranches.Size = new System.Drawing.Size(169, 94);
            this.chckBoxBranches.TabIndex = 2;
            this.chckBoxBranches.ThreeDCheckBoxes = true;
            this.chckBoxBranches.SelectedIndexChanged += new System.EventHandler(this.chckBoxBranches_SelectedIndexChanged);
            // 
            // groupFilters
            // 
            this.groupFilters.Controls.Add(this.btn_EditUser);
            this.groupFilters.Controls.Add(this.btn_AddUser);
            this.groupFilters.Controls.Add(this.btn_Customize);
            this.groupFilters.Controls.Add(this.chckBoxBranches);
            this.groupFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupFilters.Location = new System.Drawing.Point(827, 0);
            this.groupFilters.Name = "groupFilters";
            this.groupFilters.Size = new System.Drawing.Size(181, 729);
            this.groupFilters.TabIndex = 3;
            this.groupFilters.TabStop = false;
            this.groupFilters.Text = "Filter";
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditUser.Location = new System.Drawing.Point(6, 177);
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
            this.btn_AddUser.Location = new System.Drawing.Point(6, 148);
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
            this.btn_Customize.Location = new System.Drawing.Point(6, 119);
            this.btn_Customize.Name = "btn_Customize";
            this.btn_Customize.Size = new System.Drawing.Size(169, 23);
            this.btn_Customize.TabIndex = 3;
            this.btn_Customize.Text = "Customize";
            this.btn_Customize.UseVisualStyleBackColor = true;
            this.btn_Customize.Click += new System.EventHandler(this.btn_Customize_Click);
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
            this.userDBTable.Size = new System.Drawing.Size(821, 730);
            this.userDBTable.TabIndex = 1;
            this.userDBTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDBTable_CellClick);
            this.userDBTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDBTable_ColumnHeaderMouseClick);
            // 
            // ShowUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupFilters);
            this.Controls.Add(this.userDBTable);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "ShowUsersForm";
            this.Text = "SearchUserForm";
            this.Load += new System.EventHandler(this.SearchUserForm_Load);
            this.VisibleChanged += new System.EventHandler(this.SearchUserForm_VisibleChanged);
            this.groupFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserAccounts.CustomDataGridView userDBTable;
        private System.Windows.Forms.CheckedListBox chckBoxBranches;
        private System.Windows.Forms.GroupBox groupFilters;
        private System.Windows.Forms.Button btn_Customize;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_EditUser;
    }
}