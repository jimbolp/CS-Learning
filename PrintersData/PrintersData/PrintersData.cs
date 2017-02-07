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
    public partial class PrintersData : Form
    {
        public PrintersData()
        {
            InitializeComponent();
        }

        private void ShowPrinters_Load(object sender, EventArgs e)
        {
            var db = new PrintersDB();

            SortableBindingList<CustomPrintersTable> sbList = new SortableBindingList<CustomPrintersTable>();           

            foreach (var p in db.PrinterMasterData)
            {
                sbList.Add(new CustomPrintersTable{
                    Name = p.PrinterName,
                    IP = p.IPAddress,
                    Branch = p.Branches.BranchName,
                    PrintID = p.PrintID,
                    PrinterModel = p.PrinterModels.PrinterModel,
                    DNSName = p.DNSName,
                    Description = p.Description
                });
            }
            string test = sbList[0].ToString();
            dataGridView1.DataSource = new BindingSource
            {
                DataSource = sbList
            };
            dataGridView1.Refresh();
        }

        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            AddPrinter frm = new AddPrinter();
            frm.FormClosed += Frm_FormClosed;
            this.Hide();
            frm.Show();
            dataGridView1.Refresh();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            dataGridView1.Refresh();
        }

        private void deactivatePrinterButton_Click(object sender, EventArgs e)
        {
            var db = new PrintersDB();

            DialogResult confirmDeactivatePrinter = MessageBox.Show($"Сигурни ли сте, че искате да деактивирате принтер \"", "Confirm", MessageBoxButtons.YesNo);
            if(confirmDeactivatePrinter == DialogResult.Yes)
            {
                
            } 
        }

        private void editPrinterButton_Click(object sender, EventArgs e)
        {

        }

        private void addPrinterModelButton_Click(object sender, EventArgs e)
        {
            AddPrinterModel frm = new AddPrinterModel();
            frm.FormClosed += Frm_FormClosed;
            this.Hide();
            frm.Show();
            dataGridView1.Refresh();
        }
    }
   
}
