﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomerReturns
{
    public partial class CustomerReturns : Form
    {
        private string subject = "";
        private string body = "";
        public CustomerReturns()
        {
            InitializeComponent();
            subject = "";
            body = "";
        }
        List<Invoice> invoices = new List<Invoice>();
        bool isBranchValid()
        {
            int temp;
            if(int.TryParse(branchTextBox.Text, out temp))
            {
                return true;
            }
            return false;
        }
        private void invoiceNoTextBox_TextChanged(object sender, EventArgs e)
        {
            invoiceNoTextBox.Text = isNumber(invoiceNoTextBox.Text);
        }
        string isNumber(string input)
        {
            //invoiceNoTextBox.Text = "";
            string checkedText = "";
            foreach (var ch in input)
            {
                int temp = 0;
                if(int.TryParse(ch.ToString(), out temp)){
                    checkedText += temp.ToString();
                }                    
            }
            return checkedText;
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (!isSafeToClick())
            {
                if (invoices.Count == 0)
                {
                    labelResult.Text = "Полетата не трябва да бъдат празни";
                    return;
                }
                else
                {
                    if (invoices.Count == 1)
                    {
                        WriteDateAndSubject(false);
                        WriteBody(false);
                        SendByEmail();
                    }
                    else
                    {
                        WriteDateAndSubject(true);
                        WriteBody(true);
                        SendByEmail();
                    }
                }
                Process.Start("log.txt");           
            }
            else
            {
                DateTime date;
                if (DateTime.TryParseExact(invoiceDateTextBox.Text, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    invoices.Add(new Invoice(int.Parse(invoiceNoTextBox.Text),
                        date, int.Parse(customerTextBox.Text), int.Parse(branchTextBox.Text), labelResult.Text));
                    clearFields();
                }
            }
        }
        private void WriteBody(bool mult)
        {
            if (mult)
            {
                labelResult.Text = body = "Please load the following invoices:" + Environment.NewLine + Environment.NewLine;
                File.AppendAllText("log.txt", Environment.NewLine +
                "Please load the following invoices:" +
                    Environment.NewLine);
                foreach (var l in invoices)
                {
                    labelResult.Text = body += l;
                    File.AppendAllText("log.txt", l.ToString());
                }
                labelResult.Text = body += Environment.NewLine + "The invoices are not available in the invoice history (DKHIS) and have to be reloaded!";
                File.AppendAllText("log.txt", Environment.NewLine +
                    "The invoices are not available in the invoice history (DKHIS) and have to be reloaded!" +
                    Environment.NewLine);
                
            }
            else
            {
                labelResult.Text = body = "Please load the following invoice:" + Environment.NewLine + Environment.NewLine;
                File.AppendAllText("log.txt", Environment.NewLine +
                "Please load the following invoice:" +
                    Environment.NewLine);
                foreach (var l in invoices)
                {
                    labelResult.Text = body += l;
                    File.AppendAllText("log.txt", l.ToString());
                }
                labelResult.Text = body += Environment.NewLine + "The invoice is not available in the invoice history (DKHIS) and has to be reloaded!";
                File.AppendAllText("log.txt", Environment.NewLine +
                    "The invoice is not available in the invoice history (DKHIS) and has to be reloaded!" +
                    Environment.NewLine);
            }
        }
        private void WriteDateAndSubject(bool mult)
        {
            if (!mult)
            {
                labelResult.Text += "Subject: Customer Returns - load old invoice into invoice history"
                                + Environment.NewLine;
                File.AppendAllText("log.txt", Environment.NewLine +
                                DateTime.Now.ToShortDateString() +
                                Environment.NewLine +
                                "Subject: Customer Returns - load old invoice into invoice history" +
                                Environment.NewLine);
                subject = "Customer Returns - load old invoice into invoice history";
            }
            else
            {
                labelResult.Text += "Subject: Customer Returns - load old invoices into invoice history"
                                + Environment.NewLine;
                File.AppendAllText("log.txt", Environment.NewLine +
                                DateTime.Now.ToShortDateString() +
                                Environment.NewLine +
                                "Subject: Customer Returns - load old invoices into invoice history" +
                                Environment.NewLine);
                subject = "Customer Returns - load old invoices into invoice history";
            }
        }
        class Invoice
        {
            public Int64 InvoiceNo { get; set; }
            public DateTime InvoiceDate { get; set; }
            public int CustomerNo { get; set; }
            public int BranchNo { get; set; }
            public Invoice(Int64 invoiceNum, DateTime date, int customerNo, int branchNo, string labelText)
            {
                InvoiceNo = invoiceNum;
                InvoiceDate = date;
                CustomerNo = customerNo;
                BranchNo = branchNo;                
            }
            public override string ToString()
            {
                return  "Invoice no. [" + InvoiceNo +
                        "] from [" + InvoiceDate.ToShortDateString() +
                        "] for customer [" + CustomerNo +
                        "] in branch [" + BranchNo + "]" +
                        Environment.NewLine;
            }
        }
        bool isSafeToClick()
        {
            if (invoiceNoTextBox.Text == "" || invoiceDateTextBox.Text == "" ||
                customerTextBox.Text == "" || branchTextBox.Text == "")
                return false;
            return true;
        }
        void clearFields()
        {
            invoiceNoTextBox.Text = "";
            invoiceDateTextBox.Text = "";
            customerTextBox.Text = "";
            branchTextBox.Text = "";
        }
        private void nextInvoiceButton_Click(object sender, EventArgs e)
        {
            if (isSafeToClick())
            {
                DateTime date;
                    if (DateTime.TryParseExact(invoiceDateTextBox.Text, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        invoices.Add(new Invoice(Int64.Parse(invoiceNoTextBox.Text),
                            date, int.Parse(customerTextBox.Text), int.Parse(branchTextBox.Text), labelResult.Text));
                        clearFields();
                        labelResult.Text = "";
                        var invoice = invoices[invoices.Count - 1];
                        labelResult.Text += Environment.NewLine + "Invoice no. [" + invoice.InvoiceNo +
                            "] from [" + invoice.InvoiceDate.ToShortDateString() +
                            "] for customer [" + invoice.CustomerNo +
                            "] in branch [" + invoice.BranchNo + "]" +
                            Environment.NewLine;                              
                }
                else
                {
                    labelResult.Text = "Въведете валидна дата";
                }

            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            clearFields();
            invoices = new List<Invoice>();
            labelResult.Text = ""; 
        }
        private void SendByEmail()
        {
            try
            {
                int errCode = SendEmail.Send(subject, body);
                if (errCode == 1)
                {
                    MessageBox.Show("An Error Occured while sending the email!", "Error");
                }
                else
                {
                    MessageBox.Show("Message Sent to ServiceDesk");
                }
                /*
                if (string.IsNullOrEmpty(subject) || string.IsNullOrWhiteSpace(subject))
                    return;
                string toEmail = "servicedesk.it@phoenixpharma.bg";
                Outlook.Application app = new Outlook.Application();
                MailItem eMail = (MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);
                eMail.Subject = subject;
                eMail.Body = body;
                eMail.To = toEmail;
                eMail.Send();
                Marshal.FinalReleaseComObject(eMail);
                Marshal.FinalReleaseComObject(app);
                GC.Collect();
                GC.Collect();//*/
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
