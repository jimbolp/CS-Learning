using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Digit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            IdConvert(idTextBox.Text);
        }

        public void IdConvert(string id)
        {
            pznTextBox.Text = "";
            List<int> pzn = new List<int>();
            try
            {
                pzn = id.Split(' ').Select(x => int.Parse(x)).ToList();
            }
            catch (Exception e)
            {
                pznTextBox.Text = "";
            }
            foreach (var item in pzn)
            {
                pznTextBox.Text += item;
            }
        }

        private void pznTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
