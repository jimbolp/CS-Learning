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

        private void KSCUserForm_Load(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            var kscUsers = db.KSCs.Select(k => new
            {
                UserName = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.UserName).FirstOrDefault(),
                KscUserName = k.UserName,
                k.TermID,
                k.UID,
                AllowFC = (k.AllowFC) ? "Да" : "Не",
                Branch = db.Branches.Where(b => b.ID == k.BranchID).Select(b => b.BranchName).FirstOrDefault()
            });
            BindingSource bs = new BindingSource()
            {
                DataSource = kscUsers.ToList()
            };
            kscUserTable.DataSource = bs;
            kscUserTable.Refresh();
        }
    }
}
