
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
            this.textBoxADUser = new System.Windows.Forms.TextBox();
            this.labelADUser = new System.Windows.Forms.Label();
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
            this.labelActiveUsers = new System.Windows.Forms.Label();
            this.listActiveUsers = new System.Windows.Forms.ComboBox();
            this.btn_deactivateUser = new System.Windows.Forms.Button();
            this.groupBoxDeactivateUser = new System.Windows.Forms.GroupBox();
            this.btn_searchUser = new System.Windows.Forms.Button();
            this.btn_SearchKSC = new System.Windows.Forms.Button();
            this.groupBoxEditUser = new System.Windows.Forms.GroupBox();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.clearAllFields = new System.Windows.Forms.Button();
            this.listUsersToEdit = new UserAccounts.ComboBoxCustom();
            this.listUsers = new UserAccounts.ComboBoxCustom();
            this.listKSCBranches = new UserAccounts.ComboBoxCustom();
            this.groupBoxNewUser.SuspendLayout();
            this.groupBoxKSC.SuspendLayout();
            this.groupBoxDeactivateUser.SuspendLayout();
            this.groupBoxEditUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUserName.Location = new System.Drawing.Point(15, 38);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(203, 20);
            this.textBoxUserName.TabIndex = 0;
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
            // listPositions
            // 
            this.listPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listPositions.FormattingEnabled = true;
            this.listPositions.Location = new System.Drawing.Point(15, 155);
            this.listPositions.Name = "listPositions";
            this.listPositions.Size = new System.Drawing.Size(203, 21);
            this.listPositions.TabIndex = 3;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(73, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 29);
            this.label6.TabIndex = 55;
            this.label6.Text = "UserDB";
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
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.Control;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(0, 529);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(1008, 200);
            this.labelResult.TabIndex = 57;
            // 
            // groupBoxNewUser
            // 
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
            this.groupBoxNewUser.Location = new System.Drawing.Point(0, 54);
            this.groupBoxNewUser.Name = "groupBoxNewUser";
            this.groupBoxNewUser.Size = new System.Drawing.Size(390, 333);
            this.groupBoxNewUser.TabIndex = 0;
            this.groupBoxNewUser.TabStop = false;
            this.groupBoxNewUser.Text = "Създаване на нов потребител";
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
            this.groupBoxKSC.Controls.Add(this.labelActiveUsers);
            this.groupBoxKSC.Controls.Add(this.listActiveUsers);
            this.groupBoxKSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxKSC.Location = new System.Drawing.Point(596, 54);
            this.groupBoxKSC.Name = "groupBoxKSC";
            this.groupBoxKSC.Size = new System.Drawing.Size(412, 333);
            this.groupBoxKSC.TabIndex = 2;
            this.groupBoxKSC.TabStop = false;
            this.groupBoxKSC.Text = "Добавяне KSC на потребител";
            // 
            // btn_createKSCAccount
            // 
            this.btn_createKSCAccount.Enabled = false;
            this.btn_createKSCAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_createKSCAccount.Location = new System.Drawing.Point(6, 304);
            this.btn_createKSCAccount.Name = "btn_createKSCAccount";
            this.btn_createKSCAccount.Size = new System.Drawing.Size(128, 23);
            this.btn_createKSCAccount.TabIndex = 21;
            this.btn_createKSCAccount.Text = "Добави KSC акаунт";
            this.btn_createKSCAccount.UseVisualStyleBackColor = true;
            this.btn_createKSCAccount.Click += new System.EventHandler(this.btn_createKSCAccount_Click);
            // 
            // checkBoxFC
            // 
            this.checkBoxFC.AutoSize = true;
            this.checkBoxFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFC.Location = new System.Drawing.Point(279, 66);
            this.checkBoxFC.Name = "checkBoxFC";
            this.checkBoxFC.Size = new System.Drawing.Size(67, 17);
            this.checkBoxFC.TabIndex = 20;
            this.checkBoxFC.Text = "Allow FC";
            this.checkBoxFC.UseVisualStyleBackColor = true;
            // 
            // textBoxUID
            // 
            this.textBoxUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUID.Location = new System.Drawing.Point(6, 155);
            this.textBoxUID.MaxLength = 3;
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(108, 20);
            this.textBoxUID.TabIndex = 19;
            // 
            // labelUID
            // 
            this.labelUID.AutoSize = true;
            this.labelUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUID.Location = new System.Drawing.Point(3, 139);
            this.labelUID.Name = "labelUID";
            this.labelUID.Size = new System.Drawing.Size(26, 13);
            this.labelUID.TabIndex = 18;
            this.labelUID.Text = "UID";
            // 
            // textBoxTermID
            // 
            this.textBoxThermID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxThermID.Location = new System.Drawing.Point(6, 116);
            this.textBoxThermID.MaxLength = 4;
            this.textBoxThermID.Name = "textBoxTermID";
            this.textBoxThermID.Size = new System.Drawing.Size(108, 20);
            this.textBoxThermID.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Therm ID";
            // 
            // textBoxKSCUserName
            // 
            this.textBoxKSCUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKSCUserName.Location = new System.Drawing.Point(6, 78);
            this.textBoxKSCUserName.Name = "textBoxKSCUserName";
            this.textBoxKSCUserName.Size = new System.Drawing.Size(108, 20);
            this.textBoxKSCUserName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "KSC Username";
            // 
            // labelKSCBranches
            // 
            this.labelKSCBranches.AutoSize = true;
            this.labelKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKSCBranches.Location = new System.Drawing.Point(276, 23);
            this.labelKSCBranches.Name = "labelKSCBranches";
            this.labelKSCBranches.Size = new System.Drawing.Size(38, 13);
            this.labelKSCBranches.TabIndex = 12;
            this.labelKSCBranches.Text = "Склад";
            // 
            // labelActiveUsers
            // 
            this.labelActiveUsers.AutoSize = true;
            this.labelActiveUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelActiveUsers.Location = new System.Drawing.Point(3, 22);
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
            this.listActiveUsers.TabIndex = 0;
            this.listActiveUsers.SelectedIndexChanged += new System.EventHandler(this.listActiveUsers_SelectedIndexChanged);
            // 
            // btn_deactivateUser
            // 
            this.btn_deactivateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deactivateUser.Location = new System.Drawing.Point(262, 18);
            this.btn_deactivateUser.Name = "btn_deactivateUser";
            this.btn_deactivateUser.Size = new System.Drawing.Size(93, 23);
            this.btn_deactivateUser.TabIndex = 1;
            this.btn_deactivateUser.Text = "Деактивирай";
            this.btn_deactivateUser.UseVisualStyleBackColor = true;
            this.btn_deactivateUser.Click += new System.EventHandler(this.btn_deactivateUser_Click);
            // 
            // groupBoxDeactivateUser
            // 
            this.groupBoxDeactivateUser.Controls.Add(this.btn_deactivateUser);
            this.groupBoxDeactivateUser.Controls.Add(this.listUsers);
            this.groupBoxDeactivateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDeactivateUser.Location = new System.Drawing.Point(0, 459);
            this.groupBoxDeactivateUser.Name = "groupBoxDeactivateUser";
            this.groupBoxDeactivateUser.Size = new System.Drawing.Size(390, 60);
            this.groupBoxDeactivateUser.TabIndex = 1;
            this.groupBoxDeactivateUser.TabStop = false;
            this.groupBoxDeactivateUser.Text = "Деактивиране на потребител";
            // 
            // btn_searchUser
            // 
            this.btn_searchUser.Location = new System.Drawing.Point(396, 358);
            this.btn_searchUser.Name = "btn_searchUser";
            this.btn_searchUser.Size = new System.Drawing.Size(194, 23);
            this.btn_searchUser.TabIndex = 58;
            this.btn_searchUser.Text = "Покажи потребителите";
            this.btn_searchUser.UseVisualStyleBackColor = true;
            this.btn_searchUser.Click += new System.EventHandler(this.btn_searchUser_Click);
            // 
            // btn_SearchKSC
            // 
            this.btn_SearchKSC.Location = new System.Drawing.Point(396, 329);
            this.btn_SearchKSC.Name = "btn_SearchKSC";
            this.btn_SearchKSC.Size = new System.Drawing.Size(194, 23);
            this.btn_SearchKSC.TabIndex = 59;
            this.btn_SearchKSC.Text = "Покажи KSC акаунти";
            this.btn_SearchKSC.UseVisualStyleBackColor = true;
            this.btn_SearchKSC.Click += new System.EventHandler(this.btn_SearchKSC_Click);
            // 
            // groupBoxEditUser
            // 
            this.groupBoxEditUser.Controls.Add(this.btn_EditUser);
            this.groupBoxEditUser.Controls.Add(this.listUsersToEdit);
            this.groupBoxEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxEditUser.Location = new System.Drawing.Point(0, 393);
            this.groupBoxEditUser.Name = "groupBoxEditUser";
            this.groupBoxEditUser.Size = new System.Drawing.Size(390, 60);
            this.groupBoxEditUser.TabIndex = 2;
            this.groupBoxEditUser.TabStop = false;
            this.groupBoxEditUser.Text = "Редактиране на потребител";
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.Enabled = false;
            this.btn_EditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditUser.Location = new System.Drawing.Point(262, 18);
            this.btn_EditUser.Name = "btn_EditUser";
            this.btn_EditUser.Size = new System.Drawing.Size(93, 23);
            this.btn_EditUser.TabIndex = 1;
            this.btn_EditUser.Text = "Редактирай";
            this.btn_EditUser.UseVisualStyleBackColor = true;
            this.btn_EditUser.Click += new System.EventHandler(this.btn_EditUser_Click);
            // 
            // clearAllFields
            // 
            this.clearAllFields.Location = new System.Drawing.Point(396, 73);
            this.clearAllFields.Name = "clearAllFields";
            this.clearAllFields.Size = new System.Drawing.Size(194, 23);
            this.clearAllFields.TabIndex = 60;
            this.clearAllFields.Text = "Изчисти полетата";
            this.clearAllFields.UseVisualStyleBackColor = true;
            this.clearAllFields.Click += new System.EventHandler(this.clearAllFields_Click);
            // 
            // listUsersToEdit
            // 
            this.listUsersToEdit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listUsersToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listUsersToEdit.FormattingEnabled = true;
            this.listUsersToEdit.Location = new System.Drawing.Point(10, 20);
            this.listUsersToEdit.Name = "listUsersToEdit";
            this.listUsersToEdit.Size = new System.Drawing.Size(208, 21);
            this.listUsersToEdit.TabIndex = 0;
            this.listUsersToEdit.SelectedIndexChanged += new System.EventHandler(this.listUserToEdit_SelectedIndexChanged);
            // 
            // listUsers
            // 
            this.listUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(10, 20);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(208, 21);
            this.listUsers.TabIndex = 0;
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.listUsers_SelectedIndexChanged);
            // 
            // listKSCBranches
            // 
            this.listKSCBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listKSCBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listKSCBranches.FormattingEnabled = true;
            this.listKSCBranches.Location = new System.Drawing.Point(279, 39);
            this.listKSCBranches.Name = "listKSCBranches";
            this.listKSCBranches.Size = new System.Drawing.Size(121, 21);
            this.listKSCBranches.TabIndex = 11;
            this.listKSCBranches.SelectedIndexChanged += new System.EventHandler(this.listKSCBranches_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.clearAllFields);
            this.Controls.Add(this.groupBoxEditUser);
            this.Controls.Add(this.btn_SearchKSC);
            this.Controls.Add(this.btn_searchUser);
            this.Controls.Add(this.groupBoxDeactivateUser);
            this.Controls.Add(this.groupBoxKSC);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label6);
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
            this.groupBoxEditUser.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelKSCBranches;
        private ComboBoxCustom listKSCBranches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKSCUserName;
        private System.Windows.Forms.TextBox textBoxThermID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxFC;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label labelUID;
        private System.Windows.Forms.Button btn_createKSCAccount;
        private System.Windows.Forms.Button btn_searchUser;
        private System.Windows.Forms.Button btn_SearchKSC;
        private System.Windows.Forms.GroupBox groupBoxEditUser;
        private System.Windows.Forms.Button btn_EditUser;
        private ComboBoxCustom listUsersToEdit;
        private System.Windows.Forms.Button clearAllFields;
    }
}

