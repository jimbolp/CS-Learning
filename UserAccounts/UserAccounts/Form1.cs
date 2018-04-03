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

        /// <summary>
        /// Property I use to keep the currently chosen user's ID for editing...
        /// Probably not the best idea!? :D
        /// </summary>
        private int? UserIDToEdit { get; set; }
        private UsersDBContext db = new UsersDBContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeDropDownLists();
            if (db == null)
                db = new UsersDBContext();
        }

        /// <summary>
        /// Gets data from the database to fill the DropDown lists with adequate information
        /// </summary>
        private void initializeDropDownLists()
        {
            //var db = new UsersDBContext();
            var sortedUsers = db.UserMasterDatas.OrderBy(u => u.UserName);
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
            foreach (var u in sortedUsers)
            {
                listUsers.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsers.SelectedIndex = 0;

            //Fill comboBox with Active Users from the database
            listActiveUsers.Items.Insert(0, "(Изберете Потребител)");
            foreach (var u in sortedUsers.Where(u => u.Active))
            {
                listActiveUsers.Items.Add(u.UserName);
            }
            listActiveUsers.SelectedIndex = 0;

            //i = 1;
            //Fill comboBox with Depots from the database
            listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
            foreach (var b in db.Branches)
            {
                listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Color.Black, false));
            }
            listKSCBranches.SelectedIndex = 0;

            //Fill comboBox with Users to edit from the database
            listUsersToEdit.Items.Add(new ComboBoxItem("(Изберете Потребител)", Color.Black, false));
            foreach (var u in sortedUsers)
            {
                listUsersToEdit.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsersToEdit.SelectedIndex = 0;
        }
        private void btn_newUser_Click(object sender, EventArgs e)
        {
            if(!isAllowedToAddUser())
                return;

            var db = new UsersDBContext();

            DialogResult confirmCreateUser = MessageBox.Show($"Сигурни ли сте, че искате да създадете потребител \"{textBoxUserName.Text}\"", "Confirm", MessageBoxButtons.YesNo);

            if (confirmCreateUser == DialogResult.No)
            {
                labelResult.Text = "Не бяха направени промени.";
                return; //*/
            }

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
                int lastUserID = db.UserMasterDatas.OrderByDescending(u => u.ID).Select(u => u.ID).FirstOrDefault();
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

            var lastUser = db.UserMasterDatas.OrderByDescending(u => u.ID).FirstOrDefault();
            labelResult.Text = ("Потребителят е добавен успешно!") +
                               Environment.NewLine +
                               "№ --> " + lastUser.ID +
                               Environment.NewLine +
                               "Име --> " + lastUser.UserName +
                               Environment.NewLine +
                               "Username в Активната Директория --> ";
            labelResult.Text += (!string.IsNullOrEmpty(
                                   lastUser.ADUsers.Where(a => a.UserID == lastUser.ID).Select(ad => ad.ADName).FirstOrDefault())
                                   ? lastUser.ADUsers.Where(a => a.UserID == lastUser.ID).Select(ad => ad.ADName).FirstOrDefault()
                                   : "липсва");
            labelResult.Text += Environment.NewLine +
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

        /// <summary>
        /// Returns false if any of the required fields for the new user is empty..
        /// TODO: Need to add some additional checks!
        /// </summary>
        /// <returns></returns>
        private bool isAllowedToAddUser()
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text)
                || string.IsNullOrEmpty(listPositions.Text)
                || string.IsNullOrEmpty(listBranches.Text))
            {
                labelResult.Text = "Някое от задължителните полета е празно..";
                return false;
            }
            var db = new UsersDBContext();

            bool isPositionSelected = db.Positions.Any(p => p.Position1 == listPositions.SelectedItem.ToString());
            bool isBranchSelected = db.Branches.Any(b => b.BranchName == listBranches.SelectedItem.ToString());

            if (!isBranchSelected && !isPositionSelected)
            {
                labelResult.Text = "Изберете Склад и Длъжност.";
                return false;
            }

            if (!isPositionSelected)
            {
                labelResult.Text = "Изберете Длъжност.";
                return false;
            }

            if (!isBranchSelected)
            {
                labelResult.Text = "Изберете Склад.";
                return false;
            }
            return true;
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

        /// <summary>
        /// Checks if a user is selected and if it's active, deactivates it.
        /// If not... hmmm... Let me guess...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deactivateUser_Click(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            string selectedUserName = listUsers.SelectedItem.ToString();
            bool isUserSelected = db.UserMasterDatas.Any(u => u.UserName == selectedUserName);
            
            if (!isUserSelected)
            {
                labelResult.Text = "Изберете потребител!";
                return;
            }
            int selectedUserID =
                db.UserMasterDatas.Where(u => u.UserName == selectedUserName).Select(u => u.ID).First();
            if (db.UserMasterDatas.Where(u => u.ID == selectedUserID)
                    .Select(u => u.Active)
                    .First())
            {
                DeactivateUser(selectedUserID);
            }
            else
            {
                ActivateUser(selectedUserID);
            }
            RefreshListUsers();
        }

        /// <summary>
        /// Sets field "Active" to true.
        /// </summary>
        /// <param name="id"></param>
        private void ActivateUser(int id)
        {
            var db = new UsersDBContext();
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
                string userName = "";
                foreach (var u in db.UserMasterDatas)
                {
                    if (u.ID == id)
                    {
                        userName = u.UserName;
                        u.Active = true;
                    }
                }
                db.SaveChanges();
                labelResult.Text = $"Потребител \"{userName}\" беше активиран.";
            }
        }

        /// <summary>
        /// Sets field "Active" to false.
        /// </summary>
        /// <param name="id"></param>
        private void DeactivateUser(int id)
        {
            var db = new UsersDBContext();
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
                string userName = "";
                foreach (var u in db.UserMasterDatas)
                {
                    if (u.ID == id)
                    {
                        userName = u.UserName;
                        u.Active = false;
                    }
                }
                db.SaveChanges();
                labelResult.Text = $"Потребител \"{userName}\" беше деактивиран.";
            }
        }

        /// <summary>
        /// Clears and refills the lists with users if changes were made
        /// </summary>
        private void RefreshListUsers()
        {
            var db = new UsersDBContext();

            //List with all users....
            listUsers.Items.Clear();
            listUsers.Items.Add(new ComboBoxItem("(Изберете Потребител)", 0, Color.Black, false));
            var sortedUsers = db.UserMasterDatas.OrderBy(u => u.UserName);
            foreach (var u in sortedUsers)
            {
                listUsers.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsers.SelectedIndex = 0;

            //List only with Active Users...
            listActiveUsers.Items.Clear();
            listActiveUsers.Items.Insert(0, "(Изберете Потребител)");
            foreach (var u in sortedUsers.Where(u => u.Active))
            {
                listActiveUsers.Items.Add(u.UserName);
            }
            listActiveUsers.SelectedIndex = 0;

            //List Users to Edit..
            listUsersToEdit.Items.Clear();
            listUsersToEdit.Items.Add(new ComboBoxItem("(Изберете Потребител)", Color.Black, false));
            foreach (var u in sortedUsers)
            {
                listUsersToEdit.Items.Add(u.Active
                    ? new ComboBoxItem(u.UserName, Color.Black, false)
                    : new ComboBoxItem(u.UserName, Color.Red, true));
            }
            listUsersToEdit.SelectedIndex = 0;
        }

        /// <summary>
        /// Changes the text on the button. (Visual information only)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    .FirstOrDefault();
            //var kscEntriesForSelectedUser = db.KSCs.Where(k => k.UserID == selectedUserID);
            
            listKSCBranches.Items.Clear();
            //Fills comboBox with Users from the database
            listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
            foreach (var b in db.Branches)
            {
                listKSCBranches.Items.Add(db.KSCs.Any(k => k.BranchID == b.ID && k.UserID == selectedUserID)
                    ? new ComboBoxItem(b.BranchName, Color.Black, false)
                    : new ComboBoxItem(b.BranchName, Color.Red, true));
            }
            listKSCBranches.SelectedIndex = 0;
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
            
            KSC selectedUserKSC = db.KSCs.FirstOrDefault(k => k.BranchID == selectedBranchID && k.UserID == selectedUserID);
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
            ShowUsersForm srchUserForm = new ShowUsersForm();
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
            {
                UserIDToEdit = UserIDToEdit;
                Application.DoEvents();
                btn_EditUser.Enabled = false;
                return;
            }
            Application.DoEvents();
            btn_EditUser.Enabled = true;
            btn_newUser.Enabled = false;
            var db = new UsersDBContext();
            string UserName = listUsersToEdit.SelectedItem.ToString();
            
            var user = db.UserMasterDatas.Where(u => u.UserName == UserName);
            UserIDToEdit = user.Select(u => u.ID).FirstOrDefault();
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
            checkBoxGI.Checked = user.Select(u => u.GI??false).FirstOrDefault();
            checkBoxPurchase.Checked = user.Select(u => u.Purchase??false).FirstOrDefault();
            checkBoxTender.Checked = user.Select(u => u.Tender??false).FirstOrDefault();
            checkBoxPhibra.Checked = user.Select(u => u.Phibra??false).FirstOrDefault();
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

        private void btn_EditUser_Click(object sender, EventArgs e)
        {            
            if (UserIDToEdit == null)
                return;
            if(!string.IsNullOrEmpty(labelResult.Text))
                labelResult.Text.Remove(0);
            bool userNameEmpty = false;
            bool listPositionsEmpty = false;
            bool listBranchesEmpty = false;
            bool reqFieldEmpty = false;
            if (string.IsNullOrEmpty(textBoxUserName.Text))
            {
                reqFieldEmpty = true;
                userNameEmpty = true;
            }
            if (listPositions.SelectedIndex == 0)
            {
                reqFieldEmpty = true;
                listPositionsEmpty = true;
            }
            if (listBranches.SelectedIndex == 0)
            {
                reqFieldEmpty = true;
                listBranchesEmpty = true;
            }
            if(reqFieldEmpty)
            {
                labelResult.Text = "Не може да има празни задължителни полета:";
                if(userNameEmpty)
                    labelResult.Text += Environment.NewLine + "\t\" --> Име на потребител\"";
                if(listBranchesEmpty)
                    labelResult.Text += Environment.NewLine + "\t\" --> Склад\"";
                if (listPositionsEmpty)
                    labelResult.Text += Environment.NewLine + "\t\" --> Длъжност\"";
                return;
            }
            
            var db = new UsersDBContext();
            var user = db.UserMasterDatas.FirstOrDefault(u => u.ID == UserIDToEdit.Value);
            string tempOldName = user.UserName;
            if (user.UserName != textBoxUserName.Text)
                user.UserName = textBoxUserName.Text;

            if (user.Email != textBoxEmail.Text)
                user.Email = textBoxEmail.Text;

            if (db.ADUsers.Any(a => a.UserID == UserIDToEdit.Value))
            {
                if (string.IsNullOrEmpty(textBoxADUser.Text))
                {
                    var adUserToRemove = db.ADUsers.FirstOrDefault(a => a.UserID == UserIDToEdit.Value);
                    db.ADUsers.Remove(adUserToRemove);
                    db.SaveChanges();
                }
                else if (db.ADUsers.Where(a => a.UserID == UserIDToEdit.Value).Select(a => a.ADName).FirstOrDefault() !=
                    textBoxADUser.Text)
                {
                    ADUser adUser = db.ADUsers.FirstOrDefault(a => a.UserID == UserIDToEdit.Value);
                    adUser.ADName = textBoxADUser.Text;
                }
            }
            else if (!string.IsNullOrEmpty(textBoxADUser.Text) && textBoxADUser.Text.Length > 2)
            {
                var newADUser = new ADUser()
                {
                    UserID = UserIDToEdit.Value,
                    ADName = textBoxADUser.Text
                };
                db.ADUsers.Add(newADUser);
                db.SaveChanges();
            }
            if (listPositions.SelectedItem.ToString() !=
                db.Positions.Where(p => p.ID == UserIDToEdit.Value).Select(p => p.Position1).FirstOrDefault())
            {
                int positionID =
                    db.Positions.Where(p => p.Position1 == listPositions.SelectedItem.ToString())
                        .Select(p => p.ID)
                        .FirstOrDefault();
                user.PositionID = positionID;
            }
            if (listBranches.SelectedItem.ToString() !=
                db.Branches.Where(b => b.ID == user.BranchID).Select(b => b.BranchName).FirstOrDefault())
            {
                int branchID =
                    db.Branches.Where(b => b.BranchName == listBranches.SelectedItem.ToString())
                        .Select(b => b.ID)
                        .FirstOrDefault();
                user.BranchID = branchID;
            }
            if (user.PharmosUserName != textBoxPharmosName.Text)
                user.PharmosUserName = textBoxPharmosName.Text;

            if (user.UADMUserName != textBoxUadmName.Text)
                user.UADMUserName = textBoxUadmName.Text;

            if ((user.GI??false) != checkBoxGI.Checked)
                user.GI = checkBoxGI.Checked;

            if ((user.Purchase??false) != checkBoxPurchase.Checked)
                user.Purchase = checkBoxPurchase.Checked;

            if ((user.Purchase??false) != checkBoxPurchase.Checked)
                user.Purchase = checkBoxPurchase.Checked;

            if ((user.Tender??false) != checkBoxTender.Checked)
                user.Tender = checkBoxTender.Checked;

            if ((user.Phibra??false) != checkBoxPhibra.Checked)
                user.Phibra = checkBoxPhibra.Checked;

            if (user.Active != checkBoxIsActive.Checked)
                user.Active = checkBoxIsActive.Checked;

            db.SaveChanges();
            int selectedUserIdx = listUsersToEdit.SelectedIndex;
            RefreshListUsers();
            Application.DoEvents();
            listUsersToEdit.SelectedIndex = selectedUserIdx;
            labelResult.Text = $"Потребител {tempOldName} беше променен!";
        }
    }
}
