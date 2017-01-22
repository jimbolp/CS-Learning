﻿
namespace UserAccounts
{
    partial class Form1
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
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.labelPharmosName = new System.Windows.Forms.Label();
            this.textBoxPharmosName = new System.Windows.Forms.TextBox();
            this.listPositions = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBranches = new System.Windows.Forms.ComboBox();
            this.labelUadmName = new System.Windows.Forms.Label();
            this.textBoxUadmName = new System.Windows.Forms.TextBox();
            this.checkBoxGI = new System.Windows.Forms.CheckBox();
            this.checkBoxPurchase = new System.Windows.Forms.CheckBox();
            this.checkBoxTender = new System.Windows.Forms.CheckBox();
            this.checkBoxPhibra = new System.Windows.Forms.CheckBox();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.btn_newUser = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBoxNewUser = new System.Windows.Forms.GroupBox();
            this.labelADUser = new System.Windows.Forms.Label();
            this.textBoxADUser = new System.Windows.Forms.TextBox();
            this.groupBoxKSC = new System.Windows.Forms.GroupBox();
            this.labelActiveUsers = new System.Windows.Forms.Label();
            this.listActiveUsers = new System.Windows.Forms.ComboBox();
            this.listUsers = new UserAccounts.ComboBoxCustom();
            this.btn_deactivateUser = new System.Windows.Forms.Button();
            this.groupBoxDeactivateUser = new System.Windows.Forms.GroupBox();
            this.groupBoxNewUser.SuspendLayout();
            this.groupBoxKSC.SuspendLayout();
            this.groupBoxDeactivateUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(15, 80);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(203, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(12, 64);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(81, 13);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "Име Фамилия";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 103);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(15, 119);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(203, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBranch.Location = new System.Drawing.Point(259, 23);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(38, 13);
            this.labelBranch.TabIndex = 5;
            this.labelBranch.Text = "Склад";
            // 
            // labelPharmosName
            // 
            this.labelPharmosName.AutoSize = true;
            this.labelPharmosName.Location = new System.Drawing.Point(12, 221);
            this.labelPharmosName.Name = "labelPharmosName";
            this.labelPharmosName.Size = new System.Drawing.Size(99, 13);
            this.labelPharmosName.TabIndex = 7;
            this.labelPharmosName.Text = "Pharmos Username";
            // 
            // textBoxPharmosName
            // 
            this.textBoxPharmosName.Location = new System.Drawing.Point(15, 237);
            this.textBoxPharmosName.Name = "textBoxPharmosName";
            this.textBoxPharmosName.Size = new System.Drawing.Size(203, 20);
            this.textBoxPharmosName.TabIndex = 6;
            // 
            // listPositions
            // 
            this.listPositions.FormattingEnabled = true;
            this.listPositions.Location = new System.Drawing.Point(15, 197);
            this.listPositions.Name = "listPositions";
            this.listPositions.Size = new System.Drawing.Size(203, 21);
            this.listPositions.TabIndex = 8;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(12, 181);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(60, 13);
            this.labelPosition.TabIndex = 9;
            this.labelPosition.Text = "Длъжност";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(73, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "UserDB";
            // 
            // listBranches
            // 
            this.listBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBranches.FormattingEnabled = true;
            this.listBranches.Location = new System.Drawing.Point(262, 39);
            this.listBranches.Name = "listBranches";
            this.listBranches.Size = new System.Drawing.Size(121, 21);
            this.listBranches.TabIndex = 11;
            // 
            // labelUadmName
            // 
            this.labelUadmName.AutoSize = true;
            this.labelUadmName.Location = new System.Drawing.Point(12, 260);
            this.labelUadmName.Name = "labelUadmName";
            this.labelUadmName.Size = new System.Drawing.Size(90, 13);
            this.labelUadmName.TabIndex = 13;
            this.labelUadmName.Text = "UADM Username";
            // 
            // textBoxUadmName
            // 
            this.textBoxUadmName.Location = new System.Drawing.Point(15, 276);
            this.textBoxUadmName.Name = "textBoxUadmName";
            this.textBoxUadmName.Size = new System.Drawing.Size(203, 20);
            this.textBoxUadmName.TabIndex = 12;
            // 
            // checkBoxGI
            // 
            this.checkBoxGI.AutoSize = true;
            this.checkBoxGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxGI.Location = new System.Drawing.Point(262, 66);
            this.checkBoxGI.Name = "checkBoxGI";
            this.checkBoxGI.Size = new System.Drawing.Size(66, 17);
            this.checkBoxGI.TabIndex = 14;
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
            this.checkBoxPurchase.TabIndex = 15;
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
            this.checkBoxTender.TabIndex = 16;
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
            this.checkBoxPhibra.TabIndex = 17;
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
            this.checkBoxIsActive.TabIndex = 18;
            this.checkBoxIsActive.Text = "Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // btn_newUser
            // 
            this.btn_newUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_newUser.Location = new System.Drawing.Point(15, 304);
            this.btn_newUser.Name = "btn_newUser";
            this.btn_newUser.Size = new System.Drawing.Size(368, 23);
            this.btn_newUser.TabIndex = 19;
            this.btn_newUser.Text = "Добави потребител";
            this.btn_newUser.UseVisualStyleBackColor = true;
            this.btn_newUser.Click += new System.EventHandler(this.btn_newUser_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.Control;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(0, 529);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(1008, 200);
            this.labelResult.TabIndex = 20;
            // 
            // groupBoxNewUser
            // 
            this.groupBoxNewUser.Controls.Add(this.labelADUser);
            this.groupBoxNewUser.Controls.Add(this.btn_newUser);
            this.groupBoxNewUser.Controls.Add(this.textBoxADUser);
            this.groupBoxNewUser.Controls.Add(this.checkBoxIsActive);
            this.groupBoxNewUser.Controls.Add(this.labelBranch);
            this.groupBoxNewUser.Controls.Add(this.checkBoxPhibra);
            this.groupBoxNewUser.Controls.Add(this.listBranches);
            this.groupBoxNewUser.Controls.Add(this.checkBoxTender);
            this.groupBoxNewUser.Controls.Add(this.checkBoxGI);
            this.groupBoxNewUser.Controls.Add(this.checkBoxPurchase);
            this.groupBoxNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxNewUser.Location = new System.Drawing.Point(0, 41);
            this.groupBoxNewUser.Name = "groupBoxNewUser";
            this.groupBoxNewUser.Size = new System.Drawing.Size(390, 333);
            this.groupBoxNewUser.TabIndex = 21;
            this.groupBoxNewUser.TabStop = false;
            this.groupBoxNewUser.Text = "Създаване на нов потребител";
            // 
            // labelADUser
            // 
            this.labelADUser.AutoSize = true;
            this.labelADUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelADUser.Location = new System.Drawing.Point(12, 101);
            this.labelADUser.Name = "labelADUser";
            this.labelADUser.Size = new System.Drawing.Size(107, 13);
            this.labelADUser.TabIndex = 27;
            this.labelADUser.Text = "Active Directory User";
            // 
            // textBoxADUser
            // 
            this.textBoxADUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxADUser.Location = new System.Drawing.Point(15, 117);
            this.textBoxADUser.Name = "textBoxADUser";
            this.textBoxADUser.Size = new System.Drawing.Size(203, 20);
            this.textBoxADUser.TabIndex = 26;
            // 
            // groupBoxKSC
            // 
            this.groupBoxKSC.Controls.Add(this.labelActiveUsers);
            this.groupBoxKSC.Controls.Add(this.listActiveUsers);
            this.groupBoxKSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxKSC.Location = new System.Drawing.Point(448, 41);
            this.groupBoxKSC.Name = "groupBoxKSC";
            this.groupBoxKSC.Size = new System.Drawing.Size(390, 333);
            this.groupBoxKSC.TabIndex = 22;
            this.groupBoxKSC.TabStop = false;
            this.groupBoxKSC.Text = "Добавяне KSC на потребител";
            // 
            // labelActiveUsers
            // 
            this.labelActiveUsers.AutoSize = true;
            this.labelActiveUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelActiveUsers.Location = new System.Drawing.Point(6, 23);
            this.labelActiveUsers.Name = "labelActiveUsers";
            this.labelActiveUsers.Size = new System.Drawing.Size(67, 13);
            this.labelActiveUsers.TabIndex = 10;
            this.labelActiveUsers.Text = "Потребител";
            // 
            // listActiveUsers
            // 
            this.listActiveUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listActiveUsers.FormattingEnabled = true;
            this.listActiveUsers.Location = new System.Drawing.Point(6, 38);
            this.listActiveUsers.Name = "listActiveUsers";
            this.listActiveUsers.Size = new System.Drawing.Size(203, 21);
            this.listActiveUsers.TabIndex = 9;
            // 
            // listUsers
            // 
            this.listUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(10, 20);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(208, 21);
            this.listUsers.TabIndex = 23;
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.listUsers_SelectedIndexChanged);
            // 
            // btn_deactivateUser
            // 
            this.btn_deactivateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deactivateUser.Location = new System.Drawing.Point(262, 18);
            this.btn_deactivateUser.Name = "btn_deactivateUser";
            this.btn_deactivateUser.Size = new System.Drawing.Size(93, 23);
            this.btn_deactivateUser.TabIndex = 24;
            this.btn_deactivateUser.Text = "Деактивирай";
            this.btn_deactivateUser.UseVisualStyleBackColor = true;
            this.btn_deactivateUser.Click += new System.EventHandler(this.btn_deactivateUser_Click);
            // 
            // groupBoxDeactivateUser
            // 
            this.groupBoxDeactivateUser.Controls.Add(this.btn_deactivateUser);
            this.groupBoxDeactivateUser.Controls.Add(this.listUsers);
            this.groupBoxDeactivateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDeactivateUser.Location = new System.Drawing.Point(0, 380);
            this.groupBoxDeactivateUser.Name = "groupBoxDeactivateUser";
            this.groupBoxDeactivateUser.Size = new System.Drawing.Size(390, 60);
            this.groupBoxDeactivateUser.TabIndex = 25;
            this.groupBoxDeactivateUser.TabStop = false;
            this.groupBoxDeactivateUser.Text = "Деактивиране на потребител";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBoxDeactivateUser);
            this.Controls.Add(this.groupBoxKSC);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelUadmName);
            this.Controls.Add(this.textBoxUadmName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.listPositions);
            this.Controls.Add(this.labelPharmosName);
            this.Controls.Add(this.textBoxPharmosName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.groupBoxNewUser);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Import Users";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxNewUser.ResumeLayout(false);
            this.groupBoxNewUser.PerformLayout();
            this.groupBoxKSC.ResumeLayout(false);
            this.groupBoxKSC.PerformLayout();
            this.groupBoxDeactivateUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.Label labelPharmosName;
        private System.Windows.Forms.TextBox textBoxPharmosName;
        private System.Windows.Forms.ComboBox listPositions;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox listBranches;
        private System.Windows.Forms.Label labelUadmName;
        private System.Windows.Forms.TextBox textBoxUadmName;
        private System.Windows.Forms.CheckBox checkBoxGI;
        private System.Windows.Forms.CheckBox checkBoxPurchase;
        private System.Windows.Forms.CheckBox checkBoxTender;
        private System.Windows.Forms.CheckBox checkBoxPhibra;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private System.Windows.Forms.Button btn_newUser;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.GroupBox groupBoxNewUser;
        private System.Windows.Forms.GroupBox groupBoxKSC;
        private System.Windows.Forms.Button btn_deactivateUser;
        private System.Windows.Forms.GroupBox groupBoxDeactivateUser;
        private System.Windows.Forms.Label labelADUser;
        private System.Windows.Forms.TextBox textBoxADUser;
        private System.Windows.Forms.Label labelActiveUsers;
        private System.Windows.Forms.ComboBox listActiveUsers;
        private ComboBoxCustom listUsers;
    }
}

