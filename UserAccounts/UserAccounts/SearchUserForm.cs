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
    public partial class SearchUserForm : Form
    {
        public SearchUserForm()
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

        private void loadUserDBTable()
        {
            var db = new UsersDBContext();
            
            List<int> checkedBranches = (from object item in chckBoxBranches.CheckedItems select Convert.ToString(item) into itemName select db.Branches.Where(b => b.BranchName == itemName).Select(b => b.ID).First()).ToList();
            
            /*var Users = db.UserMasterDatas.Where(u => test.Any(b => b == u.BranchID)).Select(o => new
            {
                o.ID,
                o.UserName,
                o.Email,
                ActiveDirectory = db.ADUsers.Where(a => a.UserID == o.ID).Select(a => a.ADName).FirstOrDefault(),
                Position = db.Positions.Where(p => p.ID == o.PositionID).Select(p => p.Position1).FirstOrDefault(),
                Branch = db.Branches.Where(b => b.ID == o.BranchID).Select(b => b.BranchName).FirstOrDefault(),
                o.PharmosUserName,
                o.UADMUserName,
                GI = (o.GI.Value)? "Да" : "Не",
                Purchase = (o.Purchase.Value)? "Да" : "Не",
                Tender = (o.Tender.Value)? "Да" : "Не",
                Phibra = (o.Phibra.Value)? "Да" : "Не",
                State = (o.Active)? "Активен" : "Неактивен"
            });//*/

            SortableBindingList<CustomUser> sbList = new SortableBindingList<CustomUser>();
            var orderdUsers = db.UserMasterDatas.OrderBy(u => u.UserName).Where(u => checkedBranches.Any(b => b == u.BranchID));
            foreach (var o in orderdUsers)
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
            }
            userDBTable.DataSource = new BindingSource()
            {
                DataSource = sbList
            };
            userDBTable.Refresh();
        }
    }
}
