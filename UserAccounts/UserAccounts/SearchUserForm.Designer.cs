namespace UserAccounts
{
    partial class SearchUserForm
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
            this.userDBTable = new System.Windows.Forms.DataGridView();
            this.chckBoxBranches = new System.Windows.Forms.CheckedListBox();
            this.groupFilters = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).BeginInit();
            this.groupFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // userDBTable
            // 
            this.userDBTable.AllowUserToDeleteRows = false;
            this.userDBTable.AllowUserToOrderColumns = true;
            this.userDBTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userDBTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDBTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.userDBTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDBTable.GridColor = System.Drawing.SystemColors.Control;
            this.userDBTable.Location = new System.Drawing.Point(0, 427);
            this.userDBTable.Name = "userDBTable";
            this.userDBTable.Size = new System.Drawing.Size(821, 303);
            this.userDBTable.TabIndex = 1;
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
            // SearchUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupFilters);
            this.Controls.Add(this.userDBTable);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "SearchUserForm";
            this.Text = "SearchUserForm";
            this.Load += new System.EventHandler(this.SearchUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userDBTable)).EndInit();
            this.groupFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView userDBTable;
        private System.Windows.Forms.CheckedListBox chckBoxBranches;
        private System.Windows.Forms.GroupBox groupFilters;
    }
}