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
            
            //Fill comboBox with Users from the database
            listUsers.Items.Add(new ComboBoxItem("(Изберете Потребител)", Color.Black, false));            
            foreach(var u in db.UserMasterDatas)
            {
                listUsers.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsers.SelectedIndex = 0;

            //Fill comboBox with Active Users from the database
            listActiveUsers.Items.Insert(0, "(Изберете Потребител)");
            foreach (var u in db.UserMasterDatas.Where(u => u.Active))
            {
                listActiveUsers.Items.Add(u.UserName);
            }
            listActiveUsers.SelectedIndex = 0;

            //i = 1;
            //Fill comboBox with Users from the database
            listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
            foreach (var b in db.Branches)
            {
                listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Color.Black, false));
            }
            listKSCBranches.SelectedIndex = 0;

            //Fill comboBox with Users to edit from the database
            listUsersToEdit.Items.Add(new ComboBoxItem("(Изберете Потребител)", Color.Black, false));
            foreach (var u in db.UserMasterDatas)
            {
                listUsersToEdit.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsersToEdit.SelectedIndex = 0;
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
            var db = new UsersDBContext();

            bool isPositionSelected = db.Positions.Any(p => p.Position1 == listPositions.SelectedItem.ToString());
            bool isBranchSelected = db.Branches.Any(b => b.BranchName == listBranches.SelectedItem.ToString());
            
            /*foreach(var p in db.Positions)
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
            }//*/

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

            if (!string.IsNullOrEmpty(textBoxADUser.Text))
            {
                int lastUserID = db.UserMasterDatas.OrderByDescending(u => u.ID).Select(u => u.ID).First();
                var adUser = new ADUser()
                {
                    UserID = lastUserID,
                    ADName = adName.SqlValue.ToString()
                };
                db.ADUsers.Add(adUser);
                db.SaveChanges();
            }
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
            string selectedUserName = listUsers.SelectedItem.ToString();
            bool isUserSelected = db.UserMasterDatas.Any(u => u.UserName == selectedUserName);
            int selectedUserID =
                db.UserMasterDatas.Where(u => u.UserName == selectedUserName).Select(u => u.ID).First();
            
            /*foreach (var u in db.UserMasterDatas)
            {
                if (u.UserName == listUsers.SelectedItem.ToString())
                {
                    selectedUserID = u.ID;
                    isUserSelected = true;
                    break;
                }
            }//*/

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
            listUsers.Items.Add(new ComboBoxItem("(Изберете Потребител)", 0, Color.Black, false));
            
            foreach (var u in db.UserMasterDatas)
            {
                listUsers.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
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
            string selectedUserName = listUsers.SelectedItem.ToString();
            bool isUserSelected = db.UserMasterDatas.Any(u => u.UserName == selectedUserName);
            if (isUserSelected)
                selectedUserID =
                    db.UserMasterDatas.Where(u => u.UserName == selectedUserName)
                        .Select(u => u.ID)
                        .First();
            else
                return;
            /*foreach (var u in db.UserMasterDatas)
            {
                if (u.UserName == listUsers.SelectedItem.ToString())
                {
                    selectedUserID = u.ID;
                    isUserSelected = true;
                    break;
                }
            }//*/
            
            var isUserActive = db.UserMasterDatas.Where(u => u.ID == selectedUserID)
                .Select(u => u.Active).First();
            btn_deactivateUser.Text = isUserActive ? "Деактивирай" : "Активирай";
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
            //var kscEntriesForSelectedUser = db.KSCs.Where(k => k.UserID == selectedUserID);

            if (!db.KSCs.Any(k => k.UserID == selectedUserID))
            {
                listKSCBranches.Items.Clear();
                
                //Fill comboBox with Users from the database
                listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
                foreach (var b in db.Branches)
                {
                    listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Color.Red, true));
                }
                listKSCBranches.SelectedIndex = 0;
                return;
            }
            else
            {
                listKSCBranches.Items.Clear();
                
                //Fill comboBox with Users from the database
                listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
                foreach (var b in db.Branches)
                {
                    listKSCBranches.Items.Add(db.KSCs.Any(k => k.BranchID == b.ID && k.UserID == selectedUserID)
                        ? new ComboBoxItem(b.BranchName, Color.Black, false)
                        : new ComboBoxItem(b.BranchName, Color.Red, true));
                }
                listKSCBranches.SelectedIndex = 0;
            }
        }

        private void listKSCBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listActiveUsers.SelectedIndex == 0 || listKSCBranches.SelectedIndex == 0)
                return;
            //TODO..
            //Make btn_ksc Active
            btn_createKSCAccount.Enabled = true;

            var db = new UsersDBContext();
            string selectedBranch = listKSCBranches.SelectedItem.ToString();
            int selectedBranchID =
                db.Branches.Where(b => b.BranchName == selectedBranch)
                    .Select(b => b.ID)
                    .First();
            string selectedUserName = listActiveUsers.SelectedItem.ToString();
            int selectedUserID = db.UserMasterDatas.Where(u => u.UserName == selectedUserName).Select(u => u.ID).First();

            //var kscEntriesForSelectedUser = db.KSCs.Where(k => k.UserID == selectedUserID && k.BranchID == selectedBranchID);
            if (!db.KSCs.Any(k => k.UserID == selectedUserID && k.BranchID == selectedBranchID))
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

        private void btn_searchUser_Click(object sender, EventArgs e)
        {
            SearchUserForm srchUserForm = new SearchUserForm();
            srchUserForm.FormClosed += new FormClosedEventHandler(srchUserForm_Closed);
            Hide();
            srchUserForm.Show();
        }

        private void srchUserForm_Closed(object sender, EventArgs e)
        {
            Show();
        }

        private void btn_SearchKSC_Click(object sender, EventArgs e)
        {
            var srchKSCForm = new KSCUserForm();
            srchKSCForm.FormClosed += srchKSCForm_Closed;
            Hide();
            srchKSCForm.Show();
        }

        private void srchKSCForm_Closed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void listUserToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUsersToEdit.SelectedIndex == 0)
                return;
            btn_newUser.Enabled = false;
            var db = new UsersDBContext();
            string UserName = listUsersToEdit.SelectedItem.ToString();
            
            var user = db.UserMasterDatas.Where(u => u.UserName == UserName);
            int positionIndex =
                listPositions.FindStringExact(
                    db.Positions.Where(p => p.ID == user.Select(u => u.PositionID).FirstOrDefault())
                        .Select(p => p.Position1)
                        .FirstOrDefault());
            int branchIndex = listBranches.FindStringExact(
                db.Branches.Where(b => b.ID == user.Select(u => u.BranchID).FirstOrDefault())
                    .Select(b => b.BranchName)
                    .FirstOrDefault());
            ResetUsersGroupBoxItems();
            textBoxUserName.Text = user.Select(u => u.UserName).FirstOrDefault();
            textBoxEmail.Text = user.Select(u => u.Email).FirstOrDefault();
            textBoxADUser.Text = user.Select(u => u.ADUsers.Where(a => a.UserID == u.ID).Select(a=>a.ADName).FirstOrDefault()).FirstOrDefault();
            listPositions.SelectedIndex = positionIndex;
            listBranches.SelectedIndex = branchIndex;
            textBoxPharmosName.Text = user.Select(u => u.PharmosUserName).FirstOrDefault();
            textBoxUadmName.Text = user.Select(u => u.UADMUserName).FirstOrDefault();
            checkBoxGI.Checked = user.Select(u => u.GI.Value).FirstOrDefault();
            checkBoxPurchase.Checked = user.Select(u => u.Purchase.Value).FirstOrDefault();
            checkBoxTender.Checked = user.Select(u => u.Tender.Value).FirstOrDefault();
            checkBoxPhibra.Checked = user.Select(u => u.Phibra.Value).FirstOrDefault();
            checkBoxIsActive.Checked = user.Select(u => u.Active).FirstOrDefault();
        }

        private void clearAllFields_Click(object sender, EventArgs e)
        {
            ResetUsersGroupBoxItems();
            ResetKSCGroupBoxItems();
            listUsers.SelectedIndex = 0;
            listUsersToEdit.SelectedIndex = 0;
            Application.DoEvents();
            btn_newUser.Enabled = true;
        }

        private void btn_createKSCAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
