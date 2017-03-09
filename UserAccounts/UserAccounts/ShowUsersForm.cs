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
            var db = new UsersDBContext();

            foreach (var b in db.Branches)
            {
                chckBoxBranches.Items.Add(b.BranchName, CheckState.Checked);
            }

            loadUserDBTable();
        }

        private void chckBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserDBTable();
        }

        public void loadUserDBTable()
        {
            var db = new UsersDBContext();

            List<int> checkedBranches = (from object item in chckBoxBranches.CheckedItems select Convert.ToString(item) into itemName select db.Branches.Where(b => b.BranchName == itemName).Select(b => b.ID).FirstOrDefault()).ToList();

            SortableBindingList<CustomUser> sbList = new SortableBindingList<CustomUser>();
            var orderdUsers = db.UserMasterDatas.OrderBy(u => u.UserName).Where(u => checkedBranches.Any(b => b == u.BranchID)).Select(u => new CustomUser
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
                State = (u.Active) ? "Активен" : "Неактивен"
            }).ToList();//*/

            foreach (var o in orderdUsers)
            {
                sbList.Add(o);
            }
            /*foreach (var o in orderdUsers)
            {
                sbList.Add(new CustomUser
                {
                    ID = o.ID,
                    UserName = o.UserName,
                    Email = o.Email,
                    ActiveDirectory = db.ADUsers.Where(a => a.UserID == o.ID).Select(a => a.ADName).FirstOrDefault(),
                    Position = db.Positions.Where(p => p.ID == o.PositionID).Select(p => p.Position1).FirstOrDefault(),
                    Depo = db.Branches.Where(b => b.ID == o.BranchID).Select(b => b.BranchName).FirstOrDefault(),
                    PharmosUserName = o.PharmosUserName,
                    UADMUserName = o.UADMUserName,
                    GoodsIn = (o.GI == null) ? "Не" : (o.GI.Value) ? "Да" : "Не",
                    PurchaseAccount = (o.Purchase == null) ? "Не" : (o.Purchase.Value) ? "Да" : "Не",
                    TenderAccount = (o.Tender == null) ? "Не" : (o.Tender.Value) ? "Да" : "Не",
                    PhibraAccount = (o.Phibra == null) ? "Не" : (o.Phibra.Value) ? "Да" : "Не",
                    State = (o.Active) ? "Активен" : "Неактивен"
                });
            }//*/
            userDBTable.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            //userDBTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            userDBTable.RowHeadersVisible = false;
            userDBTable.DataSource = new BindingSource()
            {
                DataSource = sbList
            };
            userDBTable.Columns[0].Visible = false;

            ColorizeInactiveUsers(db);
            userDBTable.RowHeadersVisible = true;
            userDBTable.Refresh();
        }

        private void ColorizeInactiveUsers(UsersDBContext db)
        {

            for (int i = 0; i < userDBTable.Rows.Count; i++)
            {
                CustomUser cu = (CustomUser)userDBTable.Rows[i].DataBoundItem;
                UserMasterData umd = db.UserMasterDatas.FirstOrDefault(u => u.ID == cu.ID);
                if (!umd.Active)
                {
                    userDBTable.Rows[i].DefaultCellStyle.BackColor = Color.Red;
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
            var db = new UsersDBContext();
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
    }
}
