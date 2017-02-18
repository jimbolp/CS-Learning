using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintersData
{
    public partial class PrinterData : Form
    {
        public PrinterData()
        {
            InitializeComponent();
        }
        private void ShowPrinters_Load(object sender, EventArgs e)
        {
            FillListBranches();
            LoadPrintersDataGrid();
        }
        private void LoadPrintersDataGrid()
        {
            var db = new PrintersDBContext();
            SortableBindingList<CustomPrintersTable> sbList = new SortableBindingList<CustomPrintersTable>();
            if (listBranches.SelectedIndex == 0)
            {
                foreach (var p in db.PrinterMasterData)
                {
                    if (activeCheckBox.Checked)
                        if (!(p.Active) ?? false)
                            continue;
                    sbList.Add(new CustomPrintersTable
                    {
                        ID = p.ID,
                        Name = p.PrinterName,
                        IP = p.IPAddress,
                        Branch = p.Branches.BranchName,
                        PrintID = p.PrintID,
                        PrinterModel = p.PrinterModels.PrinterModel,
                        DNSName = p.DNSName,
                        Description = p.Description,
                        Active = p.Active.ToString()
                    });
                }
            }
            else
            {
                foreach (var p in db.PrinterMasterData.Where(u => u.Branches.BranchName == listBranches.SelectedItem.ToString()))
                {
                    if (activeCheckBox.Checked)
                        if (!(p.Active) ?? false)
                            continue;
                    sbList.Add(new CustomPrintersTable
                    {
                        ID = p.ID,
                        Name = p.PrinterName,
                        IP = p.IPAddress,
                        Branch = p.Branches.BranchName,
                        PrintID = p.PrintID,
                        PrinterModel = p.PrinterModels.PrinterModel,
                        DNSName = p.DNSName,
                        Description = p.Description,
                        Active = p.Active.ToString()
                    });
                }
            }
            dataGridView1.DataSource = new BindingSource { DataSource = sbList };
            UpdateDataGridViewRowColors();            
        }

        private void UpdateDataGridViewRowColors()
        { 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (((CustomPrintersTable)row.DataBoundItem).Active == "False")
                    row.DefaultCellStyle.BackColor = Color.Red;
            }
            dataGridView1.Refresh();
        }
        private void FillListBranches()
        {
            var db = new PrintersDBContext();
            listBranches.Items.Insert(0, "Всички");
            foreach (var b in db.Branches)
            {
                listBranches.Items.Add(b.BranchName);
            }
            listBranches.SelectedIndex = 0;
        }
        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            AddPrinter frm = new AddPrinter();
            frm.FormClosed += (o, args) => LoadPrintersDataGrid();
            frm.Show();
        }
        private void editPrinterButton_Click(object sender, EventArgs e)
        {
            var selection = dataGridView1.SelectedRows;
            if (selection.Count > 1)
                return;
            CustomPrintersTable dbRow = (CustomPrintersTable)selection[0].DataBoundItem;
            PrintersDBContext db = new PrintersDBContext();
            PrinterMasterData printerToEdit = db.PrinterMasterData.Where(p => p.ID == dbRow.ID).FirstOrDefault();
            AddPrinter addPrinter = new AddPrinter(printerToEdit, true);
            addPrinter.Show();
        }
        private void addPrinterModelButton_Click(object sender, EventArgs e)
        {
            AddPrinterModel frm = new AddPrinterModel();            
            frm.Show();
            dataGridView1.Refresh();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrintersDataGrid();
        }

        private void ActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadPrintersDataGrid();            
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateDataGridViewRowColors();
        }
    }
   
}
