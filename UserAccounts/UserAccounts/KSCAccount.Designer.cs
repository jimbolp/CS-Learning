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
            this.checkBoxFC = new System.Windows.Forms.CheckBox();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.labelUID = new System.Windows.Forms.Label();
            this.textBoxThermID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKSCUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelKSCBranches = new System.Windows.Forms.Label();
            this.listKSCBranches = new UserAccounts.ComboBoxCustom();
            this.labelUserName = new System.Windows.Forms.Label();
            this.groupBoxKSC.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxKSC
            // 
            this.groupBoxKSC.Controls.Add(this.btn_createKSCAccount);
            this.groupBoxKSC.Controls.Add(this.checkBoxFC);
            this.groupBoxKSC.Controls.Add(this.textBoxUID);
            this.groupBoxKSC.Controls.Add(this.labelUID);
            this.groupBoxKSC.Controls.Add(this.textBoxThermID);
            this.groupBoxKSC.Controls.Add(this.label2);
            this.groupBoxKSC.Controls.Add(this.textBoxKSCUserName);
            this.groupBoxKSC.Controls.Add(this.label1);
            this.groupBoxKSC.Controls.Add(this.labelKSCBranches);
            this.groupBoxKSC.Controls.Add(this.listKSCBranches);
            this.groupBoxKSC.Controls.Add(this.labelUserName);
            this.groupBoxKSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxKSC.Location = new System.Drawing.Point(12, 12);
            this.groupBoxKSC.Name = "groupBoxKSC";
            this.groupBoxKSC.Size = new System.Drawing.Size(353, 280);
            this.groupBoxKSC.TabIndex = 3;
            this.groupBoxKSC.TabStop = false;
            this.groupBoxKSC.Text = "Добавяне KSC на потребител";
            // 
            // btn_createKSCAccount
            // 
            this.btn_createKSCAccount.Enabled = false;
            this.btn_createKSCAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_createKSCAccount.Location = new System.Drawing.Point(6, 200);
            this.btn_createKSCAccount.Name = "btn_createKSCAccount";
            this.btn_createKSCAccount.Size = new System.Drawing.Size(128, 23);
            this.btn_createKSCAccount.TabIndex = 21;
            this.btn_createKSCAccount.Text = "Добави KSC акаунт";
            this.btn_createKSCAccount.UseVisualStyleBackColor = true;
            // 
            // checkBoxFC
            // 
            this.checkBoxFC.AutoSize = true;
            this.checkBoxFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFC.Location = new System.Drawing.Point(226, 65);
            this.checkBoxFC.Name = "checkBoxFC";
            this.checkBoxFC.Size = new System.Drawing.Size(67, 17);
            this.checkBoxFC.TabIndex = 20;
            this.checkBoxFC.Text = "Allow FC";
            this.checkBoxFC.UseVisualStyleBackColor = true;
            // 
            // textBoxUID
            // 
            this.textBoxUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUID.Location = new System.Drawing.Point(6, 174);
            this.textBoxUID.MaxLength = 3;
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(108, 20);
            this.textBoxUID.TabIndex = 19;
            // 
            // labelUID
            // 
            this.labelUID.AutoSize = true;
            this.labelUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUID.Location = new System.Drawing.Point(3, 158);
            this.labelUID.Name = "labelUID";
            this.labelUID.Size = new System.Drawing.Size(26, 13);
            this.labelUID.TabIndex = 18;
            this.labelUID.Text = "UID";
            // 
            // textBoxThermID
            // 
            this.textBoxThermID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxThermID.Location = new System.Drawing.Point(6, 135);
            this.textBoxThermID.MaxLength = 4;
            this.textBoxThermID.Name = "textBoxThermID";
            this.textBoxThermID.Size = new System.Drawing.Size(108, 20);
            this.textBoxThermID.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Therm ID";
            // 
            // textBoxKSCUserName
            // 
            this.textBoxKSCUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKSCUserName.Location = new System.Drawing.Point(6, 97);
            this.textBoxKSCUserName.Name = "textBoxKSCUserName";
            this.textBoxKSCUserName.Size = new System.Drawing.Size(108, 20);
            this.textBoxKSCUserName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "KSC Username";
            // 
            // labelKSCBranches
            // 
            this.labelKSCBranches.AutoSize = true;
            this.labelKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKSCBranches.Location = new System.Drawing.Point(223, 22);
            this.labelKSCBranches.Name = "labelKSCBranches";
            this.labelKSCBranches.Size = new System.Drawing.Size(38, 13);
            this.labelKSCBranches.TabIndex = 12;
            this.labelKSCBranches.Text = "Склад";
            // 
            // listKSCBranches
            // 
            this.listKSCBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listKSCBranches.FormattingEnabled = true;
            this.listKSCBranches.Location = new System.Drawing.Point(226, 38);
            this.listKSCBranches.Name = "listKSCBranches";
            this.listKSCBranches.Size = new System.Drawing.Size(121, 21);
            this.listKSCBranches.TabIndex = 11;
            // 
            // labelUserName
            // 
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(3, 38);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(217, 34);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "Потребител";
            // 
            // KSCAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 305);
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
        private System.Windows.Forms.CheckBox checkBoxFC;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label labelUID;
        private System.Windows.Forms.TextBox textBoxThermID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKSCUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelKSCBranches;
        private ComboBoxCustom listKSCBranches;
        private System.Windows.Forms.Label labelUserName;
    }
}