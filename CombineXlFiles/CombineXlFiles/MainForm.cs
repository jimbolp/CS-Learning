using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace CombineXlFiles
{
    public partial class MainForm : Form
    {
        public delegate void EnableDelegateClip();
        public delegate void EnableSaveFileDelegate();
        public static string fileNameToSave { get; set; }
        public List<string> LoadedFiles { get; set; }
        public static MainForm form = null;
        public MainForm()
        {
            InitializeComponent();
            form = this;
        }
        public static void SaveFileName()
        {
            form?.Sfn();
        }

        private void Sfn()
        {
            if (InvokeRequired)
            {
                Invoke(new EnableSaveFileDelegate(Sfn), new object[] { });
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                fileNameToSave = sfd.FileName;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void ClearClipboard()
        {
            form?.ClClip();
        }

        private void ClClip()
        {
            if(InvokeRequired)
            {
                Invoke(new EnableDelegateClip(ClClip), new object[] { });
                return;
            }
            try
            {
                Clipboard.Clear();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                LoadAllXlFiles(fbd.SelectedPath);
            }            
        }
        private void LoadAllXlFiles(string filePath)
        {
            var temp = from file in Directory.EnumerateFiles(filePath)
                                        where Path.GetExtension(file) == ".xls" || Path.GetExtension(file) == ".xlsx"
                                        select file;
            LoadedFiles = temp.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            XlHandler xlFiles;
            Thread t = new Thread(() =>
            {
                xlFiles = new XlHandler();
                if (xlFiles == null)
                {
                    return;
                }
                foreach (string file in LoadedFiles)
                {
                    try
                    {
                        xlFiles.CopyFileToNewWB(file);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                xlFiles.SaveNewFile();
            });
            //t.SetApartmentState(ApartmentState.STA);
            t.Start();            
        }
    }
}
