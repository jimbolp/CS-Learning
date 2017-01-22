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
            List<int> test = new List<int>();
            foreach (var item in chckBoxBranches.CheckedItems)
            {
                string temp = Convert.ToString(item);
                test.Add(db.Branches.Where(b => b.BranchName == temp).Select(b => b.ID).First());
            }
            var Users = db.UserMasterDatas.Where(u => test.Any(b => b == u.BranchID)).Select(o => new
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
            });
            BindingSource bs = new BindingSource()
            {
                DataSource = Users.ToList()
            };

            userDBTable.DataSource = bs;
            userDBTable.Refresh();

            
            
            /*textBoxShowUsers.Text = stringAsColumnName("ID", 10) + stringAsColumnName("Име на потребител", 30) + Environment.NewLine;
            foreach (var u in db.UserMasterDatas)
            {
                textBoxShowUsers.Text += stringAsColumnName(Convert.ToString(u.ID), 10);
                textBoxShowUsers.Text += stringAsColumnName(u.UserName, 30);
                textBoxShowUsers.Text += Environment.NewLine;
            }//*/
        }

        /*private string stringAsColumnName(string s, int offset)
        {
            int remainingSpace = 0;
            if (offset <= s.Length)
                return "|  " + s + "|";
            
                remainingSpace = offset - s.Length;
            return ("|" + new string(' ', 2) + s + new string(' ', remainingSpace) + "|");

        }//*/

        private void chckBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new UsersDBContext();

            List<int> test = new List<int>();
            foreach (var item in chckBoxBranches.CheckedItems)
            {
                string temp = Convert.ToString(item);
                test.Add(db.Branches.Where(b => b.BranchName == temp).Select(b => b.ID).First());
            }
            var Users = db.UserMasterDatas.Where(u => test.Any(b => b == u.BranchID)).Select(o => new
            {
                o.ID,
                o.UserName,
                o.Email,
                ActiveDirectory = db.ADUsers.Where(a => a.UserID == o.ID).Select(a => a.ADName).FirstOrDefault(),
                Position = db.Positions.Where(p => p.ID == o.PositionID).Select(p => p.Position1).FirstOrDefault(),
                Branch = db.Branches.Where(b => b.ID == o.BranchID).Select(b => b.BranchName).FirstOrDefault(),
                o.PharmosUserName,
                o.UADMUserName,
                GI = (o.GI.Value) ? "Да" : "Не",
                Purchase = (o.Purchase.Value) ? "Да" : "Не",
                Tender = (o.Tender.Value) ? "Да" : "Не",
                Phibra = (o.Phibra.Value) ? "Да" : "Не",
                State = (o.Active) ? "Активен" : "Неактивен"
            });
            BindingSource bs = new BindingSource()
            {
                DataSource = Users.ToList()
            };
            userDBTable.DataSource = bs;
            userDBTable.Refresh();
        }
    }
}
