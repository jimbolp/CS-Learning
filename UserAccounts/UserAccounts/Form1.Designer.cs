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
            this.button1 = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listUsers = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(15, 80);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(169, 20);
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
            this.textBoxEmail.Size = new System.Drawing.Size(169, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Location = new System.Drawing.Point(203, 64);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(38, 13);
            this.labelBranch.TabIndex = 5;
            this.labelBranch.Text = "Склад";
            // 
            // labelPharmosName
            // 
            this.labelPharmosName.AutoSize = true;
            this.labelPharmosName.Location = new System.Drawing.Point(12, 182);
            this.labelPharmosName.Name = "labelPharmosName";
            this.labelPharmosName.Size = new System.Drawing.Size(99, 13);
            this.labelPharmosName.TabIndex = 7;
            this.labelPharmosName.Text = "Pharmos Username";
            // 
            // textBoxPharmosName
            // 
            this.textBoxPharmosName.Location = new System.Drawing.Point(15, 198);
            this.textBoxPharmosName.Name = "textBoxPharmosName";
            this.textBoxPharmosName.Size = new System.Drawing.Size(169, 20);
            this.textBoxPharmosName.TabIndex = 6;
            // 
            // listPositions
            // 
            this.listPositions.FormattingEnabled = true;
            this.listPositions.Location = new System.Drawing.Point(15, 158);
            this.listPositions.Name = "listPositions";
            this.listPositions.Size = new System.Drawing.Size(169, 21);
            this.listPositions.TabIndex = 8;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(12, 142);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(60, 13);
            this.labelPosition.TabIndex = 9;
            this.labelPosition.Text = "Длъжност";
            this.labelPosition.Click += new System.EventHandler(this.label5_Click);
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
            this.listBranches.FormattingEnabled = true;
            this.listBranches.Location = new System.Drawing.Point(206, 80);
            this.listBranches.Name = "listBranches";
            this.listBranches.Size = new System.Drawing.Size(121, 21);
            this.listBranches.TabIndex = 11;
            this.listBranches.SelectedIndexChanged += new System.EventHandler(this.listBranches_SelectedIndexChanged);
            // 
            // labelUadmName
            // 
            this.labelUadmName.AutoSize = true;
            this.labelUadmName.Location = new System.Drawing.Point(12, 221);
            this.labelUadmName.Name = "labelUadmName";
            this.labelUadmName.Size = new System.Drawing.Size(93, 13);
            this.labelUadmName.TabIndex = 13;
            this.labelUadmName.Text = "UADM User name";
            // 
            // textBoxUadmName
            // 
            this.textBoxUadmName.Location = new System.Drawing.Point(15, 237);
            this.textBoxUadmName.Name = "textBoxUadmName";
            this.textBoxUadmName.Size = new System.Drawing.Size(169, 20);
            this.textBoxUadmName.TabIndex = 12;
            // 
            // checkBoxGI
            // 
            this.checkBoxGI.AutoSize = true;
            this.checkBoxGI.Location = new System.Drawing.Point(206, 107);
            this.checkBoxGI.Name = "checkBoxGI";
            this.checkBoxGI.Size = new System.Drawing.Size(66, 17);
            this.checkBoxGI.TabIndex = 14;
            this.checkBoxGI.Text = "GoodsIn";
            this.checkBoxGI.UseVisualStyleBackColor = true;
            // 
            // checkBoxPurchase
            // 
            this.checkBoxPurchase.AutoSize = true;
            this.checkBoxPurchase.Location = new System.Drawing.Point(206, 130);
            this.checkBoxPurchase.Name = "checkBoxPurchase";
            this.checkBoxPurchase.Size = new System.Drawing.Size(71, 17);
            this.checkBoxPurchase.TabIndex = 15;
            this.checkBoxPurchase.Text = "Purchase";
            this.checkBoxPurchase.UseVisualStyleBackColor = true;
            // 
            // checkBoxTender
            // 
            this.checkBoxTender.AutoSize = true;
            this.checkBoxTender.Location = new System.Drawing.Point(206, 153);
            this.checkBoxTender.Name = "checkBoxTender";
            this.checkBoxTender.Size = new System.Drawing.Size(60, 17);
            this.checkBoxTender.TabIndex = 16;
            this.checkBoxTender.Text = "Tender";
            this.checkBoxTender.UseVisualStyleBackColor = true;
            // 
            // checkBoxPhibra
            // 
            this.checkBoxPhibra.AutoSize = true;
            this.checkBoxPhibra.Location = new System.Drawing.Point(206, 176);
            this.checkBoxPhibra.Name = "checkBoxPhibra";
            this.checkBoxPhibra.Size = new System.Drawing.Size(56, 17);
            this.checkBoxPhibra.TabIndex = 17;
            this.checkBoxPhibra.Text = "Phibra";
            this.checkBoxPhibra.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Location = new System.Drawing.Point(206, 199);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxIsActive.TabIndex = 18;
            this.checkBoxIsActive.Text = "Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Добави потребител";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.Control;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(0, 415);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(784, 147);
            this.labelResult.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 273);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Създаване на нов потребител";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(448, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 273);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изтриване на потребител";
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(10, 20);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(169, 21);
            this.listUsers.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Деактивирай";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.listUsers);
            this.groupBox3.Location = new System.Drawing.Point(0, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 60);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Изтриване на потребител";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxIsActive);
            this.Controls.Add(this.checkBoxPhibra);
            this.Controls.Add(this.checkBoxTender);
            this.Controls.Add(this.checkBoxPurchase);
            this.Controls.Add(this.checkBoxGI);
            this.Controls.Add(this.labelUadmName);
            this.Controls.Add(this.textBoxUadmName);
            this.Controls.Add(this.listBranches);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.listPositions);
            this.Controls.Add(this.labelPharmosName);
            this.Controls.Add(this.textBoxPharmosName);
            this.Controls.Add(this.labelBranch);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Import Users";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox listUsers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

