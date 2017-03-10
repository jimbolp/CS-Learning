using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccounts
{
    public partial class KSCUserForm : Form
    {
        public KSCUserForm()
        {
            InitializeComponent();
        }
        public KSCUserForm(UserMasterData user)
        {
            User = user;
            InitializeComponent();
        }
        public UserMasterData User { get; set; }
        private void KSCUserForm_Load(object sender, EventArgs e)
        {
            if (User == null)
                InitializeKSCDataGrid(true);
            else
                InitializeKSCDataGrid(false);
        }
        private void InitializeKSCDataGrid(bool all)
        {
            var db = new UsersDBContext();
            SortableBindingList<CustomKSCUser> sbList = new SortableBindingList<CustomKSCUser>();
            IQueryable<CustomKSCUser> kscUsers;
            if (all)
            {
                kscUsers = db.KSCs.Select(k => new CustomKSCUser
                {
                    UserName = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.UserName).FirstOrDefault(),
                    KSCUserName = k.UserName,
                    TermID = k.TermID,
                    UID = k.UID,
                    AllowFC = (k.AllowFC) ? "Да" : "Не",
                    Branch = db.Branches.Where(b => b.ID == k.BranchID).Select(b => b.BranchName).FirstOrDefault()
                });
            }
            else
            {
                kscUsers = db.KSCs.Where(k => k.UserID == User.ID).Select(k => new CustomKSCUser
                {
                    UserName = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.UserName).FirstOrDefault(),
                    KSCUserName = k.UserName,
                    TermID = k.TermID,
                    UID = k.UID,
                    AllowFC = (k.AllowFC) ? "Да" : "Не",
                    Branch = db.Branches.Where(b => b.ID == k.BranchID).Select(b => b.BranchName).FirstOrDefault()
                });
            }
            foreach (var k in kscUsers)
            {
                sbList.Add(k);
            }
            BindingSource bs = new BindingSource()
            {
                DataSource = sbList
            };
            kscUserTable.DataSource = bs;
            kscUserTable.Refresh();
        }
    }
}
