using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintersData
{
    public partial class AddPrinterModel : Form
    {
        public AddPrinterModel()
        {
            InitializeComponent();
        }
        private void addPrinterModelBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(printerModelTextBx.Text))
            {
                labelResult.Text = "Попълнете модел принтер";
                return;
            }
            var db = new PrintersDBContext();
            DialogResult confirmAddPrinterModel = MessageBox.Show($"Сигурни ли сте, че искате да добавите модел принтер \"{printerModelTextBx.Text}\"?", "Confirm", MessageBoxButtons.YesNo);
            if(confirmAddPrinterModel == DialogResult.No)
            {
                labelResult.Text = "Не бяха направени промени";
                return;
            }
            SqlParameter printerModel = new SqlParameter("@printerModel", printerModelTextBx.Text);
            PrinterModels newPrinterModel = new PrinterModels
            {
                PrinterModel = printerModel.SqlValue.ToString()
            };

            db.PrinterModels.Add(newPrinterModel);
            db.SaveChanges();
            printerModelTextBx.Text = "";

            //var lastInserted = db.PrinterModels.AsNoTracking().FirstOrDefault(p => p.ID == newPrinterModel.ID);
            //int newId = newPrinterModel.ID;
            labelResult.Text = "Принтер модел " + newPrinterModel.PrinterModel + " беше добавен успешно";
            
        }
    }
}
