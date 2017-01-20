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
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBranches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new UsersDBContext();
            //listPositions.DataSource = db.Positions.Select(p => p.Position1).ToList();
            listPositions.Items.Insert(0, "(Изберете Длъжност)");
            int i = 1;
            foreach (var p in db.Positions)
            {
                listPositions.Items.Insert(i++, p.Position1);
            }
            listPositions.SelectedIndex = 0;
            //listBranches.DataSource = db.Branches.Select(b => b.BranchName).ToList();
            listBranches.Items.Insert(0, "(Изберете Филиал)");
            i = 1;
            foreach (var b in db.Branches)
            {
                listBranches.Items.Insert(i++, b.BranchName);
            }
            listBranches.SelectedIndex = 0;
            i = 1;
            listUsers.Items.Insert(0, "(Изберете Потребител)");            
            foreach(var u in db.UserMasterDatas)
            {
                if(u.Active.Value)
                    listUsers.Items.Insert(i++, u.UserName);
            }
            listUsers.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text) 
                || string.IsNullOrEmpty(listPositions.Text) 
                || string.IsNullOrEmpty(listBranches.Text))
                return;
            bool isPositionSelected = false;
            bool isBranchSelected = false;
            var db = new UsersDBContext();
            foreach(var p in db.Positions)
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
            }
            if (!(isBranchSelected && isPositionSelected))
                return;

            /*DialogResult confirmDeleteUser = MessageBox.Show($"Do you really want to delete user \"{listUsers.SelectedText}\"", "Confirm", MessageBoxButtons.YesNo);
           
            if (confirmDeleteUser == DialogResult.No)
                return;*/

            var userName = new SqlParameter("@name", textBoxUserName.Text);
            var email = new SqlParameter("@email", textBoxEmail.Text);
            var uadmName = new SqlParameter("@uadm", textBoxUadmName.Text);
            var pharmosName = new SqlParameter("@pharmos", textBoxPharmosName.Text);

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
            clearFields();
        }

        private void clearFields()
        {
            textBoxUserName.Text = "";
            textBoxEmail.Text = "";
            listPositions.SelectedIndex = 0;
            listBranches.SelectedIndex = 0;
            textBoxPharmosName.Text = "";
            textBoxUadmName.Text = "";
            checkBoxGI.Checked = false;
            checkBoxPurchase.Checked = false;
            checkBoxTender.Checked = false;
            checkBoxPhibra.Checked = false;
            checkBoxIsActive.Checked = false;
        }

        public int PositionIdFromName(string positionName)
        {
            var db = new UsersDBContext();
            int id = db.Positions.Where(p => p.Position1 == positionName).Select(i => i.ID).First();
            return id;
        }
        public int BranchIdFromName(string branchName)
        {
            var db = new UsersDBContext();
            int id = db.Branches.Where(b => b.BranchName == branchName).Select(br => br.ID).First();
            return id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmDeleteUser = MessageBox.Show($"Сигурни ли сте, че искате да деактивирате потребител \"{listUsers.SelectedItem.ToString()}\"", "Потвърди", MessageBoxButtons.YesNo);

            if (confirmDeleteUser == DialogResult.No)
            {
                labelResult.Text = "Не бяха направени промени.";
                return;
            }
            else if (confirmDeleteUser == DialogResult.Yes)
            {
                var db = new UsersDBContext();

                int userIDToDeactivate = db.UserMasterDatas.Where(u => u.UserName == listUsers.SelectedItem.ToString()).Select(u => u.ID).First();
                string tempName = "";
                foreach (var u in db.UserMasterDatas)
                {
                    if (u.ID == userIDToDeactivate)
                    {
                        tempName = u.UserName;
                        u.Active = false;
                    }
                }
                labelResult.Text = $"Потребител \"{tempName}\" беше деактивиран.";
            }
        }
    }
}
