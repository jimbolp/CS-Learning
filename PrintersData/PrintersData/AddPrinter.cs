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

namespace PrintersData
{
    public partial class AddPrinter : Form
    {
        public AddPrinter()
        {
            InitializeComponent();
        }

        private void PrintersData_Load(object sender, EventArgs e)
        {
            fillDropDownLists();           
        }

        private void fillDropDownLists()
        {
            var db = new PrintersDB();

            //Fill comboBox with printer models from the db
            var sortedPrinterModels = db.PrinterModels.OrderBy(p => p.PrinterModel);
            listPrinterModels.Items.Insert(0, "(Изберете модел принтер)");
            foreach (var p in sortedPrinterModels)
            {
                listPrinterModels.Items.Add(p.PrinterModel);
            }
            listPrinterModels.SelectedIndex = 0;

            //Fill comboBox with branches from the db
            listBranches.Items.Insert(0, "(Изберете склад)");
            foreach (var b in db.Branches)
            {
                listBranches.Items.Add(b.BranchName);
            }
            listBranches.SelectedIndex = 0;
        } 

        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(printerNameTextBox.Text)
                || string.IsNullOrEmpty(IPAddressTextBox.Text)
                || string.IsNullOrEmpty(listBranches.Text)
                || string.IsNullOrEmpty(listPrinterModels.Text))
            {
                labelResult.Text = "Някое от задължителните полета е празно";
                return;
            }
            var db = new PrintersDB();

            bool isPrinterModelSelected = db.PrinterModels.Any(p => p.PrinterModel == listPrinterModels.SelectedItem.ToString());
            bool isBranchSelected = db.Branches.Any(b => b.BranchName == listBranches.SelectedItem.ToString());

            if (!isPrinterModelSelected && !isBranchSelected)
            {
                labelResult.Text = "Изберете склад и модел принтер";
                return;
            }
            if(!isBranchSelected)
            {
                labelResult.Text = "Изберете склад";
            }
            if (!isPrinterModelSelected)
            {
                labelResult.Text = "Изберете модел принтер";
            }

            DialogResult confirmAddPrinter = MessageBox.Show($"Сигурни ли сте, че искате да добавите принтер \"{printerNameTextBox.Text}\"", "Confirm", MessageBoxButtons.YesNo);
            if (confirmAddPrinter == DialogResult.No)
            {
                labelResult.Text = "Не бяха направени промени";
                return;
            }

            var printerName = new SqlParameter("@name", printerNameTextBox.Text);
            var IPAddress = new SqlParameter("@IPAddress", IPAddressTextBox.Text);
            var printID = new SqlParameter("@printID", printIDTextBox.Text);
            var description = new SqlParameter("@description", descriptionTextBox.Text);
            var dnsName = new SqlParameter("@dnsName", dnsNameTextBox.Text);

            var newprinter = new PrinterMasterData
            {
                PrinterName = printerName.SqlValue.ToString(),
                IPAddress = IPAddress.SqlValue.ToString(),
                PrintID = printID.SqlValue.ToString(),
                Description = description.SqlValue.ToString(),
                DNSName = dnsName.SqlValue.ToString(),
                BranchID = branchIDFromName(listBranches.Text),
                PrinterModeID = printerModelFromName(listPrinterModels.Text),
                Active = activeCheckBox.Checked
            };

            db.PrinterMasterData.Add(newprinter);
            db.SaveChanges();
            ResetPrintersGroupBoxItems();

            var lastPrinter = db.PrinterMasterData.OrderByDescending(p => p.ID).First();
            labelResult.Text = "Принтер: " + lastPrinter.PrinterName + " беше добавен успешно!";
            labelResult.Text += Environment.NewLine + "Модел: " + db.PrinterModels.Where(p => p.ID == lastPrinter.PrinterModeID).Select(p => p.PrinterModel).First() +
                Environment.NewLine + "IP Адрес: " + lastPrinter.IPAddress;
            labelResult.Text += Environment.NewLine + "Склад: " + db.Branches.Where(b => b.ID == lastPrinter.BranchID).Select(b => b.BranchName).First() +
                Environment.NewLine + "Pharmos PrintID: " + lastPrinter.PrintID;
            labelResult.Text += Environment.NewLine + "DNS: " + lastPrinter.DNSName;
            labelResult.Text += Environment.NewLine + "Описание: " + lastPrinter.Description;
        }

        public int printerModelFromName(string printerModel)
        {
            var db = new PrintersDB();
            return db.PrinterModels.Where(p => p.PrinterModel == printerModel).Select(i => i.ID).First();
        }

        public int branchIDFromName(string branchName)
        {
            var db = new PrintersDB();
            return db.Branches.Where(b => b.BranchName == branchName).Select(i => i.ID).First();
        }

        private void ResetPrintersGroupBoxItems()
        {
            printerNameTextBox.Text = "";
            IPAddressTextBox.Text = "";
            listPrinterModels.SelectedIndex = 0;
            printIDTextBox.Text = "";
            listBranches.SelectedIndex = 0;
            dnsNameTextBox.Text = "";
            descriptionTextBox.Text = "";
            activeCheckBox.Checked = true;
        }
        /*
        private void listAllPrintersButton_Click(object sender, EventArgs e)
        {
            ShowPrinters frm = new ShowPrinters();
            frm.FormClosed += Frm_FormClosed;
            this.Hide();
            frm.Show();            
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        */
    }
}
