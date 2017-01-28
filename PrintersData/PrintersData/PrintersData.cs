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

        private void PrintersData_Load(object sender, EventArgs e)
        {
            var db = new PrintersDB();

            //Fill comboBox with printer models from the db
            listPrinterModels.Items.Insert(0, "(Choose Printer Model)");
            foreach(var p in db.PrinterModels)
            {
                listPrinterModels.Items.Add(p.PrinterModel);
            }
            listPrinterModels.SelectedIndex = 0;

            //Fill comboBox with branches from the db
            listBranches.Items.Insert(0, "(Choose Branch)");
            foreach(var b in db.Branches)
            {
                listBranches.Items.Add(b.BranchName);
            }
            listBranches.SelectedIndex = 0;
        }

        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(printerNameTextBox.Text)
                || string.IsNullOrEmpty(IPAddresstextBox.Text)
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
                labelResult.Text = "Изберете Склад и Модел Принтер";
                return;
            }
            if(!isBranchSelected)
            {
                labelResult.Text = "Изберете Склад";
            }
            if (!isPrinterModelSelected)
            {
                labelResult.Text = "Изберете Модел Принтер";
            }

            DialogResult confirmAddPrinter = MessageBox.Show($"Сигурни ли сте, че искате да добавите принтер \"{printerNameTextBox.Text}\"", "Confirm", MessageBoxButtons.YesNo);
            
        }
    }
}
