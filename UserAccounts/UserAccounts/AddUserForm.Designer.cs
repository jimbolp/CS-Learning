namespace UserAccounts
{
    partial class AddUserForm
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
            this.groupBoxNewUser = new System.Windows.Forms.GroupBox();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.labelUadmName = new System.Windows.Forms.Label();
            this.textBoxUadmName = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.listPositions = new System.Windows.Forms.ComboBox();
            this.labelPharmosName = new System.Windows.Forms.Label();
            this.textBoxPharmosName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxADUser = new System.Windows.Forms.TextBox();
            this.labelADUser = new System.Windows.Forms.Label();
            this.listBranches = new System.Windows.Forms.ComboBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.checkBoxGI = new System.Windows.Forms.CheckBox();
            this.checkBoxPurchase = new System.Windows.Forms.CheckBox();
            this.checkBoxTender = new System.Windows.Forms.CheckBox();
            this.checkBoxPhibra = new System.Windows.Forms.CheckBox();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.btn_newUser = new System.Windows.Forms.Button();
            this.groupBoxNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNewUser
            // 
            this.groupBoxNewUser.Controls.Add(this.btn_EditUser);
            this.groupBoxNewUser.Controls.Add(this.labelUadmName);
            this.groupBoxNewUser.Controls.Add(this.textBoxUadmName);
            this.groupBoxNewUser.Controls.Add(this.labelPosition);
            this.groupBoxNewUser.Controls.Add(this.listPositions);
            this.groupBoxNewUser.Controls.Add(this.labelPharmosName);
            this.groupBoxNewUser.Controls.Add(this.textBoxPharmosName);
            this.groupBoxNewUser.Controls.Add(this.labelEmail);
            this.groupBoxNewUser.Controls.Add(this.textBoxEmail);
            this.groupBoxNewUser.Controls.Add(this.labelUserName);
            this.groupBoxNewUser.Controls.Add(this.textBoxUserName);
            this.groupBoxNewUser.Controls.Add(this.textBoxADUser);
            this.groupBoxNewUser.Controls.Add(this.labelADUser);
            this.groupBoxNewUser.Controls.Add(this.listBranches);
            this.groupBoxNewUser.Controls.Add(this.labelBranch);
            this.groupBoxNewUser.Controls.Add(this.checkBoxGI);
            this.groupBoxNewUser.Controls.Add(this.checkBoxPurchase);
            this.groupBoxNewUser.Controls.Add(this.checkBoxTender);
            this.groupBoxNewUser.Controls.Add(this.checkBoxPhibra);
            this.groupBoxNewUser.Controls.Add(this.checkBoxIsActive);
            this.groupBoxNewUser.Controls.Add(this.btn_newUser);
            this.groupBoxNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxNewUser.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNewUser.Name = "groupBoxNewUser";
            this.groupBoxNewUser.Size = new System.Drawing.Size(390, 333);
            this.groupBoxNewUser.TabIndex = 1;
            this.groupBoxNewUser.TabStop = false;
            this.groupBoxNewUser.Text = "Създаване на нов потребител";
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditUser.Location = new System.Drawing.Point(15, 304);
            this.btn_EditUser.Name = "btn_EditUser";
            this.btn_EditUser.Size = new System.Drawing.Size(368, 23);
            this.btn_EditUser.TabIndex = 60;
            this.btn_EditUser.Text = "Запази промените";
            this.btn_EditUser.UseVisualStyleBackColor = true;
            this.btn_EditUser.Click += new System.EventHandler(this.btn_EditUser_Click);
            // 
            // labelUadmName
            // 
            this.labelUadmName.AutoSize = true;
            this.labelUadmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUadmName.Location = new System.Drawing.Point(12, 218);
            this.labelUadmName.Name = "labelUadmName";
            this.labelUadmName.Size = new System.Drawing.Size(90, 13);
            this.labelUadmName.TabIndex = 56;
            this.labelUadmName.Text = "UADM Username";
            // 
            // textBoxUadmName
            // 
            this.textBoxUadmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUadmName.Location = new System.Drawing.Point(15, 234);
            this.textBoxUadmName.Name = "textBoxUadmName";
            this.textBoxUadmName.Size = new System.Drawing.Size(203, 20);
            this.textBoxUadmName.TabIndex = 5;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPosition.Location = new System.Drawing.Point(12, 139);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(60, 13);
            this.labelPosition.TabIndex = 54;
            this.labelPosition.Text = "Длъжност";
            // 
            // listPositions
            // 
            this.listPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listPositions.FormattingEnabled = true;
            this.listPositions.Location = new System.Drawing.Point(15, 155);
            this.listPositions.Name = "listPositions";
            this.listPositions.Size = new System.Drawing.Size(203, 21);
            this.listPositions.TabIndex = 3;
            // 
            // labelPharmosName
            // 
            this.labelPharmosName.AutoSize = true;
            this.labelPharmosName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPharmosName.Location = new System.Drawing.Point(12, 179);
            this.labelPharmosName.Name = "labelPharmosName";
            this.labelPharmosName.Size = new System.Drawing.Size(99, 13);
            this.labelPharmosName.TabIndex = 53;
            this.labelPharmosName.Text = "Pharmos Username";
            // 
            // textBoxPharmosName
            // 
            this.textBoxPharmosName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPharmosName.Location = new System.Drawing.Point(15, 195);
            this.textBoxPharmosName.Name = "textBoxPharmosName";
            this.textBoxPharmosName.Size = new System.Drawing.Size(203, 20);
            this.textBoxPharmosName.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmail.Location = new System.Drawing.Point(12, 61);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 51;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmail.Location = new System.Drawing.Point(15, 77);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(203, 20);
            this.textBoxEmail.TabIndex = 1;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(12, 23);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(81, 13);
            this.labelUserName.TabIndex = 50;
            this.labelUserName.Text = "Име Фамилия";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUserName.Location = new System.Drawing.Point(15, 38);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(203, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // textBoxADUser
            // 
            this.textBoxADUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxADUser.Location = new System.Drawing.Point(15, 116);
            this.textBoxADUser.Name = "textBoxADUser";
            this.textBoxADUser.Size = new System.Drawing.Size(203, 20);
            this.textBoxADUser.TabIndex = 2;
            // 
            // labelADUser
            // 
            this.labelADUser.AutoSize = true;
            this.labelADUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelADUser.Location = new System.Drawing.Point(12, 100);
            this.labelADUser.Name = "labelADUser";
            this.labelADUser.Size = new System.Drawing.Size(107, 13);
            this.labelADUser.TabIndex = 59;
            this.labelADUser.Text = "Active Directory User";
            // 
            // listBranches
            // 
            this.listBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBranches.FormattingEnabled = true;
            this.listBranches.Location = new System.Drawing.Point(262, 39);
            this.listBranches.Name = "listBranches";
            this.listBranches.Size = new System.Drawing.Size(121, 21);
            this.listBranches.TabIndex = 6;
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBranch.Location = new System.Drawing.Point(259, 23);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(38, 13);
            this.labelBranch.TabIndex = 52;
            this.labelBranch.Text = "Склад";
            // 
            // checkBoxGI
            // 
            this.checkBoxGI.AutoSize = true;
            this.checkBoxGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxGI.Location = new System.Drawing.Point(262, 66);
            this.checkBoxGI.Name = "checkBoxGI";
            this.checkBoxGI.Size = new System.Drawing.Size(66, 17);
            this.checkBoxGI.TabIndex = 7;
            this.checkBoxGI.Text = "GoodsIn";
            this.checkBoxGI.UseVisualStyleBackColor = true;
            // 
            // checkBoxPurchase
            // 
            this.checkBoxPurchase.AutoSize = true;
            this.checkBoxPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPurchase.Location = new System.Drawing.Point(262, 89);
            this.checkBoxPurchase.Name = "checkBoxPurchase";
            this.checkBoxPurchase.Size = new System.Drawing.Size(71, 17);
            this.checkBoxPurchase.TabIndex = 8;
            this.checkBoxPurchase.Text = "Purchase";
            this.checkBoxPurchase.UseVisualStyleBackColor = true;
            // 
            // checkBoxTender
            // 
            this.checkBoxTender.AutoSize = true;
            this.checkBoxTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxTender.Location = new System.Drawing.Point(262, 112);
            this.checkBoxTender.Name = "checkBoxTender";
            this.checkBoxTender.Size = new System.Drawing.Size(60, 17);
            this.checkBoxTender.TabIndex = 9;
            this.checkBoxTender.Text = "Tender";
            this.checkBoxTender.UseVisualStyleBackColor = true;
            // 
            // checkBoxPhibra
            // 
            this.checkBoxPhibra.AutoSize = true;
            this.checkBoxPhibra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPhibra.Location = new System.Drawing.Point(262, 135);
            this.checkBoxPhibra.Name = "checkBoxPhibra";
            this.checkBoxPhibra.Size = new System.Drawing.Size(56, 17);
            this.checkBoxPhibra.TabIndex = 10;
            this.checkBoxPhibra.Text = "Phibra";
            this.checkBoxPhibra.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Checked = true;
            this.checkBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIsActive.Location = new System.Drawing.Point(262, 158);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxIsActive.TabIndex = 11;
            this.checkBoxIsActive.Text = "Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // btn_newUser
            // 
            this.btn_newUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_newUser.Location = new System.Drawing.Point(15, 304);
            this.btn_newUser.Name = "btn_newUser";
            this.btn_newUser.Size = new System.Drawing.Size(368, 23);
            this.btn_newUser.TabIndex = 12;
            this.btn_newUser.Text = "Добави потребител";
            this.btn_newUser.UseVisualStyleBackColor = true;
            this.btn_newUser.Click += new System.EventHandler(this.btn_newUser_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 356);
            this.Controls.Add(this.groupBoxNewUser);
            this.Name = "AddUserForm";
            this.Text = "AddUserForm";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.groupBoxNewUser.ResumeLayout(false);
            this.groupBoxNewUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNewUser;
        private System.Windows.Forms.Label labelUadmName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelPharmosName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelADUser;
        private System.Windows.Forms.Label labelBranch;
        public System.Windows.Forms.ComboBox listPositions;
        public System.Windows.Forms.TextBox textBoxPharmosName;
        public System.Windows.Forms.TextBox textBoxEmail;
        public System.Windows.Forms.TextBox textBoxUserName;
        public System.Windows.Forms.TextBox textBoxADUser;
        public System.Windows.Forms.TextBox textBoxUadmName;
        public System.Windows.Forms.ComboBox listBranches;
        public System.Windows.Forms.CheckBox checkBoxGI;
        public System.Windows.Forms.CheckBox checkBoxPurchase;
        public System.Windows.Forms.CheckBox checkBoxTender;
        public System.Windows.Forms.CheckBox checkBoxPhibra;
        public System.Windows.Forms.CheckBox checkBoxIsActive;
        public System.Windows.Forms.Button btn_EditUser;
        public System.Windows.Forms.Button btn_newUser;
    }
}