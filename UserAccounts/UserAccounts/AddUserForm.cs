using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccounts
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            initializeDropDownLists();
            btn_EditUser.Enabled = false;
            btn_EditUser.Visible = false;
            btn_newUser.Visible = true;
            btn_newUser.Enabled = true;
            
        }
        public AddUserForm(UserMasterData user)
        {
            InitializeComponent();
            initializeDropDownLists();
            InitializeFields(user);
            btn_newUser.Visible = false;
            btn_newUser.Enabled = false;
            btn_EditUser.Enabled = true;
            btn_EditUser.Visible = true;
            UserToEdit = user;            
        }
        private UserMasterData UserToEdit { get; set; }
        private void InitializeFields(UserMasterData user)
        {
            var db = new UsersDBContext();
            textBoxUserName.Text = user.UserName;
            textBoxEmail.Text = user.Email;
            textBoxADUser.Text =
                user.ADUsers.Where(a => a.UserID == user.ID).Select(a => a.ADName).FirstOrDefault();
            int selectedBranch = 0;
            foreach (string item in listBranches.Items)
            {
                if (item == user.Branch.BranchName)
                {
                    selectedBranch = listBranches.Items.IndexOf(item);
                    break;
                }
            }
            listBranches.SelectedIndex = selectedBranch;
            int selectedPosition = 0;
            foreach (string item in listPositions.Items)
            {
                if (item == null || (db.Positions.Where(p => p.ID == user.PositionID.Value)
                        .Select(p => p.Position1)
                        .FirstOrDefault() == null))
                    continue;
                
                if(item == db.Positions.Where(p => p.ID == user.PositionID.Value)
                    .Select(p => p.Position1)
                    .FirstOrDefault())
                try
                {
                    selectedPosition = listPositions.Items.IndexOf(item);
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message +
                        Environment.NewLine + ex.StackTrace,"Exception!");
                }
                
            }
            listPositions.SelectedIndex = selectedPosition;
            
            textBoxPharmosName.Text = user.PharmosUserName;
            textBoxUadmName.Text = user.UADMUserName;
            checkBoxGI.Checked = user.GI ?? false;
            checkBoxPhibra.Checked = user.Phibra ?? false;
            checkBoxPurchase.Checked = user.Purchase ?? false;
            checkBoxTender.Checked = user.Tender ?? false;
            checkBoxIsActive.Checked = user.Active;
        }

        public void btn_newUser_Click(object sender, EventArgs e)
        {
            if (!isAllowedToAddUser())
                return;
            CreateNewUser();
            var showUserForm = new ShowUsersForm();
            showUserForm.loadUserDBTable();
        }
        private void initializeDropDownLists()
        {
            listBranches.Items.Clear();
            listPositions.Items.Clear();
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
        }
        private void CreateNewUser()
        {
            var db = new UsersDBContext();

            DialogResult confirmCreateUser = MessageBox.Show($"Сигурни ли сте, че искате да създадете потребител \"{textBoxUserName.Text}\"", "Confirm", MessageBoxButtons.YesNo);

            if (confirmCreateUser == DialogResult.No)
            {
                MessageBox.Show("Не бяха направени промени.");
                return; //*/
            }

            var userName = new SqlParameter("@name", textBoxUserName.Text);
            var email = new SqlParameter("@email", textBoxEmail.Text);
            var uadmName = new SqlParameter("@uadm", textBoxUadmName.Text);
            var pharmosName = new SqlParameter("@pharmos", textBoxPharmosName.Text);
            //var adName = new SqlParameter("@adName", textBoxADUser.Text);

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
                
                var adUser = new ADUser()
                {
                    UserID = newUser.ID,
                    ADName = Convert.ToString((new SqlParameter("@adName", textBoxADUser.Text)).SqlValue)
                };
                db.ADUsers.Add(adUser);
                db.SaveChanges();
            }
        }
        private bool isAllowedToAddUser()
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text))
            {
                MessageBox.Show("Моля въведете Име! Полето не може да бъде празно.", "Празно поле!");
                return false;
            }
            var db = new UsersDBContext();

            bool isPositionSelected = db.Positions.Any(p => p.Position1 == listPositions.SelectedItem.ToString());
            bool isBranchSelected = db.Branches.Any(b => b.BranchName == listBranches.SelectedItem.ToString());

            if (!isBranchSelected && !isPositionSelected)
            {
                MessageBox.Show("Изберете Склад и Длъжност!", "Празно поле!");
                return false;
            }

            if (!isPositionSelected)
            {
                MessageBox.Show("Изберете Длъжност!", "Празно поле!");
                return false;
            }

            if (!isBranchSelected)
            {
                MessageBox.Show("Изберете Склад!", "Празно поле!");
                return false;
            }
            return true;
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

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            //initializeDropDownLists();
        }

        private void btn_EditUser_Click(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            var userToEdit = db.UserMasterDatas.Where(u => u.ID == UserToEdit.ID).FirstOrDefault();
            
            if (!isAllowedToAddUser())
                return;
            string selectedBranch = listBranches.SelectedItem.ToString();
            string selectedPosition = listPositions.SelectedItem.ToString();
            int selectedPositionID = db.Positions
                .Where(p => p.Position1 == selectedPosition)
                .Select(p => p.ID).FirstOrDefault();
            if (userToEdit.UserName != textBoxUserName.Text)
                userToEdit.UserName = textBoxUserName.Text;
            if (userToEdit.Email != textBoxEmail.Text)
                userToEdit.Email = textBoxEmail.Text;
            if (userToEdit.PharmosUserName != textBoxPharmosName.Text)
                userToEdit.PharmosUserName = textBoxPharmosName.Text;
            if (userToEdit.UADMUserName != textBoxUadmName.Text)
                userToEdit.UADMUserName = textBoxUadmName.Text;
            if(userToEdit.PositionID != selectedPositionID)
            {
                userToEdit.PositionID = db.Positions.Where(p => p.Position1 == selectedPosition)
                    .Select(p => p.ID).FirstOrDefault();
            }
            if(userToEdit.Branch.BranchName != selectedBranch)
            {
                userToEdit.BranchID = db.Branches
                    .Where(b => b.BranchName == selectedBranch)
                    .Select(b => b.ID).FirstOrDefault();
            }
            if ((userToEdit.GI ?? false) != checkBoxGI.Checked)
                userToEdit.GI = checkBoxGI.Checked;
            if((userToEdit.Purchase ?? false) != checkBoxPurchase.Checked)
            {
                userToEdit.Purchase = checkBoxPurchase.Checked;
            }
            if((userToEdit.Tender ?? false) != checkBoxTender.Checked)
            {
                userToEdit.Tender = checkBoxTender.Checked;
            }
            if((userToEdit.Phibra ?? false) != checkBoxPhibra.Checked)
            {
                userToEdit.Phibra = checkBoxPhibra.Checked;
            }
            if (userToEdit.Active != checkBoxIsActive.Checked)
                userToEdit.Active = checkBoxIsActive.Checked;
            if (string.IsNullOrEmpty(textBoxADUser.Text))
            {
                if(db.ADUsers.FirstOrDefault(a => a.UserID == userToEdit.ID) != null)
                {                    
                    db.ADUsers.Remove(db.ADUsers.Where(a => a.UserID == userToEdit.ID).FirstOrDefault());
                }
            }
            else
            {
                ADUser adUser = db.ADUsers.FirstOrDefault(a => a.UserID == userToEdit.ID);
                if (adUser != null
                    && adUser.ADName != textBoxADUser.Text)
                {
                    adUser.ADName = textBoxADUser.Text;
                }
                else if(adUser == null)
                {
                    ADUser newADUser = new ADUser()
                    {
                        UserID = userToEdit.ID,
                        ADName = textBoxADUser.Text
                    };
                    db.ADUsers.Add(newADUser);
                }
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Промените бяха запазени успешно.", "Запазване");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message +
                    Environment.NewLine +
                    ex.StackTrace, "Exception!!!");
            }//*/

        }
    }
}