using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserAccounts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new UsersDBContext();

            //Fill comboBox with Positions from the database
            listPositions.Items.Insert(0, "(Изберете Длъжност)");
            foreach (var p in db.Positions)
            {
                listPositions.Items.Add(p.Position1);
            }
            listPositions.SelectedIndex = 0;

            //Fill comboBox with Branches from the database
            listBranches.Items.Insert(0, "(Изберете Филиал)");
            foreach (var b in db.Branches)
            {
                listBranches.Items.Add(b.BranchName);
            }
            listBranches.SelectedIndex = 0;
            int i = 1;
            //Fill comboBox with Users from the database
            listUsers.Items.Add(new ComboBoxItem("(Изберете Потребител)", "0", Color.Black, false));            
            foreach(var u in db.UserMasterDatas)
            {
                if (u.Active)
                    listUsers.Items.Add(new ComboBoxItem(u.UserName, Convert.ToString(i++), Color.Black, false));
                else
                    listUsers.Items.Add(new ComboBoxItem(u.UserName, Convert.ToString(i++), Color.Red, true));
            }
            listUsers.SelectedIndex = 0;

            //Fill comboBox with Active Users from the database
            listActiveUsers.Items.Insert(0, "(Изберете Потребител)");
            foreach (var u in db.UserMasterDatas.Where(u => u.Active))
            {
                listActiveUsers.Items.Add(u.UserName);
            }
            listActiveUsers.SelectedIndex = 0;

            i = 1;
            //Fill comboBox with Users from the database
            listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", "0", Color.Black, false));
            foreach (var b in db.Branches)
            {
                listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Convert.ToString(i++), Color.Black, false));
            }
            listKSCBranches.SelectedIndex = 0;
        }
        
        private void btn_newUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text)
                || string.IsNullOrEmpty(listPositions.Text)
                || string.IsNullOrEmpty(listBranches.Text))
            {
                labelResult.Text = "Някое от задължителните полета е празно..";
                return;
            }
            bool isPositionSelected = false;
            bool isBranchSelected = false;
            var db = new UsersDBContext();
            foreach(var p in db.Positions)
            {
                if (p.Position1 == listPositions.SelectedItem.ToString())
                {
                    isPositionSelected = true;
                    break;
                }
            }
            foreach(var b in db.Branches)
            {
                if(b.BranchName == listBranches.SelectedItem.ToString())
                {
                    isBranchSelected = true;
                    break;
                }
            }
            if (!isBranchSelected && !isPositionSelected)
            {
                labelResult.Text = "Изберете Склад и Длъжност.";
                return;
            }

            if (!isPositionSelected)
            {
                labelResult.Text = "Изберете Длъжност.";
                return;
            }

            if(!isBranchSelected)
            {
                labelResult.Text = "Изберете Склад.";
                return;
            }
            
            DialogResult confirmCreateUser = MessageBox.Show($"Сигурни ли сте, че искате да създадете потребител \"{listUsers.SelectedItem}\"", "Confirm", MessageBoxButtons.YesNo);
           
            if (confirmCreateUser == DialogResult.No)
                return;//*/

            var userName = new SqlParameter("@name", textBoxUserName.Text);
            var email = new SqlParameter("@email", textBoxEmail.Text);
            var uadmName = new SqlParameter("@uadm", textBoxUadmName.Text);
            var pharmosName = new SqlParameter("@pharmos", textBoxPharmosName.Text);
            var adName = new SqlParameter("@adName", textBoxADUser.Text);

            var newUser = new UserMasterData
            {
                UserName = userName.SqlValue.ToString(),
                Email = email.SqlValue.ToString(),
                PositionID = PositionIdFromName(listPositions.Text),
                BranchID = BranchIdFromName(listBranches.Text),
                PharmosUserName = pharmosName.SqlValue.ToString(),
                UADMUserName = uadmName.SqlValue.ToString(),
                GI = checkBoxGI.Checked,
                Purchase = checkBoxPurchase.Checked,
                Tender = checkBoxTender.Checked,
                Phibra = checkBoxPhibra.Checked,
                Active = checkBoxIsActive.Checked
            };
            db.UserMasterDatas.Add(newUser);
            db.SaveChanges();

            int lastUserID = db.UserMasterDatas.OrderByDescending(u => u.ID).Select(u => u.ID).First();
            var adUser = new ADUser()
            {
                UserID = lastUserID,
                ADName = adName.SqlValue.ToString()
            };
            db.ADUsers.Add(adUser);
            db.SaveChanges();
            RefreshListUsers();
            ResetUsersGroupBoxItems();

            var lastUser = db.UserMasterDatas.OrderByDescending(u => u.ID).First();
            labelResult.Text = ("Потребителят е добавен успешно!") +
                               Environment.NewLine +
                               "№ --> " + lastUser.ID +
                               Environment.NewLine +
                               "Име --> " + lastUser.UserName +
                               Environment.NewLine +
                               "Username в Активната Директория --> " +
                               (!string.IsNullOrEmpty(
                                   lastUser.ADUsers.Where(a => a.UserID == lastUser.ID).Select(ad => ad.ADName).First())
                                   ? lastUser.ADUsers.Where(a => a.UserID == lastUser.ID).Select(ad => ad.ADName).First()
                                   : "липсва") +
                                     Environment.NewLine +
                                     "Длъжност --> " +
                                     db.Positions.Where(p => p.ID == lastUser.PositionID)
                                         .Select(p => p.Position1)
                                         .First() +
                                     Environment.NewLine +
                                     "Pharmos Username --> " +
                                     (!string.IsNullOrEmpty(lastUser.PharmosUserName)
                                         ? lastUser.PharmosUserName
                                         : "липсва");
        }

        private void ResetUsersGroupBoxItems()
        {
            textBoxUserName.Text = "";
            textBoxEmail.Text = "";
            textBoxADUser.Text = "";
            listPositions.SelectedIndex = 0;
            listBranches.SelectedIndex = 0;
            textBoxPharmosName.Text = "";
            textBoxUadmName.Text = "";
            checkBoxGI.Checked = false;
            checkBoxPurchase.Checked = false;
            checkBoxTender.Checked = false;
            checkBoxPhibra.Checked = false;
            checkBoxIsActive.Checked = true;
        }

        public int PositionIdFromName(string positionName)
        {
            var db = new UsersDBContext();
            return db.Positions.Where(p => p.Position1 == positionName).Select(i => i.ID).First();
        }
        public int BranchIdFromName(string branchName)
        {
            var db = new UsersDBContext();
            return db.Branches.Where(b => b.BranchName == branchName).Select(br => br.ID).First();
        }

        private void btn_deactivateUser_Click(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            int selectedUserID = 0;
            bool isUserSelected = false;
            foreach (var u in db.UserMasterDatas)
            {
                if (u.UserName == listUsers.SelectedItem.ToString())
                {
                    selectedUserID = u.ID;
                    isUserSelected = true;
                    break;
                }
            }
            if (!isUserSelected)
            {
                labelResult.Text = "Изберете потребител!";
                return;
            }
            if (db.UserMasterDatas.Where(u => u.ID == selectedUserID)
                    .Select(u => u.Active)
                    .First())
            {
                DialogResult confirmDeleteUser =
                    MessageBox.Show(
                        $"Сигурни ли сте, че искате да деактивирате потребител \"{listUsers.SelectedItem}\"", "Потвърди",
                        MessageBoxButtons.YesNo);

                if (confirmDeleteUser == DialogResult.No)
                {
                    labelResult.Text = "Не бяха направени промени.";
                    return;
                }
                if (confirmDeleteUser == DialogResult.Yes)
                {
                    string tempName = "";
                    foreach (var u in db.UserMasterDatas)
                    {
                        if (u.ID == selectedUserID)
                        {
                            tempName = u.UserName;
                            u.Active = false;
                        }
                    }
                    db.SaveChanges();
                    labelResult.Text = $"Потребител \"{tempName}\" беше деактивиран.";
                }
            }
            else
            {
                DialogResult confirmDeleteUser =
                    MessageBox.Show(
                        $"Сигурни ли сте, че искате да активирате потребител \"{listUsers.SelectedItem}\"", "Потвърди",
                        MessageBoxButtons.YesNo);

                if (confirmDeleteUser == DialogResult.No)
                {
                    labelResult.Text = "Не бяха направени промени.";
                    return;
                }
                if (confirmDeleteUser == DialogResult.Yes)
                {
                    string tempName = "";
                    foreach (var u in db.UserMasterDatas)
                    {
                        if (u.ID == selectedUserID)
                        {
                            tempName = u.UserName;
                            u.Active = true;
                        }
                    }
                    db.SaveChanges();
                    labelResult.Text = $"Потребител \"{tempName}\" беше активиран.";
                }
            }
            RefreshListUsers();
        }

        private void RefreshListUsers()
        {
            var db = new UsersDBContext();

            //List with all users....
            listUsers.Items.Clear();
            listUsers.Items.Add(new ComboBoxItem("(Изберете Потребител)", "0", Color.Black, false));
            int i = 1;
            foreach (var u in db.UserMasterDatas)
            {
                if (u.Active)
                    listUsers.Items.Add(new ComboBoxItem(u.UserName, Convert.ToString(i++), Color.Black, false));
                else
                    listUsers.Items.Add(new ComboBoxItem(u.UserName, Convert.ToString(i++), Color.Red, true));
            }
            listUsers.SelectedIndex = 0;

            //List only with Active Users...
            listActiveUsers.Items.Clear();
            listActiveUsers.Items.Insert(0, "(Изберете Потребител)");
            foreach (var u in db.UserMasterDatas.Where(u => u.Active))
            {
                listActiveUsers.Items.Add(u.UserName);
            }
            listActiveUsers.SelectedIndex = 0;
        }
        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            int selectedUserID = 0;
            bool isUserSelected = false;
            foreach (var u in db.UserMasterDatas)
            {
                if (u.UserName == listUsers.SelectedItem.ToString())
                {
                    selectedUserID = u.ID;
                    isUserSelected = true;
                    break;
                }
            }
            if (!isUserSelected)
            {
                return;
            }
            var isUserActive =
                db.UserMasterDatas.Where(u => u.ID == selectedUserID).Select(u => u.Active).First();
            if (isUserActive)
                btn_deactivateUser.Text = "Деактивирай";
            else
            {
                btn_deactivateUser.Text = "Активирай";
            }
        }

        private void listActiveUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetKSCGroupBoxItems();
            if (listActiveUsers.SelectedIndex == 0)
                return;
            var db = new UsersDBContext();
            int selectedUserID =
                db.UserMasterDatas.Where(u => u.UserName == listActiveUsers.SelectedItem.ToString())
                    .Select(u => u.ID)
                    .First();
            var kscEntriesForSelectedUser = db.KSCs.Where(k => k.UserID == selectedUserID);

            if (!kscEntriesForSelectedUser.Any())
            {
                listKSCBranches.Items.Clear();
                int i = 1;
                //Fill comboBox with Users from the database
                listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", "0", Color.Black, false));
                foreach (var b in db.Branches)
                {
                    listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Convert.ToString(i++), Color.Red, true));
                }
                listKSCBranches.SelectedIndex = 0;
                return;
            }
            else
            {
                listKSCBranches.Items.Clear();
                int i = 1;
                //Fill comboBox with Users from the database
                listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", "0", Color.Black, false));
                foreach (var b in db.Branches)
                {
                    if(kscEntriesForSelectedUser.Any(k => k.BranchID == b.ID))
                        listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Convert.ToString(i++), Color.Black, false));
                    else
                        listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Convert.ToString(i++), Color.Red, true));
                }
                listKSCBranches.SelectedIndex = 0;
            }
        }

        private void listKSCBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listActiveUsers.SelectedIndex == 0 || listKSCBranches.SelectedIndex == 0)
                return;
            var db = new UsersDBContext();
            string selectedBranch = listKSCBranches.SelectedItem.ToString();
            int selectedBranchID =
                db.Branches.Where(b => b.BranchName == selectedBranch)
                    .Select(b => b.ID)
                    .First();
            string selectedUserName = listActiveUsers.SelectedItem.ToString();
            int selectedUserID = db.UserMasterDatas.Where(u => u.UserName == selectedUserName).Select(u => u.ID).First();

            var kscEntriesForSelectedUser = db.KSCs.Where(k => k.UserID == selectedUserID);
            if (!kscEntriesForSelectedUser.Any())
            {
                ResetKSCGroupBoxItems();
                return;
            }
            KSC selectedUserKSC = db.KSCs.First(k => k.BranchID == selectedBranchID && k.UserID == selectedUserID);
            textBoxKSCUserName.Text = selectedUserKSC.UserName;
            textBoxKSCUserName.Enabled = false;
            textBoxThermID.Text = selectedUserKSC.TermID;
            textBoxThermID.Enabled = false;
            textBoxUID.Text = selectedUserKSC.UID.ToString();
            textBoxUID.Enabled = false;
            checkBoxFC.Checked = selectedUserKSC.AllowFC;
            checkBoxFC.Enabled = false;
        }

        private void ResetKSCGroupBoxItems()
        {
            textBoxKSCUserName.Text = "";
            textBoxKSCUserName.Enabled = true;
            textBoxThermID.Text = "";
            textBoxThermID.Enabled = true;
            textBoxUID.Text = "";
            textBoxUID.Enabled = true;
            checkBoxFC.Checked = false;
            checkBoxFC.Enabled = true;
        }
    }
}
