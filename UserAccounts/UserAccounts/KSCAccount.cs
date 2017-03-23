using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccounts
{
    public partial class KSCAccount : Form
    {
        public int UserID { get; set; }
        public KSCAccount()
        {
            InitializeComponent();
        }
        public KSCAccount(int userID)
        {            
            UserID = userID;
            InitializeComponent();
        }

        private void KSCAccount_Load(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            labelUserName.Text = db.UserMasterDatas.Where(u => u.ID == UserID).Select(u => u.UserName).FirstOrDefault();
        }
    }
}
