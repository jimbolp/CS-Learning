using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccounts
{
    public partial class ShowUsersForm : Form
    {
        public ShowUsersForm()
        {
            InitializeComponent();
        }

        private void SearchUserForm_Load(object sender, EventArgs e)
        {
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
            int i = 0;
            foreach (var b in db.Branches)
            {
                listBoxBranches.Items.Add(b.BranchName);
                listBoxBranches.SetSelected(i++, true);
            }

            loadUserDBTable();
            loadListBoxPositions();
        }
        public int SelectedDataGridIdx { get; set; }
        private void loadListBoxPositions()
        {
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
            int i = 0;
            listBoxPositions.Items.Clear();
            foreach(var p in db.Positions.OrderBy(p => p.Position1))
            {
                listBoxPositions.Items.Add(p.Position1);
                listBoxPositions.SetSelected(i++, true);
            }
        }
        private void listBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserDBTable();
        }

        public void loadUserDBTable()
        {
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }

            List<int> checkedBranches = (from object item in listBoxBranches.SelectedItems select Convert.ToString(item) into itemName select db.Branches.Where(b => b.BranchName == itemName).Select(b => b.ID).FirstOrDefault()).ToList();

            List<int> checkedPositions = (from object item in listBoxPositions.SelectedItems select Convert.ToString(item) into itemName select db.Positions.Where(p => p.Position1 == itemName).Select(p => p.ID).FirstOrDefault()).ToList();

            SortableBindingList < CustomUser > sbList = new SortableBindingList<CustomUser>();
            var orderdUsers = db.UserMasterDatas.OrderBy(u => u.UserName).Where(u => checkedBranches.Any(b => b == u.BranchID) && checkedPositions.Any(p => p == u.PositionID)).Select(u => new CustomUser
            {
                ID = u.ID,
                UserName = u.UserName,
                Email = u.Email,
                ActiveDirectory = db.ADUsers.Where(a => a.UserID == u.ID).Select(a => a.ADName).FirstOrDefault(),
                Position = db.Positions.Where(p => p.ID == u.PositionID).Select(p => p.Position1).FirstOrDefault(),
                Depo = db.Branches.Where(b => b.ID == u.BranchID).Select(b => b.BranchName).FirstOrDefault(),
                PharmosUserName = u.PharmosUserName,
                UADMUserName = u.UADMUserName,
                GoodsIn = (u.GI == null) ? "Не" : (u.GI.Value) ? "Да" : "Не",
                PurchaseAccount = (u.Purchase == null) ? "Не" : (u.Purchase.Value) ? "Да" : "Не",
                TenderAccount = (u.Tender == null) ? "Не" : (u.Tender.Value) ? "Да" : "Не",
                PhibraAccount = (u.Phibra == null) ? "Не" : (u.Phibra.Value) ? "Да" : "Не",
                State = (u.Active) ? "Активен" : "Неактивен",
                Description = u.Description
            }).ToList();//*/

            foreach (var o in orderdUsers)
            {
                sbList.Add(o);
            }
            
            userDBTable.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;            
            userDBTable.RowHeadersVisible = false;
            userDBTable.DataSource = new BindingSource()
            {
                DataSource = sbList
            };
            userDBTable.Columns[0].Visible = false;

            ColorizeInactiveUsers(db);
            userDBTable.RowHeadersVisible = true;            
            userDBTable.Update();
            userDBTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ColorizeInactiveUsers(UsersDBContext db)
        {

            for (int i = 0; i < userDBTable.Rows.Count; i++)
            {
                CustomUser cu = (CustomUser)userDBTable.Rows[i].DataBoundItem;
                UserMasterData umd = db.UserMasterDatas.FirstOrDefault(u => u.ID == cu.ID);
                if (!umd.Active)
                {
                    userDBTable.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255,25,25);
                }
            }
        }
        private void btn_Customize_Click(object sender, EventArgs e)
        {
            Form1 editUser = new Form1();
            editUser.FormClosed += new FormClosedEventHandler((o, args) => Visible = true);
            Visible = false;
            editUser.Show();
        }

        private void SearchUserForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                loadUserDBTable();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.btn_EditUser.Enabled = false;
            addUserForm.btn_EditUser.Visible = false;
            addUserForm.btn_newUser.Visible = true;
            addUserForm.btn_newUser.Enabled = true;
            addUserForm.FormClosed += (o, args) => loadUserDBTable();

            //Visible = false;
            addUserForm.Show();
        }

        private void btn_EditUser_Click(object sender, EventArgs e)
        {
            ShowFormToEdit();
        }
        private void ShowFormToEdit()
        {
            if (userDBTable.SelectedRows.Count != 1)
                return;
            int selectedUserID = ((CustomUser)userDBTable.SelectedRows[0].DataBoundItem).ID;
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
            UserMasterData userToEdit = db.UserMasterDatas.FirstOrDefault(u => u.ID == selectedUserID);
            AddUserForm addUserForm = new AddUserForm(userToEdit);

            addUserForm.FormClosed += (o, args) => loadUserDBTable();

            addUserForm.Show();
        }

        private void userDBTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColorizeInactiveUsers(new UsersDBContext());
        }

        private void userDBTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowFormToEdit();
        }
                
        private void OpenKSCAccount()
        {
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
            int selectedUserID = ((CustomUser)userDBTable.SelectedRows[0].DataBoundItem).ID;
            KSCUserForm kscForm = new KSCUserForm(db.UserMasterDatas.FirstOrDefault(u => u.ID == selectedUserID));
            //kscForm.FormClosed += (o, args) => loadUserDBTable();
            if (!kscForm.Visible)
                kscForm.Show();
            else
                kscForm.Select();
        }
        private void NewKSCAccount(int userID)
        {
            KSCAccount kscAccount = new KSCAccount(userID);
            kscAccount.Show();
        }

        private void btn_KSCAccount_Click(object sender, EventArgs e)
        {
            if (userDBTable.SelectedRows.Count != 1)
                return;
            OpenKSCAccount();
        }

        private void btn_FilterPos_Click(object sender, EventArgs e)
        {
            loadUserDBTable();
        }

        private void chckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBoxSelectAll.Checked)
                for (int i = 0; i < listBoxPositions.Items.Count; ++i)
                    listBoxPositions.SetSelected(i, true);                
            
            else
                for (int i = 0; i < listBoxPositions.Items.Count; ++i)
                    listBoxPositions.SetSelected(i, false);
        }

        private void listBoxPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPositions.SelectedItems.Count == listBoxPositions.Items.Count)
                chckBoxSelectAll.Checked = true;
            else
                chckBoxSelectAll.Checked = false;
        }
    }
}
