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
        public AddPrinter(PrinterMasterData printerToEdit)
        {
            printerIDToEdit = printerToEdit.ID;
            InitializeComponent();
            InitializeFields(printerToEdit);
            editPrinterButton.Visible = true;
            editPrinterButton.Enabled = true;
        }
        public int printerIDToEdit { get; set; }
        private void InitializeFields(PrinterMasterData p)
        {
            printerNameTextBox.Text = p.PrinterName.ToString();
            IPAddressTextBox.Text = p.IPAddress.ToString();
            printIDTextBox.Text = p.PrintID.ToString();
            descriptionTextBox.Text = p.Description.ToString();
            dnsNameTextBox.Text = Convert.ToString(p.DNSName);
            activeCheckBox.Checked = p.Active.Value;
            fillDropDownLists();
            listBranches.SelectedItem = p.Branches.BranchName.ToString();            
            listPrinterModels.SelectedItem = p.PrinterModels.PrinterModel.ToString();
        }
        public void fillDropDownLists()
        {
            var db = new PrintersDBContext();
            var sortedPrinterModels = db.PrinterModels.OrderBy(p => p.PrinterModel);
            listPrinterModels.Items.Insert(0, "(Изберете модел принтер)");
            foreach (var p in sortedPrinterModels)
            {
                listPrinterModels.Items.Add(p.PrinterModel);
            }
            listPrinterModels.SelectedIndex = 0;

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
            var db = new PrintersDBContext();

            bool isPrinterModelSelected = db.PrinterModels.Any(p => p.PrinterModel == listPrinterModels.SelectedItem.ToString());
            bool isBranchSelected = db.Branches.Any(b => b.BranchName == listBranches.SelectedItem.ToString());

            if (!isPrinterModelSelected && !isBranchSelected)
            {
                labelResult.Text = "Изберете склад и модел принтер";
                return;
            }
            if (!isBranchSelected)
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

            var newPrinter = new PrinterMasterData
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

            db.PrinterMasterData.Add(newPrinter);
            db.SaveChanges();
           

            //var lastPrinter = db.PrinterMasterData.OrderByDescending(p => p.ID).First();
            labelResult.Text = "Принтер: " + newPrinter.PrinterName + " беше добавен успешно!";
            /*
            labelResult.Text += Environment.NewLine + "Модел: " + db.PrinterModels.Where(p => p.ID == newPrinter.PrinterModeID).Select(p => p.PrinterModel).FirstOrDefault();
            labelResult.Text += Environment.NewLine + "IP Адрес: " + newPrinter.IPAddress;
            labelResult.Text += Environment.NewLine + "Склад: " + db.Branches.Where(b => b.ID == newPrinter.BranchID).Select(b => b.BranchName).FirstOrDefault();
            labelResult.Text += Environment.NewLine + "Pharmos PrintID: " + newPrinter.PrintID;
            labelResult.Text += Environment.NewLine + "DNS: " + newPrinter.PrintID;
            labelResult.Text += Environment.NewLine + "Описание: " + newPrinter.Description;
            /*///
            DialogResult addNewPrinter = MessageBox.Show("Желаете ли да добавите нов принтер?", "Confirm", MessageBoxButtons.YesNo);
            if (addNewPrinter == DialogResult.No)
                this.Close();
            else
                ResetPrintersGroupBoxItems();
        }

        public int printerModelFromName(string printerModel)
        {
            var db = new PrintersDBContext();
            return db.PrinterModels.Where(p => p.PrinterModel == printerModel).Select(i => i.ID).FirstOrDefault();
        }

        public int branchIDFromName(string branchName)
        {
            var db = new PrintersDBContext();
            return db.Branches.Where(b => b.BranchName == branchName).Select(i => i.ID).FirstOrDefault();
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

        private void editPrinterButton_Click(object sender, EventArgs e)
        {         
            UpdateDB();
            this.Close();       
        }
     
        void UpdateDB()
        {          
            var db = new PrintersDBContext();
            var printer = db.PrinterMasterData.FirstOrDefault(p => p.ID == printerIDToEdit);
            if (printer.PrinterName != printerNameTextBox.Text)
                printer.PrinterName = printerNameTextBox.Text;
            if (printer.Description != descriptionTextBox.Text)
                printer.Description = descriptionTextBox.Text;
            if (printer.DNSName != dnsNameTextBox.Text)
                printer.DNSName = dnsNameTextBox.Text;
            if (printer.IPAddress != IPAddressTextBox.Text)
                printer.IPAddress = IPAddressTextBox.Text;
            if (printer.PrintID != printIDTextBox.Text)
                printer.PrintID = printIDTextBox.Text;
            if ((printer.Active ?? false) != activeCheckBox.Checked)
                printer.Active = activeCheckBox.Checked;

            PrinterModels pm = db.PrinterModels.FirstOrDefault(p => p.ID == printer.PrinterModeID);

            if(listPrinterModels.SelectedItem.ToString() != pm.PrinterModel.ToString())
            {
                pm = db.PrinterModels.FirstOrDefault(p => p.PrinterModel == listPrinterModels.SelectedItem.ToString());
                printer.PrinterModeID = pm.ID;
            }

            Branches br = db.Branches.FirstOrDefault(b => b.ID == printer.BranchID);

            if(listBranches.SelectedItem.ToString() != br.BranchName.ToString())
            {
                br = db.Branches.FirstOrDefault(b => b.BranchName == 
                listBranches.SelectedItem.ToString());
                printer.BranchID = br.ID;
            }

            db.SaveChanges();
            
        }     
    }
}
