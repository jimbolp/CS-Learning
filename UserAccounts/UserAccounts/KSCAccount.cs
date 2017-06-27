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
            LoadBranches();
            btn_createKSCAccount.Enabled = true;
            btn_createKSCAccount.Visible = true;
            btn_EditKSCAccount.Enabled = false;
            btn_EditKSCAccount.Visible = false;
        }
        public KSCAccount(CustomKSCUser userToEdit)
        {
            InitializeComponent();
            LoadBranches();
            LoadFields(userToEdit);
            btn_createKSCAccount.Enabled = false;
            btn_createKSCAccount.Visible = false;
            btn_EditKSCAccount.Enabled = true;
        }
        private void LoadFields(CustomKSCUser user)
        {
            textBoxKSCUserName.Text = user.KSCUserName;
            textBoxTermID.Text = user.TermID;
            textBoxUID.Text = user.UID.ToString();
            chckBoxFC.Checked = (user.AllowFC == "Да") ? true : false;
            foreach(ComboBoxItem item in listKSCBranches.Items)
            {
                if (item.ToString() == user.Branch)
                {
                    listKSCBranches.SelectedIndex = listKSCBranches.Items.IndexOf(item);
                    break;
                }
            }
        }
        private void LoadBranches()
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
            //Fill comboBox with Depots from the database
            listKSCBranches.Items.Add(new ComboBoxItem("(Изберете Склад)", Color.Black, false));
            foreach (var b in db.Branches)
            {
                listKSCBranches.Items.Add(new ComboBoxItem(b.BranchName, Color.Black, false));
            }            
            listKSCBranches.SelectedIndex = 0;            
        }
        private void KSCAccount_Load(object sender, EventArgs e)
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
            labelUserName.Text = db.UserMasterDatas.Where(u => u.ID == UserID).Select(u => u.UserName).FirstOrDefault();
        }
        private bool EmptyField()
        {
            if (string.IsNullOrEmpty(textBoxKSCUserName.Text) 
                || string.IsNullOrEmpty(textBoxTermID.Text) 
                || string.IsNullOrEmpty(textBoxUID.Text) 
                || listKSCBranches.SelectedIndex == 0)
                return true;
            return false;
        }

        private void btn_EditKSCAccount_Click(object sender, EventArgs e)
        {
            if (EmptyField())
            {
                //TODO... Show Message..
                return;
            }
            //UserExistsInSelectedBranch();
        }

        private void btn_createKSCAccount_Click(object sender, EventArgs e)
        {
            if (EmptyField())
            {
                //TODO... Show Message..
                return;
            }
            switch (KSCAccountExists())
            {
                case 0:
                    SaveNewAccount();
                    break;
                case 1:
                    MessageBox.Show("Акаунт \"" + textBoxKSCUserName.Text + "\" вече съществува!", "Дублирано Потр. Име!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Акаунт с TermID: \"" + textBoxTermID.Text + "\" вече съществува!", "Дублиран TermID!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Акаунт с UID: \"" + textBoxUID.Text + "\" вече съществува!", "Дублиран UID!", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Потребителят вече има KSC акаунт в бранч \"" + listKSCBranches.SelectedItem.ToString(), "Съществуващ акаунт!", MessageBoxButtons.OK);
                    break;
                default:
                    MessageBox.Show("Непозната грешка!", "Грешка", MessageBoxButtons.OK);
                    break;
            }
        }

        private void SaveNewAccount()
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
            string branchName = Convert.ToString(listKSCBranches.SelectedItem);
            var newUser = new KSC()
            {
                UserName = textBoxKSCUserName.Text,
                TermID = textBoxTermID.Text,
                UID = Convert.ToInt32(textBoxUID.Text),
                UserID = UserID,
                AllowFC = chckBoxFC.Checked,
                BranchID = db.Branches.Where(b => b.BranchName == branchName)
                                        .Select(b => b.ID)
                                        .FirstOrDefault()
            };
            db.KSCs.Add(newUser);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Промените бяха запазени успешно", "Информация", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Промените не бяха запазени"
                    + Environment.NewLine
                    + e.Message
                    + Environment.NewLine
                    + e.StackTrace, "Грешка!", MessageBoxButtons.OK);
            }
        }

        private int KSCAccountExists()
        {
            UsersDBContext db = null;
            try
            {
                db = new UsersDBContext();
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return -1;
            }
            int UID = Convert.ToInt32(textBoxUID.Text);
            string branch = Convert.ToString(listKSCBranches.SelectedItem);
            /*if (db.KSCs.Any(k => k.UserName == textBoxKSCUserName.Text))
                return 1; //KSC UserName Exists//*/
            if (db.KSCs.Where(k => k.Branch.BranchName == branch).Any(k => k.TermID == textBoxTermID.Text))
                return 2; //There is User with the same TermID (NOT possible)
            if (db.KSCs.Where(k => k.Branch.BranchName == branch).Any(k => k.UID == UID))
                return 3; //There is User with the same UID (again.. NOT possible)
            if (db.KSCs.Where(k => k.Branch.BranchName == branch).Any(k => k.UserID == UserID))
                return 4; //There is already KSC account for this User in the selected branch
            return 0;
        }
    }        
}
