namespace UserAccounts
{
    partial class KSCAccount
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
            this.groupBoxKSC = new System.Windows.Forms.GroupBox();
            this.btn_createKSCAccount = new System.Windows.Forms.Button();
            this.chckBoxFC = new System.Windows.Forms.CheckBox();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.labelUID = new System.Windows.Forms.Label();
            this.textBoxTermID = new System.Windows.Forms.TextBox();
            this.labelTermID = new System.Windows.Forms.Label();
            this.textBoxKSCUserName = new System.Windows.Forms.TextBox();
            this.labelKSCUser = new System.Windows.Forms.Label();
            this.labelKSCBranches = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.btn_EditKSCAccount = new System.Windows.Forms.Button();
            this.listKSCBranches = new UserAccounts.ComboBoxCustom();
            this.groupBoxKSC.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxKSC
            // 
            this.groupBoxKSC.Controls.Add(this.btn_EditKSCAccount);
            this.groupBoxKSC.Controls.Add(this.btn_createKSCAccount);
            this.groupBoxKSC.Controls.Add(this.chckBoxFC);
            this.groupBoxKSC.Controls.Add(this.textBoxUID);
            this.groupBoxKSC.Controls.Add(this.labelUID);
            this.groupBoxKSC.Controls.Add(this.textBoxTermID);
            this.groupBoxKSC.Controls.Add(this.labelTermID);
            this.groupBoxKSC.Controls.Add(this.textBoxKSCUserName);
            this.groupBoxKSC.Controls.Add(this.labelKSCUser);
            this.groupBoxKSC.Controls.Add(this.labelKSCBranches);
            this.groupBoxKSC.Controls.Add(this.listKSCBranches);
            this.groupBoxKSC.Controls.Add(this.labelUserName);
            this.groupBoxKSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxKSC.Location = new System.Drawing.Point(12, 12);
            this.groupBoxKSC.Name = "groupBoxKSC";
            this.groupBoxKSC.Size = new System.Drawing.Size(408, 201);
            this.groupBoxKSC.TabIndex = 3;
            this.groupBoxKSC.TabStop = false;
            this.groupBoxKSC.Text = "Създаване на KSC потребител";
            // 
            // btn_createKSCAccount
            // 
            this.btn_createKSCAccount.Enabled = false;
            this.btn_createKSCAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_createKSCAccount.Location = new System.Drawing.Point(6, 146);
            this.btn_createKSCAccount.Name = "btn_createKSCAccount";
            this.btn_createKSCAccount.Size = new System.Drawing.Size(128, 23);
            this.btn_createKSCAccount.TabIndex = 21;
            this.btn_createKSCAccount.Text = "Добави KSC акаунт";
            this.btn_createKSCAccount.UseVisualStyleBackColor = true;
            this.btn_createKSCAccount.Click += new System.EventHandler(this.btn_createKSCAccount_Click);
            // 
            // chckBoxFC
            // 
            this.chckBoxFC.AutoSize = true;
            this.chckBoxFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chckBoxFC.Location = new System.Drawing.Point(6, 123);
            this.chckBoxFC.Name = "chckBoxFC";
            this.chckBoxFC.Size = new System.Drawing.Size(67, 17);
            this.chckBoxFC.TabIndex = 20;
            this.chckBoxFC.Text = "Allow FC";
            this.chckBoxFC.UseVisualStyleBackColor = true;
            // 
            // textBoxUID
            // 
            this.textBoxUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUID.Location = new System.Drawing.Point(200, 97);
            this.textBoxUID.MaxLength = 3;
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(74, 20);
            this.textBoxUID.TabIndex = 19;
            // 
            // labelUID
            // 
            this.labelUID.AutoSize = true;
            this.labelUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUID.Location = new System.Drawing.Point(197, 81);
            this.labelUID.Name = "labelUID";
            this.labelUID.Size = new System.Drawing.Size(26, 13);
            this.labelUID.TabIndex = 18;
            this.labelUID.Text = "UID";
            // 
            // textBoxTermID
            // 
            this.textBoxTermID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTermID.Location = new System.Drawing.Point(120, 97);
            this.textBoxTermID.MaxLength = 4;
            this.textBoxTermID.Name = "textBoxTermID";
            this.textBoxTermID.Size = new System.Drawing.Size(74, 20);
            this.textBoxTermID.TabIndex = 17;
            // 
            // labelTermID
            // 
            this.labelTermID.AutoSize = true;
            this.labelTermID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTermID.Location = new System.Drawing.Point(117, 81);
            this.labelTermID.Name = "labelTermID";
            this.labelTermID.Size = new System.Drawing.Size(45, 13);
            this.labelTermID.TabIndex = 16;
            this.labelTermID.Text = "Term ID";
            // 
            // textBoxKSCUserName
            // 
            this.textBoxKSCUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKSCUserName.Location = new System.Drawing.Point(6, 97);
            this.textBoxKSCUserName.Name = "textBoxKSCUserName";
            this.textBoxKSCUserName.Size = new System.Drawing.Size(108, 20);
            this.textBoxKSCUserName.TabIndex = 15;
            // 
            // labelKSCUser
            // 
            this.labelKSCUser.AutoSize = true;
            this.labelKSCUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKSCUser.Location = new System.Drawing.Point(3, 81);
            this.labelKSCUser.Name = "labelKSCUser";
            this.labelKSCUser.Size = new System.Drawing.Size(79, 13);
            this.labelKSCUser.TabIndex = 14;
            this.labelKSCUser.Text = "KSC Username";
            // 
            // labelKSCBranches
            // 
            this.labelKSCBranches.AutoSize = true;
            this.labelKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKSCBranches.Location = new System.Drawing.Point(277, 81);
            this.labelKSCBranches.Name = "labelKSCBranches";
            this.labelKSCBranches.Size = new System.Drawing.Size(38, 13);
            this.labelKSCBranches.TabIndex = 12;
            this.labelKSCBranches.Text = "Склад";
            // 
            // labelUserName
            // 
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(3, 38);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(271, 27);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "Потребител";
            // 
            // btn_EditKSCAccount
            // 
            this.btn_EditKSCAccount.Enabled = false;
            this.btn_EditKSCAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditKSCAccount.Location = new System.Drawing.Point(6, 146);
            this.btn_EditKSCAccount.Name = "btn_EditKSCAccount";
            this.btn_EditKSCAccount.Size = new System.Drawing.Size(128, 23);
            this.btn_EditKSCAccount.TabIndex = 22;
            this.btn_EditKSCAccount.Text = "Запази промените";
            this.btn_EditKSCAccount.UseVisualStyleBackColor = true;
            this.btn_EditKSCAccount.Click += new System.EventHandler(this.btn_EditKSCAccount_Click);
            // 
            // listKSCBranches
            // 
            this.listKSCBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listKSCBranches.FormattingEnabled = true;
            this.listKSCBranches.Location = new System.Drawing.Point(280, 96);
            this.listKSCBranches.Name = "listKSCBranches";
            this.listKSCBranches.Size = new System.Drawing.Size(121, 21);
            this.listKSCBranches.TabIndex = 11;
            // 
            // KSCAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 225);
            this.Controls.Add(this.groupBoxKSC);
            this.Name = "KSCAccount";
            this.Text = "KSCAccount";
            this.Load += new System.EventHandler(this.KSCAccount_Load);
            this.groupBoxKSC.ResumeLayout(false);
            this.groupBoxKSC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxKSC;
        private System.Windows.Forms.Button btn_createKSCAccount;
        private System.Windows.Forms.CheckBox chckBoxFC;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label labelUID;
        private System.Windows.Forms.TextBox textBoxTermID;
        private System.Windows.Forms.Label labelTermID;
        private System.Windows.Forms.TextBox textBoxKSCUserName;
        private System.Windows.Forms.Label labelKSCUser;
        private System.Windows.Forms.Label labelKSCBranches;
        private ComboBoxCustom listKSCBranches;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button btn_EditKSCAccount;
    }
}