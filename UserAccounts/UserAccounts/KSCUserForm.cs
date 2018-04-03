﻿using System;
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
        UsersDBContext db = null;
        public KSCUserForm(UsersDBContext db)
        {
            InitializeComponent();
            try
            {
                this.db = db;
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
        }
        public KSCUserForm(UsersDBContext db, UserMasterData user)
        {
            try
            {
                this.db = db;
            }
            catch (Exception)
            {
                MessageBox.Show("Няма връзка с базата данни!", "Проблем", MessageBoxButtons.OK);
                return;
            }
            User = user;
            InitializeComponent();
        }
        public UserMasterData User { get; set; }
        private void KSCUserForm_Load(object sender, EventArgs e)
        {
            //
        }
        private void KSCUserForm_Shown(object sender, EventArgs e)
        {
            
            if (User != null && !db.KSCs.Any(k => k.UserID == User.ID))
            {
                WindowState = FormWindowState.Minimized;
                if (MessageBox.Show("Потребител \"" + User.UserName + "\" няма KSC акаунт. Искате ли да създадете нов?", "Несъществуващ акаунт", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KSCAccount newAccount = new KSCAccount(db, User.ID);
                    newAccount.FormClosed += (o, args) => InitializeKSCDataGrid(true);
                    newAccount.Show();
                }
                else
                {
                    InitializeKSCDataGrid(true);
                    WindowState = FormWindowState.Normal;
                }
            }
            else
                InitializeKSCDataGrid(false);
            SelectRespectfulRow();
        }
        private void InitializeKSCDataGrid(bool all)
        {
            SortableBindingList<CustomKSCUser> sbList = new SortableBindingList<CustomKSCUser>();
            IQueryable<CustomKSCUser> kscUsers = null;
            if (all)
            {
                kscUsers = db.KSCs.Select(k => new CustomKSCUser
                {
                    ID = k.ID,
                    UserID = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.ID).FirstOrDefault(),
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
                try
                {
                    if (User == null)
                        throw new ArgumentNullException();
                    kscUsers = db.KSCs.Where(k => k.UserID == User.ID).Select(k => new CustomKSCUser
                    {
                        ID = k.ID,
                        UserID = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.ID).FirstOrDefault(),
                        UserName = db.UserMasterDatas.Where(u => u.ID == k.UserID).Select(u => u.UserName).FirstOrDefault(),
                        KSCUserName = k.UserName,
                        TermID = k.TermID,
                        UID = k.UID,
                        AllowFC = (k.AllowFC) ? "Да" : "Не",
                        Branch = db.Branches.Where(b => b.ID == k.BranchID).Select(b => b.BranchName).FirstOrDefault()
                    });
                }
                catch (ArgumentNullException)
                {
                    InitializeKSCDataGrid(true);
                    return;
                }
                catch (Exception)
                {
                    InitializeKSCDataGrid(true);
                    return;
                }
            }
            foreach (CustomKSCUser kUser in kscUsers.OrderBy(k => k.UserName))
            {
                sbList.Add(kUser);
            }
            BindingSource bs = new BindingSource()
            {
                DataSource = sbList
            };
            kscUserTable.DataSource = bs;
            foreach(DataGridViewRow row in kscUserTable.Rows)
            {
                row.HeaderCell.Value = Convert.ToString(row.Index + 1);
            }
            kscUserTable.Update();
            kscUserTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            kscUserTable.Columns[0].Visible = false;
            kscUserTable.Columns[1].Visible = false;

        }
        
        private void SelectRespectfulRow()
        {
            if (User == null)
                return;
            int selectedIdx = -1;
            foreach (DataGridViewRow row in kscUserTable.Rows)
            {
                if (((CustomKSCUser)row.DataBoundItem).UserID == User.ID)
                {
                    selectedIdx = kscUserTable.Rows.IndexOf(row);
                    break;
                }
            }
            if (selectedIdx >= 0)
            {
                //kscUserTable.Rows[selectedIdx].Selected = true;
                //kscUserTable.CurrentCell = kscUserTable.SelectedRows[0].Cells[0];
                foreach (DataGridViewRow row in kscUserTable.SelectedRows)
                {
                    row.Selected = false;
                }
                kscUserTable.FirstDisplayedScrollingRowIndex = selectedIdx;
                kscUserTable.Rows[selectedIdx].Selected = true;
            }
        }

        private void btn_EditKSCAccount_Click(object sender, EventArgs e)
        {
            if (kscUserTable.SelectedRows.Count != 1)
                return;
            OpenKSCUserToEdit((CustomKSCUser)kscUserTable.SelectedRows[0].DataBoundItem);
        }
        private void OpenKSCUserToEdit(CustomKSCUser kscUser)
        {
            KSCAccount EditKSCUserForm = new KSCAccount(db, kscUser);
            EditKSCUserForm.FormClosed += (o, args) => InitializeKSCDataGrid(false);
            EditKSCUserForm.FormClosed += (o, args) => SelectRespectfulRow();
            EditKSCUserForm.Show();
        }

        private void btn_newKSCAccount_Click(object sender, EventArgs e)
        {
            if (kscUserTable.SelectedRows.Count != 1)
                return;
            
            int selectedUserID = ((CustomKSCUser)kscUserTable.SelectedRows[0].DataBoundItem).UserID;
            int userID = db.UserMasterDatas
                .Where(u => u.ID == selectedUserID)
                .Select(u => u.ID)
                .FirstOrDefault();
            KSCAccount newKSCAcc = new KSCAccount(db, userID);
            newKSCAcc.FormClosed += (o, args) => InitializeKSCDataGrid(true);
            newKSCAcc.FormClosed += (o, args) => SelectRespectfulRow();
            newKSCAcc.Show();
        }
    }
}
