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
                if (p.Position1 == listPositions.SelectedText)
                {
                    isPositionSelected = true;
                    break;
                }
            }
            foreach(var b in db.Branches)
            {
                if(b.BranchName == listBranches.SelectedText)
                {
                    isBranchSelected = true;
                    break;
                }
            }
            if (!(isBranchSelected && isPositionSelected))
                return;
            var newUser = new UserMasterData
            {
                UserName = textBoxUserName.Text,
                Email = textBoxEmail.Text,
                PositionID = PositionIdFromName(listPositions.Text),
                BranchID = BranchIdFromName(listBranches.Text),
                PharmosUserName = textBoxPharmosName.Text,
                UADMUserName = textBoxUadmName.Text,
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
    }
}
